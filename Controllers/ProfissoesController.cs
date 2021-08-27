using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetoFinalAEC.Models;
using projetoFinalAEC.Servicos;
using web_renderizacao_server_side.Models;


namespace projetoFinalAEC.Controllers
{

    [Logado]
    public class ProfissoesController : Controller
    {
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(await ProfissaoServico.Todos(pagina));
        }

        // GET: Candidatos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var profissao = await PaiServico.BuscaPorId(id);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        // GET: Candidatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profissao profissao)
        {
            if (ModelState.IsValid)
            {
                var p = await ProfissaoServico.Salvar(profissao);
                return Redirect($"/Profissoes/Details/{p.Id}");
            }
            return View(profissao);
        }

        // GET: Candidatos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var profissao = await PaiServico.BuscaPorId(id);
            if (profissao == null)
            {
                return NotFound();
            }
            return View(profissao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Profissao profissao)
        {
            if (id != profissao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await ProfissaoServico.Salvar(profissao);
                return RedirectToAction(nameof(Index));
            }
            return View(profissao);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var profissao = await ProfissaoServico.BuscaPorId(id);
            if (profissao == null)
            {
                return NotFound();
            }

            return View(profissao);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await CandidatoServico.ExcluirPorId(id);
            return RedirectToAction(nameof(Index));
        }
    }
}