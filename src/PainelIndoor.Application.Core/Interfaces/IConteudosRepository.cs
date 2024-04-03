using PainelIndoor.Application.Core.Enums;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Entities;
using System;
using System.Collections.Generic;

namespace PainelIndoor.Application.Interfaces
{
    public interface IConteudosRepository : IAsyncRepositoryBase<Conteudos>
    {
        IEnumerable<Conteudos> ObterConteudosPorTipo(TipoConteudo tipoConteudo, Guid monitorId);
    }
}
