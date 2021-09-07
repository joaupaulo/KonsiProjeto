using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonsiLoja.Models
{
    public class RelatorioGeral
    {
        public int RelatorioGeralId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Contrato Contrato { get; set; }
        public int ContratoId { get; set; }
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }




    }
}
