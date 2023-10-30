using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Contrat
{
    public int Num { get; set; }

    public DateTime DateSouscription { get; set; }

    public DateTime DateEcheance { get; set; }

    public int? IdClient { get; set; }

    public int? NumFor { get; set; }

    public virtual ICollection<DossiersSinistre> DossiersSinistres { get; } = new List<DossiersSinistre>();

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Formule? NumForNavigation { get; set; }
}
