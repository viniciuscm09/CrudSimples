using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoEmprestimo.Models;

namespace ProjetoEmprestimo.Data
{
    public class DadosContex : DbContext
    {
        public DadosContex(DbContextOptions<DadosContex> options) : base(options)
        {


        }
        public DbSet<EmpreestimoModel> Emprestimos { get; set; }


    }
}
