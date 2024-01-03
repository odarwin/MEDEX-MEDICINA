using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            FichaPlans = new HashSet<FichaPlan>();
        }

        public int Em_Id { get; set; }
        public int Em_IdPersona { get; set; }
        public DateTime? Em_FechaCreacion { get; set; }
        public DateTime? Em_FechaModifica { get; set; }
        public DateTime? Em_FechaElimina { get; set; }
        public int? Em_UsuCreacion { get; set; }
        public int? Em_UsuModifica { get; set; }
        public int? Em_UsuElimina { get; set; }
        public string? Em_Rol { get; set; }
        public bool Em_Activo { get; set; }
        public bool Em_Eliminado { get; set; }

        public virtual Persona Em_IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<FichaPlan> FichaPlans { get; set; }
    }
}
