using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_renderizacao_server_side.Models;

namespace projetoFinalAec.Servicos.ServicoRefatorado
{
    public interface IHttpClientService<T> : IDisposable
    {
        Task<List<T>> Todos(int pagina = 1);
        Task<Paginacao<T>> TodosPaginado(int pagina = 1);
        Task<T> BuscaPorId(int id);
        Task<T> Salvar(T entidade);
        Task ExcluirPorId(int id);
    }
}