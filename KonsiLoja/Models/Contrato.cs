using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KonsiLoja.Models
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        [DisplayName("Número do contrato")]
        public int NumeroContrato { get; set; }
        [DisplayName("Valor do contrato")]
        public decimal ValorContrato { get; set; }
        [DisplayName("Saldo Devedor")]
        public decimal SaldoDevedor { get; set; }
        [DisplayName("Parcelas Totais")]
        public int ParcelasTotais { get; set; }
        [DisplayName("Parcelas Pagas")]
        public int ParcelasPagas { get; set; }
        [DisplayName("Valor de Parcelas")]
        public int ValorParcela { get; set; }
        public Vendedor Vendedores { get; set; }
        public int ? VendedoresId { get; set; }
        public Cliente Clientes { get; set; }
        public int ? ClientesId { get; set; }
        public List<RelatorioGeral> RelatorioGeral { get; set; }




    }
}
