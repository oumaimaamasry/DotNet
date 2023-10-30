using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Intervention
{
    public int CodeIntervention { get; set; }

    public int CodeDos { get; set; }

    public DateTime DateIntervention { get; set; }

    public virtual DossiersSinistre? CodeDosNavigation { get; set; } //= null;
}
