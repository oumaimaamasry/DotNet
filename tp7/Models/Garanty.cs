using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Garanty
{
    public int CodeGarantie { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Prevision> Previsions { get; } = new List<Prevision>();
}
