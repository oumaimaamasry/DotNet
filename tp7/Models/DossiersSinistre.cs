using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class DossiersSinistre
{
    public int CodeDossier { get; set; }

    public DateTime DateOuverture { get; set; }

    public DateTime DateCloture { get; set; }

    public string Indemnite { get; set; } = null!;

    public int? NumContrat { get; set; }

    public int? Idcorrespondant { get; set; }

    public int? IdExpert { get; set; }

    public virtual Expert? IdExpertNavigation { get; set; }

    public virtual Correspondant? IdcorrespondantNavigation { get; set; }

    public virtual ICollection<Intervention> Interventions { get; } = new List<Intervention>();

    public virtual Contrat? NumContratNavigation { get; set; }
}
