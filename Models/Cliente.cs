using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
    
    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Rut { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Empresa { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [Display(Name = "Segmento")]
        public int? SegmentoId { get; set; }

        [ForeignKey("SegmentoId")]
        public virtual SegmentoCliente Segmento { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }

        public Cliente()
        {
            this.Ciudades = new HashSet<Ciudad>();
            this.FechaCreacion = DateTime.Now;
        }
    }
}