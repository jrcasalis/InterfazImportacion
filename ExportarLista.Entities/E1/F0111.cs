namespace ExportarLista.Entities.E1
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CRPDTA.F0111")]
    public partial class F0111:EntityBase
    {
        [Key]
        [Column(Order = 0)]
        public double WWAN8 { get; set; }

        [Key]
        [Column(Order = 1)]
        public double WWIDLN { get; set; }

        public double? WWDSS5 { get; set; }

        [StringLength(40)]
        public string WWMLNM { get; set; }

        [StringLength(40)]
        public string WWATTL { get; set; }

        [StringLength(40)]
        public string WWREM1 { get; set; }

        [StringLength(40)]
        public string WWSLNM { get; set; }

        [StringLength(40)]
        public string WWALPH { get; set; }

        [StringLength(40)]
        public string WWDC { get; set; }

        [StringLength(25)]
        public string WWGNNM { get; set; }

        [StringLength(25)]
        public string WWMDNM { get; set; }

        [StringLength(25)]
        public string WWSRNM { get; set; }

        [StringLength(1)]
        public string WWTYC { get; set; }

        [StringLength(3)]
        public string WWW001 { get; set; }

        [StringLength(3)]
        public string WWW002 { get; set; }

        [StringLength(3)]
        public string WWW003 { get; set; }

        [StringLength(3)]
        public string WWW004 { get; set; }

        [StringLength(3)]
        public string WWW005 { get; set; }

        [StringLength(3)]
        public string WWW006 { get; set; }

        [StringLength(3)]
        public string WWW007 { get; set; }

        [StringLength(3)]
        public string WWW008 { get; set; }

        [StringLength(3)]
        public string WWW009 { get; set; }

        [StringLength(3)]
        public string WWW010 { get; set; }

        [StringLength(40)]
        public string WWMLN1 { get; set; }

        [StringLength(40)]
        public string WWALP1 { get; set; }

        [StringLength(10)]
        public string WWUSER { get; set; }

        [StringLength(10)]
        public string WWPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WWUPMJ { get; set; }

        [StringLength(10)]
        public string WWJOBN { get; set; }

        public double? WWUPMT { get; set; }

        [StringLength(3)]
        public string WWNTYP { get; set; }

        [StringLength(40)]
        public string WWNICK { get; set; }

        [StringLength(1)]
        public string WWGEND { get; set; }

        public double? WWDDATE { get; set; }

        public double? WWDMON { get; set; }

        public double? WWDYR { get; set; }

        [StringLength(3)]
        public string WWWN001 { get; set; }

        [StringLength(3)]
        public string WWWN002 { get; set; }

        [StringLength(3)]
        public string WWWN003 { get; set; }

        [StringLength(3)]
        public string WWWN004 { get; set; }

        [StringLength(3)]
        public string WWWN005 { get; set; }

        [StringLength(3)]
        public string WWWN006 { get; set; }

        [StringLength(3)]
        public string WWWN007 { get; set; }

        [StringLength(3)]
        public string WWWN008 { get; set; }

        [StringLength(3)]
        public string WWWN009 { get; set; }

        [StringLength(3)]
        public string WWWN010 { get; set; }

        [StringLength(10)]
        public string WWFUCO { get; set; }

        [StringLength(10)]
        public string WWPCM { get; set; }

        [StringLength(3)]
        public string WWPCF { get; set; }

        [StringLength(1)]
        public string WWACTIN { get; set; }

        [StringLength(36)]
        public string WWCFRGUID { get; set; }

        public double? WWSYNCS { get; set; }

        public double? WWCAAD { get; set; }
    }
}
