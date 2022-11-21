using System;
using System.Collections.Generic;

namespace VideoTutorial.Models;

public partial class Empleado
{
    public long Id { get; set; }

    public string? Nombre { get; set; }

    public long IdArea { get; set; }

    public virtual Empleado IdAreaNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> InverseIdAreaNavigation { get; } = new List<Empleado>();
}
