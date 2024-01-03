using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Plan
    {
        public Plan()
        {
            FichaPlans = new HashSet<FichaPlan>();
            Ficha_ClientePlans = new HashSet<Ficha_ClientePlan>();
        }

        public int pl_id { get; set; }
        public string? pl_codigo { get; set; }
        public string? pl_descripcion { get; set; }
        public bool? pl_activo { get; set; }
        public DateTime pl_fecha_creacion { get; set; }
        public DateTime? pl_fecha_modificacion { get; set; }
        public int? pl_usu_creacion { get; set; }
        public int? pl_usu_modificacion { get; set; }
        public DateTime? pl_fecha_elimina { get; set; }
        public int? pl_usu_elimina { get; set; }

        public virtual ICollection<FichaPlan> FichaPlans { get; set; }
        public virtual ICollection<Ficha_ClientePlan> Ficha_ClientePlans { get; set; }
    }
}
