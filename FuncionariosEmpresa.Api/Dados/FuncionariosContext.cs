using FuncionariosEmpresa.Core.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosEmpresa.Api.Dados;

public class FuncionariosContext : DbContext
{
    public FuncionariosContext(DbContextOptions<FuncionariosContext>opts) : base(opts)
    {
        
    }

    public DbSet<Funcionarios> Funcionarios { get; set; }
    public DbSet<Transacoes> Transacoes { get; set; }

}
