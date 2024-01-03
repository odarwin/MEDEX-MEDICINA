using System;
using System.Collections.Generic;

namespace ProyectoMedexcard.Entities
{
    public partial class Ficha_ClientePlan
    {
        public int Fcp_Id { get; set; }
        public int Fcp_IdCliente { get; set; }
        public int? Fcp_Edad { get; set; }
        public string Fcp_Cedula { get; set; } = null!;
        public string? Fcp_Telefono1 { get; set; }
        public string? Fcp_Telefono2 { get; set; }
        public string? Fcp_Correo { get; set; }
        public string? Fcp_DirDomicilio { get; set; }
        public string? Fcp_DirLaboral { get; set; }
        public int Fcp_IdPlan { get; set; }
        public decimal Fcp_ValorPlan { get; set; }
        public decimal? Fcp_ValorLetrasPlan { get; set; }
        public DateTime? Fcp_FechaCreacion { get; set; }
        public DateTime? Fcp_FechaElimina { get; set; }
        public DateTime? Fcp_FechaModifica { get; set; }
        public int? Fcp_UsuElimina { get; set; }
        public int? Fcp_UsuModifica { get; set; }
        public int? Fcp_UsuCreacion { get; set; }
        public string? Fcp_Estado { get; set; }
        public string? Fcp_Secuencia { get; set; }

        public virtual Cliente Fcp_IdClienteNavigation { get; set; } = null!;
        public virtual Plan Fcp_IdPlanNavigation { get; set; } = null!;
    }
}
