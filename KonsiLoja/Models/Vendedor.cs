using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonsiLoja.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        [Required]
        [RegularExpression("(\\d{0,5})", ErrorMessage = "O cdigo do vendedor precisa de 5 digitos")]
        public int Codigo { get; set; }
        [DisplayName("Vendedor")]
        public string Nome { get; set; }
        public List<Contrato> Contratos { get; set; }
        public List<Cliente> Clientes { get; set; }
      
    }
}
  