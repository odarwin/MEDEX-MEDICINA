using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProyectoMedexcard.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public bool Activo { get; set; }
    public string Origen { get; set; }
    public DateTime FechaCreacion { get; set; }
}

