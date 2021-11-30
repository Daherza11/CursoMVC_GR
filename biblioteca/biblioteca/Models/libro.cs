namespace biblioteca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("libro")]
    public partial class libro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public libro()
        {
            prestamo = new HashSet<prestamo>();
        }

        [Key]
        public int idlibro { get; set; }

        [StringLength(50)]
        [Display(Name ="Título")]
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public string titulo { get; set; }

        [StringLength(50)]
        [Display(Name = "Autor")]
        public string autor { get; set; }

        [Display(Name = "Páginas")]
        [Range(1,int.MaxValue,ErrorMessage ="Ingrese un número mayor que {1} y menor que {2}.")]
        public int? paginas { get; set; }

        [StringLength(50)]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Column(TypeName ="date")]
        [Display(Name = "Fecha de publicación")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [DataType(DataType.Date,ErrorMessage ="Ingrese una fecha válida.")]
        public DateTime fecha_pub { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<prestamo> prestamo { get; set; }
    }
}
