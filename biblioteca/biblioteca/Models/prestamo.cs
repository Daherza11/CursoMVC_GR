namespace biblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prestamo")]
    public partial class prestamo
    {
        [Key]
        public int idprestamo { get; set; }
        [Display(Name = "Cliente")]
        public int? idcliente { get; set; }
        [Display(Name = "Libro")]
        public int? idlibro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_salida { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Fecha Devolución")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha válida.")]

        public DateTime? fecha_devolucion { get; set; }


        [StringLength(50)]
        public string estado { get; set; }

        [Display(Name = "Cliente")]

        public virtual cliente cliente { get; set; }
        [Display(Name = "Libro")]

        public virtual libro libro { get; set; }
    }
}
