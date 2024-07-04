using AutoMapper;
using FuncionariosEmpresa.Core.Dtos;
using FuncionariosEmpresa.Core.Modelos;

namespace FuncionariosEmpresa.Core.Profiles;

public class FuncionariosProfile : Profile
{
    public FuncionariosProfile()
    {
        CreateMap<AdicionaFuncionarioDto, Funcionarios>();
        CreateMap<AtualizaFuncionarioDto, Funcionarios>();
        CreateMap<Funcionarios, ExibeFuncionarioDto>();

    }
}
