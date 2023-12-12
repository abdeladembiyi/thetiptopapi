using System;
using System.Collections.Generic;

namespace thetiptopapi.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string? Role { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public string? MotDepasse { get; set; }

    public string? DateDeNaissance { get; set; }

    public DateOnly? DateCreation { get; set; }

    public DateOnly? DateModification { get; set; }

    public DateOnly? DateSuppresion { get; set; }

    public string? AncienMotDepasse { get; set; }

    public string? Sexe { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();
}
