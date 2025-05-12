using UnityEngine;

public class ControladorMapa : MonoBehaviour
{
    public GameObject spritePrefab;
    public GameObject lineRendererPrefab;
    public GameObject textPrefab;
    public Transform parent;
    public Canvas canvas;

    private MapaInteractivo mapa;

    void Start()
    {
        mapa = new MapaInteractivo();

        // Crear Zonas
        var zona1 = new Zona("Bosque", "Un bosque frondoso lleno de criaturas.", true, false);
        var zona2 = new Zona("Cueva", "Una cueva oscura y peligrosa.", false, true);
        var zona3 = new Zona("Ciudad Abandonada", "Ruinas de una ciudad antigua.", false, true);

        mapa.AgregarZona("Z1", zona1, new Vector3(0, 0, 0), spritePrefab, textPrefab, parent, canvas);
        mapa.AgregarZona("Z2", zona2, new Vector3(2, 2, 0), spritePrefab, textPrefab, parent, canvas);
        mapa.AgregarZona("Z3", zona3, new Vector3(-2, 2, 0), spritePrefab, textPrefab, parent, canvas);

        // Conectar Zonas
        mapa.ConectarZonas("Z1", "Z2", lineRendererPrefab, parent);
        mapa.ConectarZonas("Z1", "Z3", lineRendererPrefab, parent);
    }
}