using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Prevision
{
    public int CodeProvision { get; set; }

    public int CodeFor { get; set; }

    public int CodeGar { get; set; }

    public string? PlafondFranchie { get; set;}// = null!;

    public virtual Formule? CodeForNavigation { get; set; }// = null;

    public virtual Garanty? CodeGarNavigation { get; set; }// = null;
}
