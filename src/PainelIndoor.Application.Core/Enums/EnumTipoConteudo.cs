namespace PainelIndoor.Application.Core.Enums
{
    public class EnumTipoConteudo
    {
        public static string Descricao(TipoConteudo tipo)
        {
            switch (tipo)
            {
                case TipoConteudo.VideoLocal:
                    return "VÍDEO LOCAL";
                case TipoConteudo.VideoYouTube:
                    return "VÍDEO YOUTUBE (INCORPORADO)";
                case TipoConteudo.PaginaHtml:
                    return "PÁGINA WEB";
                case TipoConteudo.Indicadores:
                    return "INDICADORES";
                case TipoConteudo.ImagemFixa:
                    return "IMAGEM FIXA";
                case TipoConteudo.ImagemSlide:
                    return "SLIDE DE IMAGENS";
                case TipoConteudo.PaginaBi:
                    return "POWER BI";
                case TipoConteudo.Outros:
                    return "OUTROS";
                default:
                    return "NÃO DEFINIDO";
            }
        }
    }

    public enum TipoConteudo
    {
        VideoLocal = 1,
        VideoYouTube = 2,
        PaginaHtml = 3,
        Indicadores = 4,
        ImagemFixa = 5,
        ImagemSlide = 6,
        PaginaBi = 7,
        Outros = 8
    }
}
