namespace ExportarLista.Entities.E1
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODDTA.F0101")]
    public partial class F0101:EntityBase
    {
        [Key]
        public double ABAN8 { get; set; }

        [StringLength(20)]
        public string ABALKY { get; set; }

        [StringLength(20)]
        public string ABTAX { get; set; }

        [StringLength(40)]
        public string ABALPH { get; set; }

        [StringLength(40)]
        public string ABDC { get; set; }

        [StringLength(12)]
        public string ABMCU { get; set; }

        [StringLength(10)]
        public string ABSIC { get; set; }

        [StringLength(2)]
        public string ABLNGP { get; set; }

        [StringLength(3)]
        public string ABAT1 { get; set; }

        [StringLength(2)]
        public string ABCM { get; set; }

        [StringLength(1)]
        public string ABTAXC { get; set; }

        [StringLength(1)]
        public string ABAT2 { get; set; }

        [StringLength(1)]
        public string ABAT3 { get; set; }

        [StringLength(1)]
        public string ABAT4 { get; set; }

        [StringLength(1)]
        public string ABAT5 { get; set; }

        [StringLength(1)]
        public string ABATP { get; set; }

        [StringLength(1)]
        public string ABATR { get; set; }

        [StringLength(1)]
        public string ABATPR { get; set; }

        [StringLength(1)]
        public string ABAB3 { get; set; }

        [StringLength(1)]
        public string ABATE { get; set; }

        [StringLength(1)]
        public string ABSBLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ABEFTB { get; set; }

        public double? ABAN81 { get; set; }

        public double? ABAN82 { get; set; }

        public double? ABAN83 { get; set; }

        public double? ABAN84 { get; set; }

        public double? ABAN86 { get; set; }

        public double? ABAN85 { get; set; }

        [StringLength(3)]
        public string ABAC01 { get; set; }

        [StringLength(3)]
        public string ABAC02 { get; set; }

        [StringLength(3)]
        public string ABAC03 { get; set; }

        [StringLength(3)]
        public string ABAC04 { get; set; }

        [StringLength(3)]
        public string ABAC05 { get; set; }

        [StringLength(3)]
        public string ABAC06 { get; set; }

        [StringLength(3)]
        public string ABAC07 { get; set; }

        [StringLength(3)]
        public string ABAC08 { get; set; }

        [StringLength(3)]
        public string ABAC09 { get; set; }

        [StringLength(3)]
        public string ABAC10 { get; set; }

        [StringLength(3)]
        public string ABAC11 { get; set; }

        [StringLength(3)]
        public string ABAC12 { get; set; }

        [StringLength(3)]
        public string ABAC13 { get; set; }

        [StringLength(3)]
        public string ABAC14 { get; set; }

        [StringLength(3)]
        public string ABAC15 { get; set; }

        [StringLength(3)]
        public string ABAC16 { get; set; }

        [StringLength(3)]
        public string ABAC17 { get; set; }

        [StringLength(3)]
        public string ABAC18 { get; set; }

        [StringLength(3)]
        public string ABAC19 { get; set; }

        [StringLength(3)]
        public string ABAC20 { get; set; }

        [StringLength(3)]
        public string ABAC21 { get; set; }

        [StringLength(3)]
        public string ABAC22 { get; set; }

        [StringLength(3)]
        public string ABAC23 { get; set; }

        [StringLength(3)]
        public string ABAC24 { get; set; }

        [StringLength(3)]
        public string ABAC25 { get; set; }

        [StringLength(3)]
        public string ABAC26 { get; set; }

        [StringLength(3)]
        public string ABAC27 { get; set; }

        [StringLength(3)]
        public string ABAC28 { get; set; }

        [StringLength(3)]
        public string ABAC29 { get; set; }

        [StringLength(3)]
        public string ABAC30 { get; set; }

        [StringLength(8)]
        public string ABGLBA { get; set; }

        public double? ABPTI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ABPDI { get; set; }

        [StringLength(1)]
        public string ABMSGA { get; set; }

        [StringLength(30)]
        public string ABRMK { get; set; }

        [StringLength(20)]
        public string ABTXCT { get; set; }

        [StringLength(20)]
        public string ABTX2 { get; set; }

        [StringLength(40)]
        public string ABALP1 { get; set; }

        [StringLength(2)]
        public string ABURCD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ABURDT { get; set; }

        public double? ABURAT { get; set; }

        public double? ABURAB { get; set; }

        [StringLength(15)]
        public string ABURRF { get; set; }

        [StringLength(10)]
        public string ABUSER { get; set; }

        [StringLength(10)]
        public string ABPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ABUPMJ { get; set; }

        [StringLength(10)]
        public string ABJOBN { get; set; }

        public double? ABUPMT { get; set; }

        [StringLength(1)]
        public string ABPRGF { get; set; }

        [StringLength(2)]
        public string ABSCCLTP { get; set; }

        [StringLength(10)]
        public string ABTICKER { get; set; }

        [StringLength(10)]
        public string ABEXCHG { get; set; }

        [StringLength(13)]
        public string ABDUNS { get; set; }

        [StringLength(3)]
        public string ABCLASS01 { get; set; }

        [StringLength(3)]
        public string ABCLASS02 { get; set; }

        [StringLength(3)]
        public string ABCLASS03 { get; set; }

        [StringLength(3)]
        public string ABCLASS04 { get; set; }

        [StringLength(3)]
        public string ABCLASS05 { get; set; }

        public double? ABNOE { get; set; }

        public double? ABGROWTHR { get; set; }

        [StringLength(15)]
        public string ABYEARSTAR { get; set; }

        [StringLength(5)]
        public string ABAEMPGP { get; set; }

        [StringLength(1)]
        public string ABACTIN { get; set; }

        [StringLength(5)]
        public string ABREVRNG { get; set; }

        public double? ABSYNCS { get; set; }

        public double? ABPERRS { get; set; }

        public double? ABCAAD { get; set; }
    }
}
