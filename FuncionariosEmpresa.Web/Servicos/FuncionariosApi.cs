using FuncionariosEmpresa.Core.Dtos;
using System.Net.Http.Json;

namespace FuncionariosEmpresa.Web.Servicos;

public class FuncionariosApi
{
    private readonly HttpClient _httpClient;

    public FuncionariosApi(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Api");
    }

    public async Task<ICollection<ExibeFuncionarioDto>?> ExibeFuncionariosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ExibeFuncionarioDto>>("funcionarios");
    }

    public async Task AddFuncionarioAsync(AdicionaFuncionarioDto funcionario)
    {
        await _httpClient.PostAsJsonAsync("AdicionaFuncionario", funcionario);
    }

    public async Task DeleteArtistaAsync(string funcionarioCpf)
    {
        await _httpClient.DeleteAsync($"RemoveFuncionario{funcionarioCpf}");
    }

    public async Task<ExibeFuncionarioDto?> GetFuncionarioPorCpfAsync(string cpf)
    {
        return await _httpClient.GetFromJsonAsync<ExibeFuncionarioDto>($"BuscaFuncionario{cpf}");
    }

    public async Task AtualizaFuncionarioAsync(string cpf, AtualizaFuncionarioDto funcionario)
    {
        await _httpClient.PutAsJsonAsync($"AtualizaFuncionario{cpf}", funcionario);
    }

}
