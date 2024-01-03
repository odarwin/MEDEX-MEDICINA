using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class SecuenciaFormulario
    {
        public int Se_Id { get; set; }
        public string? Se_Formulario { get; set; }
        public int Se_Valor { get; set; }
        public string? Se_Anio { get; set; }
        public bool Se_Activo { get; set; }
    }
}
