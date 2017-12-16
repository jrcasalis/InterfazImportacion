namespace ExportarLista.Entities.E1
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CRPDTA.F01151")]
    public partial class F01151:EntityBase
    {
        [Key]
        [Column(Order = 0)]
        public double EAAN8 { get; set; }

        [Key]
        [Column(Order = 1)]
        public double EAIDLN { get; set; }

        [Key]
        [Column(Order = 2)]
        public double EARCK7 { get; set; }

        [StringLength(4)]
        public string EAETP { get; set; }

        [StringLength(256)]
        public string EAEMAL { get; set; }

        [StringLength(10)]
        public string EAUSER { get; set; }

        [StringLength(10)]
        public string EAPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EAUPMJ { get; set; }

        [StringLength(10)]
        public string EAJOBN { get; set; }

        public double? EAUPMT { get; set; }

        public double? EAEHIER { get; set; }

        [StringLength(15)]
        public string EAEFOR { get; set; }

        [StringLength(3)]
        public string EAECLASS { get; set; }

        public double? EACFNO1 { get; set; }

        [StringLength(10)]
        public string EAGEN1 { get; set; }

        [StringLength(1)]
        public string EAFALGE { get; set; }

        public double? EASYNCS { get; set; }

        public double? EACAAD { get; set; }
    }
}
