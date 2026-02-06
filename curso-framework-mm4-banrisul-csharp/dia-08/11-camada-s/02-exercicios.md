# Exercícios de Camada S

## 1. Camada S de categorias de produtos bancários

Neste exercício vamos agora gerar a camada S de categorias, também considerando que precisamos gerar os métodos equivalentes às nossas necessidades expostas nas user stories criadas nos exercícios anteriores. Agora considerando-as em suas formas completas, já observando as regras e critérios de aceitação.

Relembrando as stories de categoria:

```gherkin
US1 - Inclusão de nova categoria

Como um analista de marketing
Eu quero incluir uma nova categoria informando seu código numérico e sua descrição
Para que o banco possa manter um cadastro oficial e padronizado de categorias utilizadas por diversas áreas

Regras
    - O código numérico é obrigatório
    - O código numérico é de livre escolha
    - O código numérico deve ser único na base
    - A descrição é obrigatória
    - A descrição deve conter apenas letras, números e acentuação
    - A inclusão deve registrar informações de auditoria: usuário responsável e data/hora atuais*

Critérios de Aceitação
    - Dado que informo um código numérico ainda não utilizado e uma descrição válida, então a aplicação inclui a categoria com sucesso
    - Dado que o código numérico não é informado ou já existe na base, então a aplicação rejeita a inclusão
    - Dado que a descrição não é informada ou é inválida, então a aplicação rejeita a inclusão
```

> Atenção: Durante os exercícios no tópico de TOs, percebemos que uma necessidade de negócio havia mudado: **Tornou-se necessário e obrigatório informar usuário e data/hora da última alteração já durante a fase de inclusão de uma categoria**. A user story acima já está atualizada para contemplar essa necessidade através da **regra demarcada com um asterisco (\*)**.

```gherkin
US2 - Remoção de categoria

Como um analista comercial
Eu quero remover uma categoria previamente cadastrada
Para evitar que equipes selecionem categorias obsoletas no cadastro de novos produtos

Regras
    - A remoção deve eliminar a categoria fisicamente da base
    - A remoção deve se dar pela seleção por código numérico

Critérios de Aceitação
    - Dado que informo o código numérico de uma categoria existente, então a aplicação remove a categoria com sucesso
    - Dado que o código numérico informado não existe na base, então a aplicação rejeita a remoção e informa que a categoria não foi encontrada
```

```gherkin
US3 - Alteração de dados de categoria

Como um gerente de marketing
Eu quero alterar a descrição de uma categoria já cadastrada
Para corrigir informações incompletas ou ajustá-la às estratégias atuais de marketing

Regras
    - Apenas a descrição pode ser alterada
    - O código numérico não pode ser modificado
    - A nova descrição é obrigatória
    - A nova descrição deve conter apenas letras, números e acentuação
    - A alteração deve registrar informações de auditoria: usuário responsável e data/hora atuais

Critérios de Aceitação
    - Dado que informo uma nova descrição válida, então a aplicação altera a categoria e registra as informações de auditoria com sucesso
    - Dado que o código numérico informado não existe na base, então a aplicação rejeita a alteração e informa que a categoria não foi encontrada
    - Dado que a nova descrição não é informada ou é inválida, então a aplicação rejeita a alteração e informa que a descrição é inválida
```

```gherkin
US4 - Listagem de categorias

Como um gerente de marketing
Eu quero visualizar a lista de todas as categorias cadastradas
Para apoiar a criação de campanhas, análises de portfólio e decisões estratégicas

Regras
    - A listagem deve retornar todas as categorias cadastradas
    - A listagem deve exibir: código numérico, descrição e informações de auditoria (última alteração)

Critérios de Aceitação
    - Ao solicitar a listagem, a aplicação retorna todas as categorias existentes com suas informações
    - Se não houver categorias cadastradas, então a aplicação rejeita a consulta e informa que a lista está vazia
```

```gherkin
US5 - Consulta de categoria por código ou descrição

Como um gerente de produtos digitais
Eu quero consultar uma categoria pelo seu código numérico ou pela descrição
Para validar rapidamente informações em reuniões e decisões com áreas internas e parceiros

Regras
    - A consulta pode ser realizada pelo código numérico ou pela descrição exata
    - A consulta deve retornar exatamente 1 categoria caso cadastrada
    - A consulta deve retornar: código numérico, descrição e informações de auditoria (última alteração)
    - Caso não exista categoria correspondente, a aplicação deve informar inexistência

Critérios de Aceitação
    - Dado que informo um código numérico válido de uma categoria existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo uma descrição exata de uma categoria existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código numérico inexistente, então a aplicação rejeita a consulta e informa que a categoria não foi encontrada
    - Dado que informo uma descrição inexistente, então a aplicação rejeita a consulta e informa que a categoria não foi encontrada
```

> Notas:
>
> - Inclua também os métodos **Contar(...)** e **Imprimir(...)** por conveniência;
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

Gere a camada S e faça todos os passos para incorporá-la à solução `pxckcfxn.sln` na raíz de _PXC_ da `Desenvhome`.

Refine o seu código e faça as implementações de negócio da mesma forma como feito no laboratório.

> Dicas:
>
> - Não é mais necessária a geração de soluções através do **Gerador de Solution**. Agora a incorporação desse projeto é manual dentro da solução. Um detalhe importante é que o **Gerador de Classes MM4** gera a camada S **já com referências adicionadas à respectiva camada Q e ao projeto de TOs**, então ao incorporar o projeto de camada S à solução, tudo deve estar prontamente compilável.
> - Para adicionar um projeto já existente a uma solução no _Visual Studio_, clique com o botão direito em cima da solution e selecione a opção **Add (Adicionar) ⟹ Existing Project (Projeto Existente)**. Na janela de diálogo você deverá selecionar o arquivo de projeto (`.csproj`) do projeto que você quer incorporar à solução.

&nbsp; <!-- Manter para que haja a separação entre os dois blocos -->
> Nota: As referências "prontas" que o gerador adiciona na camada S apontam para os binários já compilados dentro do espaço de provisionamento em ambiente local (`Soft`), ou seja: `C:\Soft\PXC\bin\`. Caso a aplicação apresente comportamento inconsistente ou algum tipo de problema de compilação. Basta remover essa referência automática e readicioná-la através da forma tradicional de referência entre projetos. Se necessário, revise no laboratório de arquitetura 3 camadas a forma como fazer referências entre projetos.
