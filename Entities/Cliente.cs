using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ficha_ClientePlans = new HashSet<Ficha_ClientePlan>();
        }

        public int Cl_Id { get; set; }
        public DateTime? Cl_FechaCreacion { get; set; }
        public DateTime? Cl_FechaModifica { get; set; }
        public DateTime? Cl_FechaElimina { get; set; }
        public int? Cl_UsuCreacion { get; set; }
        public int? Cl_UsuElimina { get; set; }
        public int? Cl_UsuModifica { get; set; }
        public bool Cl_Activo { get; set; }
        public bool Cl_Eliminado { get; set; }
        public int Cl_IdPersona { get; set; }

        public virtual Persona Cl_IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<Ficha_ClientePlan> Ficha_ClientePlans { get; set; }
    }
}
