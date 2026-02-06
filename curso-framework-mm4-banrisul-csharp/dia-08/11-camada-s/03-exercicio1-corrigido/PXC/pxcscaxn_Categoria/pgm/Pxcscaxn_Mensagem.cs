using System;
using System.Linq;

namespace Bergs.Pxc.Pxcscaxn
{
    /// <summary>
    /// Mensagens previstas para o componente
    /// </summary>
    public enum TipoCategoriaMensagem
    {
        /// <summary>
        /// Mensagem de aviso de necessidade de existência do código da categoria
        /// </summary>
        FalhaRnValidarExistenciaCod,
        /// <summary>
        /// Mensagem de aviso de necessidade de existência da descrição
        /// </summary>
        FalhaRnValidarExistenciaDescricao,
        /// <summary>
        /// Mensagem de aviso de falha ao consultar uma categoria existente na base de dados
        /// </summary>
        FalhaRnConsultarCategoriaBaseDados,
        /// <summary>
        /// Mensagem de aviso de falha para inclusão de categoria devido à já existência de um outra categoria com o mesmo código na base de dados
        /// </summary>
        FalhaRnIncluirCategoriaJaExistente,
        /// <summary>
        /// Mensagem de aviso de necessidade de existência de ao menos uma das opções de categoria: código ou descrição
        /// </summary>
        FalhaRnValidarExistenciaCodOuDescricao,
        /// <summary>
        /// Mensagem genérica de falha indeterminada
        /// </summary>
        FalhaIndeterminada
    }

    /// <summary>
    /// Classe de mapa de mensagens de categorias
    /// </summary>
    public class CategoriaMensagem: Pwx.Pwxoiexn.Mensagens.Mensagem
    {
        private const string MOTIVO_INDETERMINADO = "Motivo indeterminado.";
        private const string SUFIXO_GENERICO_INDETERMINANCIA = "indeterminado(a)";

        private readonly TipoCategoriaMensagem _tipoMensagem;
        private readonly string _mensagem;

        /// <summary>
        /// Mensagem para o usuário
        /// </summary>
        public override string ParaUsuario
        {
            get { return ParaOperador; }
        }

        /// <summary>
        /// Mensagem para o operador (logs e auditorias internas)
        /// </summary>
        public override string ParaOperador
        {
            get { return _mensagem; }
        }

        /// <summary>
        /// Identificador do tipo de mensagem
        /// </summary>
        public override string Identificador
        {
            get { return _tipoMensagem.ToString(); }
        }

        /// <summary>
        /// Construtor de uma nova mensagem de categoria
        /// </summary>
        /// <param name="tipoMensagem">Identificador do tipo de mensagem</param>
        /// <param name="argumentos">Argumentos extras a serem interpolados na mensagem</param>
        public CategoriaMensagem(TipoCategoriaMensagem tipoMensagem, params string[] argumentos)
        {
            _tipoMensagem = tipoMensagem;

            _mensagem = MapearMensagem(argumentos);
        }

        /// <summary>
        /// Construtor de uma mensagem de categoria a partir de outra mensagem já existente
        /// </summary>
        /// <param name="categoriaMensagem">Objeto de mensagem de categoria</param>
        public CategoriaMensagem(CategoriaMensagem categoriaMensagem)
        {
            _tipoMensagem = (TipoCategoriaMensagem)Enum.Parse(typeof(TipoCategoriaMensagem), categoriaMensagem.Identificador);

            _mensagem = categoriaMensagem.ParaUsuario;
        }

        private string MapearMensagem(params string[] argumentos)
        {
            switch (_tipoMensagem)
            {
                case TipoCategoriaMensagem.FalhaRnValidarExistenciaCod:
                    return "O código da categoria deve ser informado.";
                case TipoCategoriaMensagem.FalhaRnValidarExistenciaDescricao:
                    return "A descrição da categoria deve ser informada.";
                case TipoCategoriaMensagem.FalhaRnConsultarCategoriaBaseDados:
                    return $"A consulta da categoria na base de dados falhou: {argumentos.ElementAtOrDefault(0) ?? MOTIVO_INDETERMINADO}";
                case TipoCategoriaMensagem.FalhaRnIncluirCategoriaJaExistente:
                    return "Já existe na base de dados uma categoria com código equivalente ao código informado.";
                case TipoCategoriaMensagem.FalhaRnValidarExistenciaCodOuDescricao:
                    return "Ao menos uma das opções de categoria deve ser informada: código ou descrição.";
                case TipoCategoriaMensagem.FalhaIndeterminada:
                default:
                    return $"Houve uma falha {SUFIXO_GENERICO_INDETERMINANCIA} durante a execução das validações de categoria.";
            }
        }
    }
}
