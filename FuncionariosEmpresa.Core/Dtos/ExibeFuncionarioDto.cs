using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosEmpresa.Core.Dtos;

public class ExibeFuncionarioDto
{
    public string? Nome { get; set; }

    public string? Cpf { get; set; }

    public string? Email { get; set; }

    public string? NumeroCelular { get; set; }

    public DateTime? HoraDaConsulta { get; set; } = DateTime.Now;
}
