using UnityEngine;

public class ZonaInteractable : MonoBehaviour
{
    private Zona zona;

    public void Configurar(Zona zonaConfig)
    {
        zona = zonaConfig;
    }

    private void OnMouseDown()
    {
        Debug.Log($"Zona seleccionada: {zona.NombreZona}");
        Debug.Log($"Descripción: {zona.Descripcion}");
        Debug.Log($"Tiene Tesoro: {zona.TieneTesoro}");
        Debug.Log($"Es Peligrosa: {zona.EsPeligrosa}");
    }
}