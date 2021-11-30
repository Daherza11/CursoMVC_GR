using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace biblioteca.Models
{
    public class EstadoCliente
    {
        [Key]
        public int idestadocliente { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<cliente> clientes { get; set; }
    }
}