using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_BastianContreras_NicoleAlegria.Models
{
   
    public partial class Ciudad
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        [StringLength(100)]
        public string Provincia { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } // Representa la Comuna

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}