using PainelIndoor.Application.Core.Enums;
using PainelIndoor.Application.Core.Extensions;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using PainelIndoor.Application.Entities;
using PainelIndoor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Conteudos
{
    public class ConteudosHandler : IConteudosService
    {
        //private readonly IHostingEnvironment _env;
        private readonly IPaineisRepository _monitoresRepository;
        private readonly IConteudosRepository _conteudosRepository;
        //private readonly GeneralOperations _generalOperations;
        //private readonly IConfiguration _config;

        private readonly string[] _extensoesPermitidas = { ".mp4", ".jpg", ".jpeg", ".png" };

        public ConteudosHandler(
            //IHostingEnvironment env,
            IPaineisRepository monitoresRepository,
            IConteudosRepository conteudosRepository
            //GeneralOperations generalOperations,
            //IConfiguration config
            )
        {
            //_env = env;
            _monitoresRepository = monitoresRepository;
            _conteudosRepository = conteudosRepository;
            //_generalOperations = generalOperations;
            //_config = config;
        }

        //public async Task<ProducaoEpsInicio> Listar(ProducaoEpsPrmtsPesquisa par, CancellationToken cancellationToken)
        //{
        //    #region DesabilitaOperacoes

        //    bool permiteGravar = _baseOperations.RequirementBase("ProducaoEps", "Gravar");

        //    bool habilitaMultiEmpresa = _baseOperations.RequirementBase("IsMultiEmpresa", "Sim");

        //    bool habilitaMultiUnidade = _baseOperations.RequirementBase("IsMultiUnidade", "Sim");

        //    bool habilitaLimparUnidade = (_baseOperations.RequirementBase("VisualizarCentroCusto", "Geral") ||
        //       _baseOperations.RequirementBase("VisualizarCentroCusto", "PorEmpresa"));

        //    #endregion

        //    par.CodEmpresa = (!habilitaMultiEmpresa || String.IsNullOrEmpty(par.CodEmpresa)) ? _baseOperations.CodEmpresa()
        //        : par.CodEmpresa;

        //    par.CodCentroCusto = (!habilitaMultiUnidade) ? _baseOperations.CodCentroCusto()
        //        //se multiunidade e habilita limpar centro de custo e centro custo é nulo
        //        : (habilitaMultiUnidade && !habilitaLimparUnidade && !par.CodCentroCusto.HasValue) ? _baseOperations.CodCentroCusto()
        //        //centro custo recebido
        //        : par.CodCentroCusto;

        //    par.Ano ??= DateTime.Now.Year;

        //    par.MesApuracao ??= DateTime.Now.Month;

        //    par.TotalItens = await _producaoEpsRepository.ContarAsync(par, cancellationToken);

        //    par.ItensPorPagina = (par.SemPaginacao) ? par.TotalItens : par.ItensPorPagina ?? 10;

        //    par.PaginaAtual = (!par.PaginaAtual.HasValue || par.PaginaAtual == 0) ? 1 : par.PaginaAtual;

        //    var lista = await _producaoEpsRepository
        //        .ObterDadosAsync(par, cancellationToken);

        //    var vm = new ProducaoEpsInicio()
        //    {
        //        ProducaoEps = lista,

        //        ParametrosPesquisa = new ProducaoEpsPrmtsPesquisa()
        //        {
        //            Id = par.Id,
        //            TextoPesquisa = par.TextoPesquisa,
        //            CodEmpresa = par.CodEmpresa,
        //            Ano = par.Ano,
        //            MesApuracao = par.MesApuracao,
        //            IdApuracao = par.IdApuracao,
        //            CodCentroCusto = par.CodCentroCusto,
        //            PaginaAtual = par.PaginaAtual.Value,
        //            ItensPorPagina = par.ItensPorPagina,
        //            TotalItens = par.TotalItens,
        //            IsLoaded = true,
        //            PaginasTotais = (par.ItensPorPagina > 0) ? int.Parse(Math.Ceiling(((decimal)par.TotalItens / par.ItensPorPagina.Value)).ToString()) : 0
        //        },



        //        HabilitaAdicionar = permiteGravar,
        //        HabilitaAlterar = permiteGravar,
        //        HabilitaExcluir = permiteGravar,
        //        HabilitaMultiEmpresa = habilitaMultiEmpresa,
        //        HabilitaMultiUnidade = habilitaMultiUnidade,
        //        HabilitaLimparUnidade = (habilitaLimparUnidade && habilitaMultiUnidade)
        //    };

        //    return vm;
        //}


        //public PainelInicio ObterMonitores(PaineisParametrosPesquisa par)
        //{
        //    //Itens a exibir, por página
        //    par.ItensPorPagina = 5;

        //    par.Pagina = par.Pagina ?? 0;

        //    //Se o parâmetro for diferente de nulo
        //    //removo os caracteres especiais
        //    if (!String.IsNullOrEmpty(par.TextoPesquisa))
        //        par.TextoPesquisa = AjustarTextos.TextoPadrao(par.TextoPesquisa);

        //    //Filtro os itens com base nos parâmetros recebidos
        //    var itensFiltrados = new MonitoresFilterSpec(par);

        //    //Filtro e pagino os itens com base nos parâmetros recebidos
        //    var itensFiltradosPaginados = new MonitoresFilterPaginatedSpec(par);

        //    //Listo os itens recebidos, filtrados e paginados
        //    var itens = _monitoresRepository
        //        .List(itensFiltradosPaginados)
        //        .ToList();

        //    //Conto o total de itens com base nos filtros aplicados
        //    var totalItens = _monitoresRepository.Count(itensFiltrados);

        //    var vm = new PainelInicio()
        //    {
        //        Monitores = itens.Select(i => new MonitoresLer()
        //        {
        //            Id = i.Id,

        //            Descricao = i.Descricao,

        //            Filial = i.Filial.NomeFilial,

        //            TipoConteudo = i.TipoConteudo,

        //            _TipoConteudo = EnumTipoConteudo.Descricao(i.TipoConteudo),

        //            Ativo = (i.IsEnabled) ? "SIM" : "NÃO"

        //        }),

        //        TextoPesquisa = par.TextoPesquisa,

        //        CodEmpresa = par.CodEmpresa,

        //        CodFilial = par.CodFilial,

        //        ChaveCentroCusto = par.ChaveCentroCusto,

        //        Ano = par.Ano,

        //        Paginacao = new Paginacao()
        //        {
        //            PaginaAtual = par.Pagina.Value,

        //            ItensPorPagina = itens.Count,

        //            TotalItens = totalItens,

        //            PaginasTotais = int.Parse(Math.Ceiling(((decimal)totalItens / par.ItensPorPagina)).ToString())
        //        }
        //    };
        //    vm.Paginacao.IsVisibleProxima = (vm.Paginacao.PaginaAtual == vm.Paginacao.PaginasTotais - 1) ? true : false;

        //    vm.Paginacao.IsVisibleAnterior = (vm.Paginacao.PaginaAtual == 0) ? true : false;

        //    return vm;
        //}

        //public MonitoresLer ObterMonitorPorId(Guid id)
        //{
        //    var item = _monitoresRepository.GetById(id);

        //    var vm = new MonitoresLer()
        //    {
        //        Id = item.Id,

        //        Descricao = item.Descricao,

        //        TipoConteudo = item.TipoConteudo,

        //        ChaveCentroCusto = item.ChaveCentroCusto,

        //        CodEmpresa = item.CodEmpresa,

        //        CodFilial = item.CodFilial,

        //        IsEnabled = item.IsEnabled
        //    };

        //    return vm;
        //}

        //public MonitoresLer ObterDetalhesMonitor(Guid id)
        //{
        //    var monitor = _monitoresRepository.ObterDetalhesMonitor(id);

        //    var vm = new MonitoresLer()
        //    {
        //        Id = monitor.Id,

        //        Descricao = monitor.Descricao,

        //        ChaveCentroCusto = monitor.ChaveCentroCusto,

        //        CodEmpresa = monitor.CodEmpresa,

        //        CodFilial = monitor.CodFilial,

        //        Filial = monitor.Filial.NomeFilial,

        //        IsEnabled = monitor.IsEnabled,

        //        TipoConteudo = monitor.TipoConteudo,

        //        Logo = (monitor.CodEmpresa == "02MT") ? "https://sesimt.ind.br/assets/images/logo-sesi.png" :
        //            "https://www.senaimt.ind.br/assets/images/logo-senai.png",

        //        Conteudos = monitor.Conteudo.Select(c => new ConteudosLer()
        //        {
        //            Id = c.Id,

        //            Caminho = c.Caminho,

        //            Descricao = c.Descricao,

        //            TipoConteudo = c.TipoConteudo,

        //            _TipoConteudo = EnumTipoConteudo.Descricao(c.TipoConteudo),

        //            IsEnabled = c.IsEnabled,

        //            _Mudo = (c.Mudo) ? "muted" : null,

        //            _AutoPlay = (c.AutoPlay) ? "autoplay" : null,

        //            _Looping = (c.Looping) ? "loop" : null,

        //            Status = (c.IsEnabled) ? "SIM" : "NÃO",

        //            MonitorId = c.MonitorId,

        //            TempoExibicao = c.TempoExibicao,

        //            DesabilitaAlterar = !(c.TipoConteudo == monitor.TipoConteudo),

        //            OcultaVideoPlayer = (c.TipoConteudo != TipoConteudo.VideoYouTube) ? "hidden" :
        //            (!c.IsEnabled) ? "hidden" : null,

        //            OcultaAtributosVideoLocal = (c.TipoConteudo == TipoConteudo.VideoLocal) ? null : "hidden",

        //            DesabilitaVideoPlayar = (c.TipoConteudo != TipoConteudo.VideoYouTube) ? true :
        //            (!c.IsEnabled) ? true : false,

        //            DesabilitaUploadFile = (monitor.TipoConteudo == TipoConteudo.VideoLocal
        //            || monitor.TipoConteudo == TipoConteudo.ImagemFixa
        //            || monitor.TipoConteudo == TipoConteudo.ImagemSlide) ? false : true
        //        }),

        //        AlterarConteudo = new ConteudosGravar()
        //        {
        //            MonitorId = monitor.Id

        //        },

        //        AdicionarConteudo = new ConteudosGravar()
        //        {
        //            MonitorId = monitor.Id,

        //            TipoConteudo = monitor.TipoConteudo,

        //            TempoExibicao = (monitor.TipoConteudo != TipoConteudo.ImagemSlide) ? 0 : 120,

        //            DesabilitaTempoExibicao = (monitor.TipoConteudo == TipoConteudo.ImagemSlide
        //                || monitor.TipoConteudo == TipoConteudo.Indicadores
        //                || monitor.TipoConteudo == TipoConteudo.PaginaBi) ? null : "readonly",

        //            OcultaUploadFile = (monitor.TipoConteudo == TipoConteudo.VideoLocal
        //            || monitor.TipoConteudo == TipoConteudo.ImagemFixa
        //            || monitor.TipoConteudo == TipoConteudo.ImagemSlide) ? null : "hidden",

        //            OcultaCaminho = (monitor.TipoConteudo == TipoConteudo.VideoLocal
        //            || monitor.TipoConteudo == TipoConteudo.ImagemFixa
        //            || monitor.TipoConteudo == TipoConteudo.ImagemSlide) ? "hidden" : null,

        //            OcultaTempoExibicao = (monitor.TipoConteudo == TipoConteudo.ImagemSlide
        //                || monitor.TipoConteudo == TipoConteudo.Indicadores
        //                || monitor.TipoConteudo == TipoConteudo.PaginaBi) ? null : "hidden",

        //            Caminho = (monitor.TipoConteudo == TipoConteudo.VideoLocal
        //            || monitor.TipoConteudo == TipoConteudo.ImagemFixa
        //            || monitor.TipoConteudo == TipoConteudo.ImagemSlide) ? "PATH DEFAULT" : null
        //        }
        //    };

        //    return vm;
        //}

        //public PainelInicio ObterDadosPaineis(string codFilial)
        //{
        //    var monitores = _monitoresRepository.ObterMonitoresPorFilial(codFilial);

        //    var vm = new PainelInicio()
        //    {
        //        Monitores = monitores.Select(m => new MonitoresLer()
        //        {
        //            Id = m.Id,

        //            TipoConteudo = m.TipoConteudo,

        //            Descricao = m.Descricao,

        //            Logo = (codFilial.Substring(0, 4) == "02MT") ? "https://sesimt.ind.br/assets/images/logo-sesi.png" :
        //            "https://www.senaimt.ind.br/assets/images/logo-senai.png",

        //            PoliticaQualidade = PoliticaQualidade(m.CodEmpresa),

        //            Conteudos = m.Conteudo.Select(c => new ConteudosLer()
        //            {
        //                MonitorId = c.MonitorId,

        //                Descricao = c.Descricao,

        //                TempoExibicao = c.TempoExibicao,

        //                Caminho = c.Caminho,

        //                TipoConteudo = c.TipoConteudo,

        //                IsEnabled = c.IsEnabled,

        //                _Mudo = (c.Mudo) ? "muted" : null,

        //                _AutoPlay = (c.AutoPlay) ? "autoplay" : null,

        //                _Looping = (c.Looping) ? "loop" : null
        //            })
        //        })
        //    };

        //    return vm;
        //}

        //public async Task<TasksResult> AlterarMonitor(MonitoresGravar model)
        //{
        //    try
        //    {
        //        model.ChaveCentroCusto = _filaisRepository.ObterDetalhesFilialPorCodigo(model.CodFilial).Result.ChaveCentroCusto;

        //        var monitor = new Application.Entities.Paineis()
        //        {
        //            Id = model.Id,

        //            ChaveCentroCusto = model.ChaveCentroCusto,

        //            Descricao = AjustarTextos.TextoPadrao(model.Descricao),

        //            CodEmpresa = model.CodFilial.Substring(0, 4),

        //            CodFilial = model.CodFilial,

        //            TipoConteudo = model.TipoConteudo,

        //            IsEnabled = model.IsEnabled
        //        };

        //        await _monitoresRepository.UpdateAsync(monitor);

        //        return new TasksResult(true, "Monitor alterado com sucesso!", null);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new TasksResult(false, "Ocorreu um erro em sua solicitação. Detalhes:" + ex.Message, null);
        //    }
        //}
        //public ConteudosLer ObterConteudoPorId(Guid id)
        //{
        //    var item = _conteudosRepository.GetById(id);

        //    var vm = new ConteudosLer()
        //    {
        //        Id = item.Id,

        //        MonitorId = item.MonitorId,

        //        Descricao = item.Descricao,

        //        TipoConteudo = item.TipoConteudo,

        //        TempoExibicao = item.TempoExibicao,

        //        DesabilitaTempoExibicao = (item.TipoConteudo == TipoConteudo.ImagemSlide
        //            || item.TipoConteudo == TipoConteudo.Indicadores
        //            || item.TipoConteudo == TipoConteudo.PaginaBi) ? null : "readonly",

        //        OcultaUploadFile = (item.TipoConteudo == TipoConteudo.VideoLocal
        //            || item.TipoConteudo == TipoConteudo.ImagemFixa
        //            || item.TipoConteudo == TipoConteudo.ImagemSlide) ? null : "hidden",

        //        OcultaCaminho = (item.TipoConteudo == TipoConteudo.VideoLocal
        //            || item.TipoConteudo == TipoConteudo.ImagemFixa
        //            || item.TipoConteudo == TipoConteudo.ImagemSlide) ? "hidden" : null,

        //        OcultaTempoExibicao = (item.TipoConteudo == TipoConteudo.ImagemSlide
        //                || item.TipoConteudo == TipoConteudo.Indicadores
        //                || item.TipoConteudo == TipoConteudo.PaginaBi) ? null : "hidden",

        //        OcultaAtributosVideoLocal = (item.TipoConteudo == TipoConteudo.VideoLocal) ? null : "hidden",

        //        Caminho = (item.TipoConteudo == TipoConteudo.VideoLocal
        //            || item.TipoConteudo == TipoConteudo.ImagemFixa
        //            || item.TipoConteudo == TipoConteudo.ImagemSlide) ? "PATH DEFAULT" : item.Caminho,

        //        IsEnabled = item.IsEnabled,

        //        AutoPlay = item.AutoPlay,

        //        Mudo = item.Mudo,

        //        Looping = item.Looping
        //    };

        //    return vm;
        //}

        //public async Task<TasksResult> AdicionarConteudo(ConteudosGravar model)
        //{
        //    try
        //    {
        //        model.Id = Guid.NewGuid();

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && (model.Arquivo == null || model.Arquivo.Length == 0))

        //            return new TasksResult(false, "É necessário anexar o arquivo!", null);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && model.Arquivo.Length > _config.GetValue<long>("TamanhoLimiteUpload"))

        //            return new TasksResult(false, "O arquivo é muito grande. Experimente algo menor que 128MB!", null);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && model.Arquivo.Length != 0)

        //            model.FileExtension = Path.GetExtension(model.Arquivo.FileName);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && !_extensoesPermitidas.Contains(model.FileExtension))

        //            return new TasksResult(false, "Extensão não permitida. Experimente postar vídeos .mp4!", null);

        //        bool exclusivo = (model.TipoConteudo == TipoConteudo.Indicadores) ? false :
        //            (model.TipoConteudo == TipoConteudo.ImagemSlide) ? false :
        //            (model.TipoConteudo == TipoConteudo.PaginaBi) ? false : true;

        //        //Conteudo do banco
        //        //Se estou ativando um conteudo único, os demais que possuem o mesmo tipo serão desativados
        //        if (exclusivo && model.IsEnabled)
        //        {
        //            var itensInativar = _conteudosRepository.ObterConteudosPorTipo(model.TipoConteudo, model.MonitorId);

        //            foreach (var item in itensInativar)
        //            {
        //                item.IsEnabled = false;
        //            }

        //            await _conteudosRepository.UpdateRangeAsync(itensInativar);
        //        }

        //        var conteudo = new Conteudos()
        //        {
        //            Id = model.Id,

        //            MonitorId = model.MonitorId,

        //            Descricao = AjustarTextos.TextoPadrao(model.Descricao),

        //            Caminho = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Id.ToString() + model.FileExtension :
        //                model.Caminho,

        //            FilePath = (model.TipoConteudo == TipoConteudo.VideoLocal) ? _config.GetValue<string>("LocalArmazenamentoVideos") :
        //                null,

        //            TempoExibicao = model.TempoExibicao,

        //            TipoConteudo = model.TipoConteudo,

        //            IsEnabled = model.IsEnabled,

        //            AutoPlay = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.AutoPlay : false,

        //            Mudo = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Mudo : false,

        //            Looping = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Looping : false
        //        };

        //        if (_conteudosRepository.SeConteudoExiste(conteudo))

        //            return new TasksResult(false, "O conteúdo postado já existe na base de dados!", null);

        //        //Deletar arquivos com mesmo nome
        //        if (model.TipoConteudo == TipoConteudo.VideoLocal)

        //            File.Delete(Path.Combine(conteudo.FilePath, conteudo.Caminho.ToString()));

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && (model.Arquivo != null || model.Arquivo.Length != 0))
        //        {
        //            //O nome do arquivo é o caminho gravado no banco de dados
        //            var fullPath = Path.Combine(conteudo.FilePath, conteudo.Caminho);

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                model.Arquivo.CopyTo(stream);

        //            }
        //        }

        //        await _conteudosRepository.AddAsync(conteudo);

        //        return new TasksResult(true, "Conteúdo adicionado com sucesso!", null);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new TasksResult(false, "Ocorreu um erro em sua solicitação. Detalhes:" + ex.Message, null);
        //    }
        //}

        //public async Task<TasksResult> AlterarConteudo(ConteudosGravar model)
        //{
        //    try
        //    {
        //        //if (model.TipoConteudo == TipoConteudo.VideoLocal && (model.Arquivo == null || model.Arquivo.Length == 0))

        //        //    return new TasksResult(false, "É necessário anexar o arquivo!", null);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal
        //            && (model.Arquivo != null && model.Arquivo.Length > _config.GetValue<long>("TamanhoLimiteUpload")))

        //            return new TasksResult(false, "O arquivo é muito grande. Experimente algo menor que 128MB!", null);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && model.Arquivo != null)

        //            model.FileExtension = Path.GetExtension(model.Arquivo.FileName);

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && (model.Arquivo != null && !_extensoesPermitidas.Contains(model.FileExtension)))

        //            return new TasksResult(false, "Extensão não permitida. Experimente postar vídeos .mp4!", null);

        //        model.Caminho = (model.TipoConteudo == TipoConteudo.VideoLocal && model.Arquivo != null) ? model.Id.ToString() + model.FileExtension :
        //            model.Caminho;

        //        model.FilePath = _config.GetValue<string>("LocalArmazenamentoVideos");

        //        bool exclusivo = (model.TipoConteudo == TipoConteudo.Indicadores) ? false :
        //            (model.TipoConteudo == TipoConteudo.ImagemSlide) ? false :
        //            (model.TipoConteudo == TipoConteudo.PaginaBi) ? false : true;

        //        var conteudosAlterar = new List<Conteudos>();

        //        //Conteudo do banco
        //        //Se estou ativando um conteudo único, os demais que possuem o mesmo tipo serão desativados
        //        if (exclusivo && model.IsEnabled)
        //        {
        //            var conteudos = _conteudosRepository.ObterConteudosPorTipo(model.TipoConteudo, model.MonitorId);

        //            foreach (var item in conteudos)
        //            {
        //                item.Id = item.Id;

        //                item.MonitorId = item.MonitorId;

        //                item.TipoConteudo = item.TipoConteudo;

        //                item.FilePath = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.FilePath :
        //                    item.FilePath;

        //                item.Descricao = (item.Id == model.Id) ? AjustarTextos.TextoPadrao(model.Descricao) : item.Descricao;

        //                //item.Caminho = item.Caminho;

        //                item.TempoExibicao = (item.Id == model.Id) ? model.TempoExibicao : item.TempoExibicao;

        //                item.IsEnabled = (item.Id == model.Id) ? model.IsEnabled : false;

        //                item.AutoPlay = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.AutoPlay : false;

        //                item.Mudo = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Mudo : false;

        //                item.Looping = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Looping : false;

        //                conteudosAlterar.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            var itemAlterar = _conteudosRepository.GetById(model.Id);

        //            itemAlterar.TempoExibicao = model.TempoExibicao;

        //            itemAlterar.Descricao = AjustarTextos.TextoPadrao(model.Descricao);

        //            itemAlterar.IsEnabled = model.IsEnabled;

        //            itemAlterar.Caminho = model.Caminho;

        //            itemAlterar.FilePath = (model.TipoConteudo == TipoConteudo.VideoLocal) ? _config.GetValue<string>("LocalArmazenamentoVideos") :
        //                    itemAlterar.FilePath;

        //            itemAlterar.AutoPlay = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.AutoPlay : false;

        //            itemAlterar.Mudo = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Mudo : false;

        //            itemAlterar.Looping = (model.TipoConteudo == TipoConteudo.VideoLocal) ? model.Looping : false;

        //            conteudosAlterar.Add(itemAlterar);
        //        }

        //        //Deletar arquivos com mesmo nome
        //        //if (model.TipoConteudo == TipoConteudo.VideoLocal)

        //        //    File.Delete(Path.Combine(model.FilePath, model.Caminho.ToString()));

        //        if (model.TipoConteudo == TipoConteudo.VideoLocal && (model.Arquivo != null))
        //        {
        //            //Deletar arquivos com mesmo nome somente se estiver postando um novo arquivo
        //            File.Delete(Path.Combine(model.FilePath, model.Caminho.ToString()));

        //            //O nome do arquivo é o caminho gravado no banco de dados
        //            var fullPath = Path.Combine(model.FilePath, model.Caminho);

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                model.Arquivo.CopyTo(stream);
        //            }
        //        }

        //        await _conteudosRepository.UpdateRangeAsync(conteudosAlterar);

        //        return new TasksResult(true, "Conteúdo(s) alterado(s) com sucesso!", null);
        //    }
        //    catch (Exception ex)
        //    {

        //        return new TasksResult(false, "Ocorreu um erro em sua solicitação. Detalhes:" + ex.Message, null);
        //    }
        //}

        public string PoliticaQualidade(string codEmpresa)
        {
            //Obter o arquivo html padrão da mensagem
            var pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "html", codEmpresa + "_politica_qualidade.html");

            //Construtor de texto
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(pathToFile))
            {
                sb.Append(sr.ReadToEnd());

                sr.Close();
            }

            return sb.ToString();
        }

        public Task<PaineisResponse> ExcluirAsync(PaineisRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaineisResponse> AdicionarAsync(PaineisRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
