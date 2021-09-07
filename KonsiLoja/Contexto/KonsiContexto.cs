using KonsiLoja.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonsiLoja.Contexto
{
    public class KonsiContexto : DbContext
    {

       

            public KonsiContexto(DbContextOptions<KonsiContexto> options) : base(options)
            {

            }

            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Contrato> Contratos { get; set; }
            public DbSet<Vendedor> Vendedors { get; set; }
           
         

        
    }
}