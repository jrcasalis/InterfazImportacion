namespace ExportarLista.Entities.E1
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODDTA.F0413")]
    public partial class F0413 : EntityBase
    {
        [Key]
        public double RMPYID { get; set; }

        [StringLength(2)]
        public string RMDCTM { get; set; }

        public double? RMDOCM { get; set; }

        public double? RMPYE { get; set; }

        [StringLength(8)]
        public string RMGLBA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RMDMTJ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RMVDGJ { get; set; }

        public double? RMICU { get; set; }

        [StringLength(2)]
        public string RMICUT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RMDICJ { get; set; }

        public double? RMPAAP { get; set; }

        [StringLength(3)]
        public string RMCRCD { get; set; }

        [StringLength(1)]
        public string RMCRRM { get; set; }

        [StringLength(1)]
        public string RMAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RMVLDT { get; set; }

        [StringLength(1)]
        public string RMPYIN { get; set; }

        [StringLength(1)]
        public string RMISTP { get; set; }

        [StringLength(20)]
        public string RMCBNK { get; set; }

        [StringLength(8)]
        public string RMBKTR { get; set; }

        [StringLength(10)]
        public string RMTORG { get; set; }

        [StringLength(10)]
        public string RMUSER { get; set; }

        [StringLength(10)]
        public string RMPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RMUPMJ { get; set; }

        public double? RMUPMT { get; set; }

        [StringLength(10)]
        public string RMJOBN { get; set; }

        [StringLength(1)]
        public string RMMIP { get; set; }

        [StringLength(1)]
        public string RMLRFL { get; set; }

        [StringLength(1)]
        public string RMPRGF { get; set; }

        [StringLength(1)]
        public string RMGFL7 { get; set; }

        [StringLength(1)]
        public string RMGFL8 { get; set; }

        public double? RMGAM3 { get; set; }

        public double? RMGAM4 { get; set; }

        [StringLength(25)]
        public string RMGEN6 { get; set; }

        [StringLength(25)]
        public string RMGEN7 { get; set; }

        public double? RMNETTCID { get; set; }

        public double? RMNETDOC { get; set; }

        [StringLength(1)]
        public string RMRCND { get; set; }

        [StringLength(8)]
        public string RMR3 { get; set; }

        public double? RMCNTRTID { get; set; }

        [StringLength(12)]
        public string RMCNTRTCD { get; set; }

        public double? RMWVID { get; set; }

        [StringLength(10)]
        public string RMBLSCD2 { get; set; }

        [StringLength(6)]
        public string RMHARPER { get; set; }

        [StringLength(10)]
        public string RMHARSFX { get; set; }
    }
}
