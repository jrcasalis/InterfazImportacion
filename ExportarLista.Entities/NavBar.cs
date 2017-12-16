using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExportarLista.Entities
{
    [Table("dbo.Menus")]
    public class NavBar : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "El largo máximo de {0} es de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El largo máximo de {0} es de {1} caracteres.")]
        public String Controlador { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El largo máximo de {0} es de {1} caracteres.")]
        public String Accion { get; set; }

        [StringLength(100, ErrorMessage = "El largo máximo de {0} es de {1} caracteres.")]
        [DisplayName("Clase imagen")]
        public String ClaseImagen { get; set; }

        [ForeignKey("IdPadre")]
        public NavBar Padre { get; set; }

        [DisplayName("Menú superior")]
        public int? IdPadre { get; set; }

        [DisplayName("Es contenedor")]
        public bool EsPadre { get; set; }
        public bool TieneHijos { get; set; }

        [DisplayName("Activo")]
        public bool Estado { get; set; }

        [StringLength(50, ErrorMessage = "El largo máximo de {0} es de {1} caracteres.")]
        public string LiActivo { get; set; }
    }
}
