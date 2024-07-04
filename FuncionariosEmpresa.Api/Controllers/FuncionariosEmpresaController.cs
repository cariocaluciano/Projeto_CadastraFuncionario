using AutoMapper;
using FuncionariosEmpresa.Api.Dados;
using FuncionariosEmpresa.Core.Dtos;
using FuncionariosEmpresa.Core.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace FuncionariosEmpresa.Api.Controllers;

public class FuncionariosEmpresaController : Controller
{
    private readonly FuncionariosContext _context;
    private IMapper _mapper;

    public FuncionariosEmpresaController(FuncionariosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("/AdicionaFuncionario")]
    public IActionResult AdicionaFuncionario([FromBody] AdicionaFuncionarioDto funcionarioDto)
    {
        Funcionarios funcionario = _mapper.Map<Funcionarios>(funcionarioDto);

        _context.Funcionarios.Add(funcionario);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ExibeFuncionario), new
        {
            cpf = funcionario.Cpf
        }, funcionario);
    }

    [HttpGet("/Funcionarios")]
    public IEnumerable<ExibeFuncionarioDto> ExibeFuncionarios([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ExibeFuncionarioDto>>(_context.Funcionarios.Skip(skip).Take(take)); 
            
    }

    [HttpGet("/BuscaFuncionario{cpf}")]
    public IActionResult ExibeFuncionario(string cpf)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Cpf == cpf);
        if (funcionario == null) return NotFound();

        var funcionarioDto = _mapper.Map<ExibeFuncionarioDto>(funcionario);

        return Ok(funcionarioDto);
    }

    [HttpPut("/AtualizaFuncionario{cpf}")]
    public IActionResult AtualizaFuncionario(string cpf, [FromBody] AtualizaFuncionarioDto funcionarioDto)
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Cpf == cpf);
        if (funcionario == null) return NotFound();

        _mapper.Map(funcionarioDto, funcionario);
        _context.Funcionarios.Update(funcionario);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("/RemoveFuncionario{cpf}")]
    public IActionResult RemoveFuncionario(string cpf) 
    {
        var funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Cpf == cpf);
        if (funcionario == null) return NotFound();
        _context.Remove(funcionario);
        _context.SaveChanges();
        return NoContent();
    }

}
