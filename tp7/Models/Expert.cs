using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Expert
{
    public int IdExpert { get; set; }

    public string Nom { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<DossiersSinistre> DossiersSinistres { get; } = new List<DossiersSinistre>();
}
