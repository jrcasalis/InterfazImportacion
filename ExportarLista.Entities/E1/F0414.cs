namespace ExportarLista.Entities.E1
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODDTA.F0414")]
    public partial class F0414 : EntityBase
    {
        [Key]
        [Column(Order = 0)]
        public double RNPYID { get; set; }

        [Key]
        [Column(Order = 1)]
        public double RNRC5 { get; set; }

        [StringLength(2)]
        public string RNDCTM { get; set; }

        [StringLength(5)]
        public string RNKCO { get; set; }

        [StringLength(2)]
        public string RNDCT { get; set; }

        public double? RNDOC { get; set; }

        [StringLength(3)]
        public string RNSFX { get; set; }

        public double? RNSFXE { get; set; }

        public double? RNPAAP { get; set; }

        public double? RNADSC { get; set; }

        public double? RNADSA { get; set; }

        public double? RNPFAP { get; set; }

        public double? RNCDS { get; set; }

        public double? RNCDSA { get; set; }

        [StringLength(1)]
        public string RNCRRM { get; set; }

        [StringLength(3)]
        public string RNCRCD { get; set; }

        public double? RNCRR { get; set; }

        [StringLength(4)]
        public string RNGLC { get; set; }

        [StringLength(1)]
        public string RNPOST { get; set; }

        [StringLength(1)]
        public string RNALT6 { get; set; }

        public double? RNPN { get; set; }

        public double? RNFY { get; set; }

        public double? RNCTRY { get; set; }

        [StringLength(1)]
        public string RNFNLP { get; set; }

        public double? RNAN8 { get; set; }

        [StringLength(5)]
        public string RNCO { get; set; }

        [StringLength(12)]
        public string RNMCU { get; set; }

        [StringLength(8)]
        public string RNPO { get; set; }

        [StringLength(30)]
        public string RNRMK { get; set; }

        public double? RNHCRR { get; set; }

        [StringLength(10)]
        public string RNUSER { get; set; }

        [StringLength(10)]
        public string RNPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RNUPMJ { get; set; }

        public double? RNUPMT { get; set; }

        [StringLength(10)]
        public string RNJOBN { get; set; }

        [StringLength(3)]
        public string RNBCRC { get; set; }

        [StringLength(1)]
        public string RNLRFL { get; set; }

        [StringLength(1)]
        public string RNGFL7 { get; set; }

        [StringLength(1)]
        public string RNGFL8 { get; set; }

        public double? RNGAM3 { get; set; }

        public double? RNGAM4 { get; set; }

        [StringLength(25)]
        public string RNGEN6 { get; set; }

        [StringLength(25)]
        public string RNGEN7 { get; set; }

        [StringLength(3)]
        public string RNDRCO { get; set; }

        public double? RNNETTCID { get; set; }

        public double? RNNETDOC { get; set; }

        public double? RNNETRC5 { get; set; }

        public double? RNCNTRTID { get; set; }

        [StringLength(12)]
        public string RNCNTRTCD { get; set; }

        public double? RNWVID { get; set; }

        [StringLength(10)]
        public string RNBLSCD2 { get; set; }

        [StringLength(6)]
        public string RNHARPER { get; set; }

        [StringLength(10)]
        public string RNHARSFX { get; set; }
    }
}
