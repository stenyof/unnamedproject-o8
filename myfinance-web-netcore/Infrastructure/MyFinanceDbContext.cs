using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Infrastructure.Entities;

namespace myfinance_web_netcore.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; } // <- Adicionado aqui
    }
}