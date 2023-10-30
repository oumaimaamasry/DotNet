using System;
using System.Collections.Generic;

namespace tp7.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public virtual ICollection<Contrat> Contrats { get; } = new List<Contrat>();
}
