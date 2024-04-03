using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PainelIndoor.Application.Core;
using PainelIndoor.Application.Core.Services.Conteudos.ViewModels;
using PainelIndoor.Application.Core.Services.Paineis;
using PainelIndoor.Application.Core.Services.Paineis.ViewModels;

namespace PainelIndoorWeb.Controllers
{
    [Route("paineis/")]
    public class PaineisController : Controller
    {
        private readonly IPaineisService _paineisAppService;
        public PaineisController(IPaineisService paineisAppService,
            IConfiguration config)
        {
            _paineisAppService = paineisAppService;
        }

        #region Visoes
        [HttpGet]
        [Route("senai-dr")]
        [AllowAnonymous]
        public IActionResult PainelSenai(PaineisPrmtsPesquisa par)
        {
            par.CodFilial = "03MT0001";
            var dados = _paineisAppService.ModoExibicaoAsync(par);
            return View("Painel4x1", dados);
        }

        [HttpGet]
        [Route("sesi-dr")]
        [AllowAnonymous]
        public IActionResult PainelSesi(PaineisPrmtsPesquisa par)
        {
            par.CodFilial = "02MT0001";
            var dados = _paineisAppService.ModoExibicaoAsync(par);
            return View("Painel4x1", dados);
        }

        [HttpGet]
        [Route("senai-cba")]
        [AllowAnonymous]
        public IActionResult Painel2x1(PaineisPrmtsPesquisa par)
        {
            par.CodFilial = "03MT0002";
            var dados = _paineisAppService.ModoExibicaoAsync(par);
            return View("Painel2x1", dados);
        }

        [HttpGet]
        [Route("senai-lrv")]
        [AllowAnonymous]
        public IActionResult Painel1x1(PaineisPrmtsPesquisa par)
        {
            par.CodFilial = "03MT0021";
            var dados = _paineisAppService.ModoExibicaoAsync(par);
            return View("Painel1x1", dados);
        }
        #endregion

        [HttpGet]
        [Route("inicio")]
        //[Authorize(Policy = "AdministracaoPainelTV-Ler")]
        public async Task<ViewResult> Inicio(PaineisPrmtsPesquisa filtro)
        {
            var monitores = await _paineisAppService.ListarAsync(filtro);

            return View(monitores);
        }

        [HttpPost]
        [Route("inicio")]
        //[Authorize(Policy = "AdministracaoPainelTV-Ler")]
        public async Task<PartialViewResult> MonitoresPartial([FromForm] PaineisPrmtsPesquisa filtro)
        {
            var monitores = await _paineisAppService.ListarAsync(filtro);

            return PartialView("_painel_listar", monitores);

        }

        [HttpGet]
        [Route("links")]
        public IActionResult Links()
        {
            return View();
        }

        [HttpGet]
        [Route("painel-por-id")]
        //[Authorize(Policy = "AdministracaoPainelTV-Ler")]
        public async Task<IActionResult> ObterPaineilPorId([FromQuery] PaineisPrmtsPesquisa par)
        {
            try
            {
                var monitor = await _paineisAppService.ObterPainelPorIdAsync(par.Id.Value);

                return Ok(new { page = par.PaginaAtual, monitor });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = 0, message = "Ocorreu um erro em sua solicitação. Detalhes: " + ex.Message });
            }
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //[Route("monitores/alterar-monitor")]
        ////[Authorize(Policy = "AdministracaoPainelTV-Gravar")]
        //public async Task<IActionResult> AlterarMonitor([FromForm] PaineisRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _paineisAppService.AlterarMonitor(model);

        //    if (!result.Executado)

        //        return BadRequest(result);

        //    return Ok(model);
        //}

        //[HttpGet]
        //[Route("monitores/detalhes-monitor")]
        ////[Authorize(Policy = "AdministracaoPainelTV-Ler")]
        //public IActionResult DetalhesMonitor(Guid id)
        //{
        //    var monitor = _paineisAppService.ObterDetalhesMonitor(id);
        //    return View(monitor);
        //}

        //[HttpPost]
        //[Route("monitores/conteudo-por-id")]
        ////[Authorize(Policy = "AdministracaoPainelTV-Ler")]
        //public IActionResult ObterConteudoPorId([FromForm] ConteudosPrmtsPesquisa par)
        //{
        //    try
        //    {
        //        var conteudo = _paineisAppService.ObterConteudoPorId(par.Id.Value);

        //        return Ok(conteudo);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(new { status = 0, mensagem = "Ocorreu um erro em sua solicitação. Detalhes: " + ex.Message });
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("monitores/adicionar-conteudo")]
        ////[Authorize(Policy = "AdministracaoPainelTV-Gravar")]
        //public async Task<IActionResult> AdicionarConteudo([FromForm] ConteudosRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _paineisAppService.AdicionarConteudo(model);

        //    if (!result.Executado)
        //    {
        //        //var modelState = ModelStateHandler.SimpleValidation("Model", result.Mensagem);

        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("monitores/alterar-conteudo")]
        ////[Authorize(Policy = "AdministracaoPainelTV-Gravar")]
        //public async Task<IActionResult> AlterarConteudo([FromForm] ConteudosRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _paineisAppService.AlterarConteudo(model);

        //    if (!result.Executado)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}
    }
}
