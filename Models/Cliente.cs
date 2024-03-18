using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class Cliente
{
    public int Consecutivo { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? NumeroRif { get; set; }

    public string? Direccion { get; set; }

    public int ConsecutivoCiudad { get; set; }

    public string? Ciudad { get; set; }

    public string? ZonaPostal { get; set; }

    public string? Telefono { get; set; }

    public string? Status { get; set; }

    public string? Contacto { get; set; }

    public string? ZonaDeCobranza { get; set; }

    public string? Email { get; set; }

    public string? TipoDocumento { get; set; }

    public string? TipoDeContribuyente { get; set; }

    public virtual Ciudad ConsecutivoCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
