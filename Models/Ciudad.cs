using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class Ciudad
{
    public int Consecutivo { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public string? FldOrigen { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
