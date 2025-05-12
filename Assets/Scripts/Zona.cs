using UnityEngine;

public class Zona : Node<Zona>
{
    public string NombreZona { get; private set; }
    public string Descripcion { get; private set; }
    public bool TieneTesoro { get; private set; }
    public bool EsPeligrosa { get; private set; }

    public Zona(string nombreZona, string descripcion, bool tieneTesoro, bool esPeligrosa)
        : base()
    {
        NombreZona = nombreZona;
        Descripcion = descripcion;
        TieneTesoro = tieneTesoro;
        EsPeligrosa = esPeligrosa;
    }
}