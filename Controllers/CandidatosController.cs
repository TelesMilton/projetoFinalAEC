using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetoFinalAEC.Servicos;
using web_renderizacao_server_side.Helpers;
using web_renderizacao_server_side.Models;
using projetoFinalAEC.Models;

namespace projetoFinalAEC.Controllers
{
    [Logado]
    public class CandidatosController : Controller
    {
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await CandidatoServico.TodosPaginado(pagina));
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var candidato = await CandidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                var cand = await CandidatoServico.Salvar(candidato);
                return Redirect($"/Alunos/Details/{cand.Id}");
            }
            return View(candidato);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var candidato = await CandidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(candidato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Candidato candidato)
        {
            if (id != Id_Candidato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await CandidatoServico.Salvar(candidato);
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await candidatoServico.BuscaPorId(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await CandidatoServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}