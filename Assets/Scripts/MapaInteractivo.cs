using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapaInteractivo : Graph<string, Zona>
{
    public Dictionary<string, GameObject> NodoVisuales = new Dictionary<string, GameObject>();
    public Dictionary<string, TextMeshProUGUI> TextoVisuales = new Dictionary<string, TextMeshProUGUI>();

    public void AgregarZona(string id, Zona zona, Vector3 posicion, GameObject spritePrefab, GameObject textPrefab, Transform parent, Canvas canvas)
    {
        AddNode(id, zona);

        if (spritePrefab == null || textPrefab == null)
        {
            Debug.LogError("Error: El prefab del sprite o del texto no está asignado.");
            return;
        }

        if (parent == null || canvas == null)
        {
            Debug.LogError("Error: El objeto padre (parent) o el Canvas no está asignado.");
            return;
        }

        // Instancia del nodo visual
        GameObject nodoVisual = Object.Instantiate(spritePrefab, posicion, Quaternion.identity, parent);
        nodoVisual.name = zona.NombreZona;
        NodoVisuales[id] = nodoVisual;

        // Instancia del texto visual
        GameObject textoObj = Object.Instantiate(textPrefab, canvas.transform);
        TextMeshProUGUI textoUI = textoObj.GetComponent<TextMeshProUGUI>();
        textoUI.text = zona.NombreZona;
        TextoVisuales[id] = textoUI;

        // Mensaje de depuración para verificar la creación del texto
        Debug.Log($"Texto para '{zona.NombreZona}' creado en Canvas.");

        // Sincronización con la posición del nodo en el Canvas
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(nodoVisual.transform.position);
        textoUI.transform.position = screenPosition;

        // Ajuste adicional para elevar el texto
        textoUI.transform.position += new Vector3(0, 50, 0);

        // Agregar interacción
        var zonaInteractable = nodoVisual.AddComponent<ZonaInteractable>();
        zonaInteractable.Configurar(zona);
    }

    public void ConectarZonas(string id1, string id2, GameObject lineRendererPrefab, Transform parent)
    {
        if (Nodes.ContainsKey(id1) && Nodes.ContainsKey(id2))
        {
            AddEdge(id1, id2);

            if (lineRendererPrefab == null)
            {
                Debug.LogError("Error: El prefab de LineRenderer no está asignado.");
                return;
            }

            GameObject lineObj = Object.Instantiate(lineRendererPrefab, parent);
            LineRenderer line = lineObj.GetComponent<LineRenderer>();
            line.positionCount = 2;
            line.SetPosition(0, NodoVisuales[id1].transform.position);
            line.SetPosition(1, NodoVisuales[id2].transform.position);
        }
    }

    private void LateUpdate()
    {
        foreach (var item in NodoVisuales)
        {
            if (TextoVisuales.ContainsKey(item.Key))
            {
                TextoVisuales[item.Key].transform.position = Camera.main.WorldToScreenPoint(item.Value.transform.position + new Vector3(0, 1, 0));
            }
        }
    }
}