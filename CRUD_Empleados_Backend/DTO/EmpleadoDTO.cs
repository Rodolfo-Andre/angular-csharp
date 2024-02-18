using System.ComponentModel.DataAnnotations;

namespace CRUD_Empleados_Backend.Models
{
    public class EmpleadoGeneral
    {
        [Required(ErrorMessage = "El campo 'Nombre' es requerido")]
        [MinLength(3, ErrorMessage = "El campo 'Nombre' debe tener una longitud mínima de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "El campo 'Nombre' debe tener una longitud máxima de 50 caracteres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Apellido' es requerido")]
        [MinLength(3, ErrorMessage = "El campo 'Apellido' debe tener una longitud mínima de 3 caracteres")]
        [MaxLength(50, ErrorMessage = "El campo 'Apellido' debe tener una longitud máxima de 50 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Código de Teléfono' es requerido")]
        public string CodigoTelefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Teléfono' es requerido")]
        [MinLength(9, ErrorMessage = "El campo 'Teléfono' debe tener una longitud mínima de 9 caracteres")]
        [MaxLength(16, ErrorMessage = "El campo 'Teléfono' debe tener una longitud máxima de 16 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Correo' es requerido")]
        [EmailAddress(ErrorMessage = "El campo 'Correo' debe tener un formato válido")]
        [MaxLength(50, ErrorMessage = "El campo 'Correo' debe tener una longitud máxima de 50 caracteres")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Fecha de Nacimiento' es requerido")]
        public string FechaNacimiento { get; set; } = string.Empty;
        public decimal Sueldo { get; set; }

        [Required(ErrorMessage = "El campo 'Estado Civil' es requerido")]
        public string EstadoCivil { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Area de Trabajo' es requerido")]
        public int IdAreaTrabajo { get; set; }

        [Required(ErrorMessage = "El campo 'País de Nacimiento' es requerido")]
        public int IdPaisNacimiento { get; set; }

        [Required(ErrorMessage = "El campo 'Tipo de Documento' es requerido")]
        public int IdTipoDocumento { get; set; }

        [Required(ErrorMessage = "El campo 'Número de Documento' es requerido")]
        [MinLength(8, ErrorMessage = "El campo 'Número de Documento' debe tener una longitud mínima de 8 caracteres")]
        [MaxLength(16, ErrorMessage = "El campo 'Número de Documento' debe tener una longitud máxima de 16 caracteres")]
        public string NroDocumento { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo 'Sexo' es requerido")]
        [MaxLength(1, ErrorMessage = "El campo 'Sexo' debe tener una longitud máxima de 1 caracter")]
        public string Sexo { get; set; } = string.Empty;
    }

    public class EmpleadoObtener : EmpleadoGeneral
    {
        public int Id { get; set; }
        public string AreaTrabajo { get; set; } = string.Empty;
        public string PaisNacimiento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }

    public class EmpleadoRegistrar : EmpleadoGeneral
    {
    }

    public class EmpleadoActualizar : EmpleadoGeneral
    {
        [Required(ErrorMessage = "El campo 'Id del Empleado' es requerido")]
        public int IdEmpleado { get; set; }
    }

    public class EmpleadoEstado 
    {
        [Required(ErrorMessage = "El campo 'Id del Empleado' es requerido")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El campo 'Estado' es requerido")]
        public int Estado { get; set; }
    }
}
