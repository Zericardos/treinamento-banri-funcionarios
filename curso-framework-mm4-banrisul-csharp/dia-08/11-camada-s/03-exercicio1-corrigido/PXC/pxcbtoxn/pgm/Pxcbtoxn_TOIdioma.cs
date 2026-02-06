using Bergs.Pwx.Pwxodaxn;
using Bergs.Pwx.Pwxoiexn;
using Bergs.Pwx.Pwxoiexn.Validacoes;
using System;
using System.Data;
using System.Xml.Serialization;

namespace Bergs.Pxc.Pxcbtoxn
{
    /// <summary>
    /// Representa um registro da tabela IDIOMA da base de dados PXC
    /// </summary>
    public class TOIdioma: TOTabela
    {
        /// <summary>
        /// Constante com o nome da tabela IDIOMA
        /// </summary>
        public const string TABELA = "PXC.IDIOMA";

        /// <summary>
        /// Constante com o nome do campo COD_IDIOMA na tabela IDIOMA
        /// </summary>
        public const string CODIGO_IDIOMA = "COD_IDIOMA";
        /// <summary>
        /// Constante com o nome para a propriedade de código ISO de idioma (Não existe na tabela — apenas para uso em impressões)
        /// </summary>
        public const string CODIGO_ISO_COMBINADO_IDIOMA = "COD_ISO_IDIOMA";
        /// <summary>
        /// Constante com o nome do campo DESC_IDIOMA na tabela IDIOMA
        /// </summary>
        public const string DESCRICAO_IDIOMA = "DESC_IDIOMA";
        /// <summary>
        /// Constante com o nome do campo COD_USUARIO na tabela IDIOMA
        /// </summary>
        public const string CODIGO_USUARIO = "COD_USUARIO";
        /// <summary>
        /// Constante com o nome do campo DTHR_ULT_ATU na tabela IDIOMA
        /// </summary>
        public const string DATA_HORA_ULTIMA_ALTERACAO = "DTHR_ULT_ATU";

        /// <summary>
        /// Campo COD_IDIOMA da tabela IDIOMA
        /// </summary>
        [XmlAttribute("cod_idioma")]
        [CampoTabela(CODIGO_IDIOMA, Chave = true, Obrigatorio = true, TipoParametro = DbType.Int32, Tamanho = 8, Precisao = 8)]
        [NaoNulo(mensagemErro: "Código numérico deve ser informado.")]
        public CampoObrigatorio<int> CodIdioma { get; set; }

        /// <summary>
        /// Campo calculado código ISO combinado de idioma
        /// </summary>
        [XmlAttribute("cod_iso_idioma")]
        [NaoBranco(mensagemErro: "Código ISO combinado deve ser informado.")]
        public CampoObrigatorio<string> CodigoIsoCombinado { get; set; }

        /// <summary>
        /// Campo DESC_IDIOMA da tabela IDIOMA
        /// </summary>
        [XmlAttribute("desc_idioma")]
        [CampoTabela(DESCRICAO_IDIOMA, Obrigatorio = true, TipoParametro = DbType.String, Tamanho = 50, Precisao = 50)]
        [Alfanumerico(mensagemErro: "Descrição inválida. A descrição deve ser composta de letras, números e acentuação.")]
        public CampoObrigatorio<string> DescIdioma { get; set; }

        /// <summary>
        /// Campo COD_USUARIO da tabela IDIOMA
        /// </summary>
        [XmlAttribute("cod_usuario")]
        [CampoTabela(CODIGO_USUARIO, TipoParametro = DbType.String, Tamanho = 6, Precisao = 6)]
        public CampoOpcional<string> CodUsuario { get; set; }

        /// <summary>
        /// Campo DTHR_ULT_ATU da tabela IDIOMA
        /// </summary>
        [XmlAttribute("dthr_ult_atu")]
        [CampoTabela(DATA_HORA_ULTIMA_ALTERACAO, TipoParametro = DbType.DateTime, Tamanho = 10, Precisao = 10, Escala = 6)]
        public CampoOpcional<DateTime> DthrUltAtu { get; set; }

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
                    case CODIGO_IDIOMA:
                        {
                            CodIdioma = Convert.ToInt32(campo.Conteudo);

                            CodigoIsoCombinado = Feconid.CodigoToIso(CodIdioma);

                            break;
                        }
                    case DESCRICAO_IDIOMA:
                        {
                            DescIdioma = Convert.ToString(campo.Conteudo).Trim();

                            break;
                        }
                    case CODIGO_USUARIO:
                        {
                            CodUsuario = LerCampoOpcional<string>(campo);

                            break;
                        }
                    case DATA_HORA_ULTIMA_ALTERACAO:
                        {
                            DthrUltAtu = LerCampoOpcional<DateTime>(campo);

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
