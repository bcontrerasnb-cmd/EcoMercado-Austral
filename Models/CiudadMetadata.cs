using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    [MetadataType(typeof(CiudadMetadata))]
    [Table("Ciudad")]
    public partial class Ciudad
    {

        public class CiudadMetadata
        {
            [Required(ErrorMessage = "La región es obligatoria")]
            [StringLength(100)]
            [Display(Name = "Región")]
            public string Region { get; set; }

            [Required(ErrorMessage = "La provincia es obligatoria")]
            [StringLength(100)]
            [Display(Name = "Provincia")]
            public string Provincia { get; set; }

            [Required(ErrorMessage = "El nombre de la comuna es obligatorio")]
            [StringLength(50)]
            [Display(Name = "Comuna")]
            public string Nombre { get; set; }
        }
    }
}