using Bergs.Pwx.Pwxodaxn;
using Bergs.Pwx.Pwxoiexn;
using System;
using System.Data;
using System.Xml.Serialization;

namespace Bergs.Pxc.Pxcbtoxn
{
    /// <summary>
    /// Representa um registro da tabela CATEGORIA da base de dados PXC
    /// </summary>
    public class TOCategoria: TOTabela
    {
        /// <summary>
        /// Constante com o nome da tabela CATEGORIA
        /// </summary>
        public const string TABELA = "PXC.CATEGORIA";

        /// <summary>
        /// Constante com o nome do campo COD_CATEGORIA na tabela CATEGORIA
        /// </summary>
        public const string CODIGO_CATEGORIA = "COD_CATEGORIA";
        /// <summary>
        /// Constante com o nome do campo DESCRICAO na tabela CATEGORIA
        /// </summary>
        public const string DESCRICAO_CATEGORIA = "DESCRICAO";
        /// <summary>
        /// Constante com o nome do campo COD_OPERADOR na tabela CATEGORIA
        /// </summary>
        public const string CODIGO_USUARIO = "COD_OPERADOR";
        /// <summary>
        /// Constante com o nome do campo ULT_ATUALIZACAO na tabela CATEGORIA
        /// </summary>
        public const string DATA_HORA_ULTIMA_ALTERACAO = "ULT_ATUALIZACAO";

        /// <summary>
        /// Campo COD_CATEGORIA da tabela CATEGORIA
        /// </summary>
        [XmlAttribute("cod_categoria")]
        [CampoTabela(CODIGO_CATEGORIA, Chave = true, Obrigatorio = true, TipoParametro = DbType.Int32, Tamanho = 8, Precisao = 8)]
        public CampoObrigatorio<int> CodCategoria { get; set; }

        /// <summary>
        /// Campo DESCRICAO da tabela CATEGORIA
        /// </summary>
        [XmlAttribute("descricao")]
        [CampoTabela(DESCRICAO_CATEGORIA, Obrigatorio = true, TipoParametro = DbType.String, Tamanho = 35, Precisao = 35)]
        public CampoObrigatorio<string> Descricao { get; set; }

        /// <summary>
        /// Campo COD_OPERADOR da tabela CATEGORIA
        /// </summary>
        [XmlAttribute("cod_operador")]
        [CampoTabela(CODIGO_USUARIO, Obrigatorio = true, TipoParametro = DbType.String, Tamanho = 6, Precisao = 6)]
        public CampoObrigatorio<string> CodOperador { get; set; }

        /// <summary>
        /// Campo ULT_ATUALIZACAO da tabela CATEGORIA
        /// </summary>
        [XmlAttribute("ult_atualizacao")]
        [CampoTabela(DATA_HORA_ULTIMA_ALTERACAO, Obrigatorio = true, UltAtualizacao = true, TipoParametro = DbType.DateTime, Tamanho = 10, Precisao = 10, Escala = 6)]
        public CampoObrigatorio<DateTime> UltAtualizacao { get; set; }

        /// <summary>
        /// Popula os atributos da classe a partir de uma linha de dados
        /// </summary>
        /// <param name="linha">Registro de dados retornado pelo acesso à base de dados</param>
        public override void PopularRetorno(Linha linha)
        {
            // Percorre os campos que foram retornados pela consulta e converte seus valores para tipos do .NET
            foreach (Campo campo in linha.Campos)
            {
                switch (campo.Nome)
                {
                    case CODIGO_CATEGORIA:
                        {
                            CodCategoria = Convert.ToInt32(campo.Conteudo);

                            break;
                        }
                    case DESCRICAO_CATEGORIA:
                        {
                            Descricao = Convert.ToString(campo.Conteudo).Trim();

                            break;
                        }
                    case CODIGO_USUARIO:
                        {
                            CodOperador = Convert.ToString(campo.Conteudo).Trim();

                            break;
                        }
                    case DATA_HORA_ULTIMA_ALTERACAO:
                        {
                            UltAtualizacao = Convert.ToDateTime(campo.Conteudo);

                            break;
                        }
                    default:
                        {
                            // TODO: Tratar situação em que a coluna da tabela não tiver sido mapeada para uma propriedade do TO

                            break;
                        }
                }
            }
        }
    }
}
