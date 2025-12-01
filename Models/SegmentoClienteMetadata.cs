using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    [MetadataType(typeof(SegmentoClienteMetadata))]
    [Table("SegmentoCliente")]

    public partial class SegmentoCliente
    {
        public class SegmentoClienteMetadata
        {
            [Required(ErrorMessage = "El nombre del segmento es obligatorio")]
            [StringLength(50)]
            [Display(Name = "Nombre Segmento")]
            public string Nombre { get; set; }

            [StringLength(200)]
            [Display(Name = "Descripción")]
            [DataType(DataType.MultilineText)] // Esto hace que el EditorFor cree un TextArea automático
            public string Descripcion { get; set; }

            [StringLength(50)]
            [Display(Name = "Estado Actual")]
            public string Estado { get; set; }
        }
    }
}