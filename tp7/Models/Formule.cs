using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Formule
{
    public int CodeFormule { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Contrat> Contrats { get; } = new List<Contrat>();

    public virtual ICollection<Prevision> Previsions { get; } = new List<Prevision>();
}
