using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonsiLoja.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        [Required]
        public int CPF { get; set; }
        public int ? VendedoresId { get; set; }
        public Vendedor Vendedores { get; set; }
        public Contrato Contrato { get; set; }
        public List<RelatorioGeral> RelatorioGeral { get; set; }
         
      
    }
}
