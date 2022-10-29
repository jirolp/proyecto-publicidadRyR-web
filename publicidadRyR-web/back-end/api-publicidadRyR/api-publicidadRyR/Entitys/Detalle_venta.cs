using System.ComponentModel.DataAnnotations;

namespace api_publicidadRyR.Entitys
{
    public class Detalle_venta
    {
        [Key]
        public int id_detalle_venta { get; set; }
        [Required]
        public Venta id_venta { get; set; }
        [Required]
        public Juguetes id_prod { get; set; }
        [Required]
        public int cantidad { get; set; }
    }
}
