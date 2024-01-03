using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            FichaPlans = new HashSet<FichaPlan>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
        public int idProvincia { get; set; }

        public virtual Provincia idProvinciaNavigation { get; set; } = null!;
        public virtual ICollection<FichaPlan> FichaPlans { get; set; }
    }
}
