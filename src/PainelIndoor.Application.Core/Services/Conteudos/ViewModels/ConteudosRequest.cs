using PainelIndoor.Application.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PainelIndoor.Application.Core.Services.Conteudos.ViewModels
{
    public class ConteudosRequest : BaseRequest
    {
        [Display(Name = "Monitor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid MonitorId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Caminho")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Caminho { get; set; }

        public string FilePath { get; set; }

        public string FileExtension { get; set; }

        public IFormFile Arquivo { get; set; }

        [Display(Name = "Tempo de Exibição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int TempoExibicao { get; set; }

        [Display(Name = "Tipo de Conteúdo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public TipoConteudo TipoConteudo { get; set; }

        [Display(Name = "Ativo?")]
        public bool IsEnabled { get; set; }

        public bool AutoPlay { get; set; }

        public bool Mudo { get; set; }

        public bool Looping { get; set; }

        public string DesabilitaTempoExibicao { get; set; }

        public string OcultaTempoExibicao { get; set; }

        public string OcultaAtributosVideoLocal { get; set; }

        public string OcultaCaminho { get; set; }

        public string OcultaUploadFile { get; set; }
    }
}
