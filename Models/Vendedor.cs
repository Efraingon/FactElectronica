using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class Vendedor
{
    public int Consecutivo { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Rif { get; set; }

    public string? StatusVendedor { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
