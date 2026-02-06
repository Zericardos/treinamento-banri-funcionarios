# Exercícios de TOs

## 1. TO de categorias de produtos bancários

Neste exercício vamos agora também gerar o TO de categorias, também conforme as user stories criadas nos exercícios anteriores.

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

Aqui a modelagem também já foi feita e a base está pronta no **IBM DB2**:

```sql
SELECT
    COD_CATEGORIA     -- INTEGER   NN PK
  , DESCRICAO         -- CHAR(35)  NN
  , COD_OPERADOR      -- CHAR(6)   NN
  , ULT_ATUALIZACAO   -- TIMESTAMP NN
FROM PXC.CATEGORIA;
```

Gere o TO e faça todos os passos para incorporá-lo ao projeto de TOs e deixá-lo pronto para uso.

> Atenção: Perceba um detalhe importante: Usuário e data/hora da última alteração se tornaram **campos obrigatórios (NN - Not Null)** na base de dados. Isso significa que eles já não devem mais ser só preenchidos nas alterações, e sim logo que a categoria é incluída. Sim, necessidades de negócio mudam o tempo todo e impactam diretamente os requisitos, e aqui temos um exemplo claro de algo que mudou e vamos precisar nos adaptar. Construa o TO conforme o código que vai ser gerado, pois o gerador de classes gera os TOs com propriedades obrigatórias (NN) ou opcionais envolvendo-as com o seu wrapper equivalente (`CampoObrigatorio<T>` ou `CampoOpcional<T>`).
> Nos próximos tópicos quando utilizarmos as user stories detalhadas e os casos de teste de categorias, vamos atualizá-los para comportar essa mudança nas expectativas do negócio.
