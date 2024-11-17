using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dominio
{
    public class Carrito 
    { public int IdCarrito { get; set; } 
        [DisplayName("Id Producto")] 
        public int IdProducto { get; set; } 
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
    }
}