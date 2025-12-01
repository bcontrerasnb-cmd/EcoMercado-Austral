using System;
using System.ComponentModel.DataAnnotations;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {
        public class ClienteMetadata
        {
            // Validaciones para RUT
            [Required(ErrorMessage = "El RUT es obligatorio")]
            [StringLength(20)]
            public string Rut { get; set; }

            // Validaciones para NOMBRE
            [Required(ErrorMessage = "El nombre es obligatorio")]
            [StringLength(100)]
            [Display(Name = "Nombre del Cliente")]
            public string Nombre { get; set; }

            // Validaciones para EMPRESA
            [StringLength(100)]
            [Display(Name = "Nombre de la Empresa")]
            public string Empresa { get; set; }

            // Validaciones para EMAIL
            [EmailAddress(ErrorMessage = "Formato de correo inválido")]
            [StringLength(100)]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            // Validaciones para TELÉFONO
            [StringLength(20)]
            [Display(Name = "Teléfono de Contacto")]
            public string Telefono { get; set; }

            // METADATA DE AUDITORÍA
            [Display(Name = "Fecha Registro")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime FechaCreacion { get; set; }

            [Display(Name = "Última Modificación")]
            public DateTime? FechaModificacion { get; set; }
        }
    }
}