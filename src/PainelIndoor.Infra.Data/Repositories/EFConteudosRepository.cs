using Microsoft.EntityFrameworkCore.ChangeTracking;
using PainelIndoor.Application.Core.Enums;
using PainelIndoor.Application.Entities;
using PainelIndoor.Application.Interfaces;
using PainelIndoor.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Infra.Data.Repositories
{
    public class EFConteudosRepository : EFAsyncRepositoryBase<Conteudos>, IConteudosRepository
    {
        public EFConteudosRepository(ApplicationDbContext context) : base(context)
        {     
        }

        public IEnumerable<Conteudos> ObterConteudosPorTipo(TipoConteudo tipoConteudo, Guid monitorId)
        {
            throw new NotImplementedException();
        }
    }
}
