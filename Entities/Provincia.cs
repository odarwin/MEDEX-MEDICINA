using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Ciudads = new HashSet<Ciudad>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}
