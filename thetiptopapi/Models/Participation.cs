using System;
using System.Collections.Generic;

namespace thetiptopapi.Models;

public partial class Participation
{
    public int IdParticipation { get; set; }

    public DateOnly? DateParticipation { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
