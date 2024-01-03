using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class FichaPlan
    {
        public int Fp_Id { get; set; }
        public int? Fp_IdCiudad { get; set; }
        public int? Fp_IdEmpleado { get; set; }
        public DateTime Fp_FechaCreacion { get; set; }
        public DateTime Fp_Fecha { get; set; }
        public int? Fp_UsuCreacion { get; set; }
        public int Fp_IdPlan { get; set; }
        public DateTime? Fp_FechaModifica { get; set; }
        public DateTime? Fp_FechaElimina { get; set; }
        public int? Fp_UsuModifica { get; set; }
        public int? Fp_UsuElimina { get; set; }
        public bool Fp_Eliminado { get; set; }
        public string Fp_Secuencia { get; set; } = null!;

        public virtual Ciudad? Fp_IdCiudadNavigation { get; set; }
        public virtual Empleado? Fp_IdEmpleadoNavigation { get; set; }
        public virtual Plan Fp_IdPlanNavigation { get; set; } = null!;
    }
}
