using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosEmpresa.Core.Modelos;

public class Funcionarios
{
    [Key]
    public long Id { get; set; }
    [MaxLength(50)]
    public string? Nome { get; set; }
    [MaxLength(11)]
    public string? Cpf { get; set; }
    [MaxLength(50)]
    public string? Email { get; set; }
    [MaxLength(13)]
    public string? NumeroCelular { get; set; } 
}
