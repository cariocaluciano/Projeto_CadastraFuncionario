using FuncionariosEmpresa.Core.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosEmpresa.Core.Modelos;

public class Transacoes
{
    public long Id { get; set; }
    public DateTime DataCriacaoOuAlteracao { get; set; } = DateTime.Now;
    public ETipoTransacao InclusaoOuAlteracao { get; set; } = ETipoTransacao.Inclusao;

    public Funcionarios Funcionarios { get; set; } = null!;
}
