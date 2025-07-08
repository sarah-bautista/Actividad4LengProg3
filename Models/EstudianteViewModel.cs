using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(15, MinimumLength = 6)]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Debes seleccionar una carrera.")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "Correo inválido.")]
        public string CorreoInstitucional { get; set; }

        [Phone(ErrorMessage = "Número telefónico no válido.")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener al menos 10 dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El turno es obligatorio.")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "El tipo de ingreso es obligatorio.")]
        public string TipoIngreso { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje debe ser entre 0 y 100.")]
        public int? PorcentajeBeca { get; set; }


        public bool AceptaTerminos { get; set; }
    }
}

