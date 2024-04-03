using PainelIndoor.Application.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PainelIndoor.Application.Core.Services.Paineis.ViewModels
{
    public class PaineisRequest : BaseRequest
    {
        [Display(Name = "Empresa")]
        public string CodEmpresa { get; set; }

        [Display(Name = "Filial")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CodFilial { get; set; }

        [Display(Name = "Centro de Custo")]
        public string ChaveCentroCusto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo de Conteúdo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public TipoConteudo TipoConteudo { get; set; }

        [Display(Name = "Ativo?")]
        public bool IsEnabled { get; set; }
    }
}
