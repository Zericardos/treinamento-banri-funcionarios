# Exercícios de Camada Q

## 1. Camada Q de categorias de produtos bancários

Neste exercício vamos agora também gerar a camada Q de categorias, também considerando que precisamos gerar os métodos equivalentes às nossas necessidades expostas nas user stories criadas nos exercícios anteriores.

Relembrando as stories (de forma resumida) de categoria:

```gherkin
US1 - Inclusão de nova categoria

Como um analista de marketing
Eu quero incluir uma nova categoria informando seu código numérico e sua descrição
Para que o banco possa manter um cadastro oficial e padronizado de categorias utilizadas por diversas áreas
```

```gherkin
US2 - Remoção de categoria

Como um analista comercial
Eu quero remover uma categoria previamente cadastrada
Para evitar que equipes selecionem categorias obsoletas no cadastro de novos produtos
```

```gherkin
US3 - Alteração de dados de categoria

Como um gerente de marketing
Eu quero alterar a descrição de uma categoria já cadastrada
Para corrigir informações incompletas ou ajustá-la às estratégias atuais de marketing
```

```gherkin
US4 - Listagem de categorias

Como um gerente de marketing
Eu quero visualizar a lista de todas as categorias cadastradas
Para apoiar a criação de campanhas, análises de portfólio e decisões estratégicas
```

```gherkin
US5 - Consulta de categoria por código ou descrição

Como um gerente de produtos digitais
Eu quero consultar uma categoria pelo seu código numérico ou pela descrição
Para validar rapidamente informações em reuniões e decisões com áreas internas e parceiros
```

> Notas:
>
> - Inclua também o método **Contar(...)** por conveniência;
> - Siga as demais configurações da mesma forma como foi feito no laboratório;
> - O _identificador curto para o TO_ de categorias é "ca".

Relembrando a modelagem já pronta no **IBM DB2**:

```sql
SELECT
    COD_CATEGORIA     -- INTEGER   NN PK
  , DESCRICAO         -- CHAR(35)  NN
  , COD_OPERADOR      -- CHAR(6)   NN
  , ULT_ATUALIZACAO   -- TIMESTAMP NN
FROM PXC.CATEGORIA;
```

> Atenção: Vamos relembrar que no exercício de criação do TO de categorias chegamos a mencionar que um requisito havia mudado, pois principalmente o campo `ULT_ATUALIZACAO` era obrigatório mesmo em inserções. Dado que agora aprendemos a técnica de [**SAC**](../../dicionario-banrisul.md#sac---sincronização-de-acessos-concorrentes), você percebe o requisito não-funcional implícito aqui?

Relembrando uma possível definição do TO de categorias:

```csharp
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
```

Gere a camada Q e faça todos os passos para incorporá-la à solução `pxckcfxn.sln` na raíz de _PXC_ da `Desenvhome`.

Refine o seu código da mesma forma como feito no laboratório.

> Dicas:
>
> - Não é mais necessária a geração de soluções através do **Gerador de Solution**. Agora a incorporação desse projeto é manual dentro da solução. Um detalhe importante é que o **Gerador de Classes MM4** gera a camada Q **já com referências adicionadas ao projeto de TOs**, então ao incorporar o projeto de camada Q à solução, tudo deve estar prontamente compilável.
> - Para adicionar um projeto já existente a uma solução no _Visual Studio_, clique com o botão direito em cima da solution e selecione a opção **Add (Adicionar) ⟹ Existing Project (Projeto Existente)**. Na janela de diálogo você deverá selecionar o arquivo de projeto (`.csproj`) do projeto que você quer incorporar à solução.

&nbsp; <!-- Manter para que haja a separação entre os dois blocos -->
> Nota: As referências "prontas" que o gerador adiciona na camada Q apontam para os binários já compilados dentro do espaço de provisionamento em ambiente local (`Soft`), ou seja: `C:\Soft\PXC\bin\`. Caso a aplicação apresente comportamento inconsistente ou algum tipo de problema de compilação. Basta remover essa referência automática e readicioná-la através da forma tradicional de referência entre projetos. Se necessário, revise no laboratório de arquitetura 3 camadas a forma como fazer referências entre projetos.
