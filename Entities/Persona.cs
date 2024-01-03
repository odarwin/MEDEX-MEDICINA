using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
            Empleados = new HashSet<Empleado>();
        }

        public int Per_Id { get; set; }
        public string Per_Nombre { get; set; } = null!;
        public string Per_Apellido { get; set; } = null!;
        public string? Per_NombreCompleto { get; set; }
        public string? Per_Cedula { get; set; }
        public string? Per_TipoIdentificacion { get; set; }
        public string? Per_Ruc { get; set; }
        public string? Per_Pasaporte { get; set; }
        public DateTime? Per_FechaNacimiento { get; set; }
        public DateTime? Per_FechaCreacion { get; set; }
        public int? Per_UsuCreacion { get; set; }
        public int? Per_UsuModifica { get; set; }
        public int? Per_FechaModifica { get; set; }
        public int? Per_UsuElimina { get; set; }
        public DateTime? Per_FechaElimina { get; set; }
        public bool Per_Activo { get; set; }
        public bool Per_Eliminado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
