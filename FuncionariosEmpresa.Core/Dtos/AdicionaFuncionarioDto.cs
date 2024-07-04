using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosEmpresa.Core.Dtos;

public class AdicionaFuncionarioDto
{
    public AdicionaFuncionarioDto(string? nome, string? cpf, string? email, string? numeroCelular)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        NumeroCelular = numeroCelular;
    }

    public string? Nome { get; set; }
    [StringLength(11)]
    public string? Cpf { get; set; }
    [StringLength(50)]
    public string? Email { get; set; }
    [StringLength(13)]
    public string? NumeroCelular { get; set; }
}
