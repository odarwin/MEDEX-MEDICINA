using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoMedexcard.Models.Empleados
{
    public class EmpleadoViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Cedula")]
        public string cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
       
        [Required(ErrorMessage = "Seleccione un Tipo de Empleado")]

        public int idTipoEmpleado { get; set; }

    }
    public class TipoEmpleado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
/*
 
 ,[Per_Nombre]
      ,[Per_Apellido]
      ,[Per_NombreCompleto]
      ,[Per_Cedula]
      ,[Per_TipoIdentificacion]
      ,[Per_Ruc]
      ,[Per_Pasaporte]
      ,[Per_FechaNacimiento]
      ,[Per_FechaCreacion]
      ,[Per_UsuCreacion]
      ,[Per_UsuModifica]
      ,[Per_FechaModifica]
      ,[Per_UsuElimina]
      ,[Per_FechaElimina]
      ,[Per_Activo]
      ,[Per_Eliminado]
 */