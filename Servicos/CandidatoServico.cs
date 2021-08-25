using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using projetoFinalAEC.Models;
using System.Net.Http.Json;
using web_renderizacao_server_side.Models;
using web_renderizacao_server_side;

namespace projetoFinalAEC.Servicos
{
   public class CandidatoServico
    {
        public static async Task<List<Candidato>> Todos(int pagina = 1)
        {
            return (await TodosPaginado(pagina)).Results;
        }
        public static async Task<Paginacao<Candidato>> TodosPaginado(int pagina = 1)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.CandidatosAPI}/alunos?page={pagina}"))
                {
                    if(!response.IsSuccessStatusCode) return new Paginacao<Candidato>();

                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Paginacao<Candidato>>(json);
                }
            }
        }

        public static async Task<Candidato> BuscaPorId(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.GetAsync($"{Program.CandidatosAPI}/candidatos/{id}"))
                {
                    if(!response.IsSuccessStatusCode) return null;
                    return JsonConvert.DeserializeObject<Candidato>(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public static async Task<Candidato> Salvar(Candidato candidato)
        {
            using (var http = new HttpClient())
            {
                if(candidato.Id == 0)
                {
                    using (var response = await http.PostAsJsonAsync($"{Program.AlunosAPI}/candidatos", candidato))
                    {
                        string retorno = await response.Content.ReadAsStringAsync();
                        if(!response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("========================");
                            Console.WriteLine(retorno);
                            Console.WriteLine("========================");
                            throw new Exception("Erro ao incluir na API");
                        }
                        return JsonConvert.DeserializeObject<Candidato>(retorno);
                    }
                }
                else
                {
                    using (var response = await http.PutAsJsonAsync($"{Program.CandidatosAPI}/alunos/{candidato.Id}", candidato))
                    {
                        if(!response.IsSuccessStatusCode) throw new Exception("Erro ao atualizar na API");
                        return JsonConvert.DeserializeObject<Candidato>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
        }

        public static async Task ExcluirPorId(int id)
        {
            using (var http = new HttpClient())
            {
                using (var response = await http.DeleteAsync($"{Program.CandidatosAPI}/alunos/{id}"))
                {
                    if(!response.IsSuccessStatusCode) throw new Exception("Erro ao excluir da API");
                }
            }
        }
    }
}