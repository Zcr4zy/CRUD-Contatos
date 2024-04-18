using CRUD_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Contatos.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
