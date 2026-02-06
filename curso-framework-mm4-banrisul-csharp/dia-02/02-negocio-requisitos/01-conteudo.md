# Negócio e requisitos

## Negócio

Antes de existir qualquer recurso de aplicação, seja uma tela, uma página web, ou qualquer outra coisa, existe algo mais fundamental: **um problema de negócio que precisa ser resolvido**.

Toda aplicação — desde uma lista de tarefas ou uma agenda de contatos, até um complexo ecossistema bancário — é concebida a partir de funcionalidades para resolver problemas reais de negócios, identificados por profissionais atentos e preparados, que **compreendendo as necessidades e dores do negócio**, aplicam **engenharia de requisitos**.

### A importância de entender o problema

Mesmo profissionais experientes podem cair na armadilha de começar "codando" sem clareza do problema. Isso quase sempre causa:

- Implementações que não atendem as expectativas;
- Detalhes importantes ignorados ou não notados;
- Funcionalidades que resolvem sintomas, mas não as causas;
- Aumento de **retrabalho** e desperdício de tempo.

Para evitar isso, precisamos sempre priorizar os **por ques** e os **o ques**, a partir do questionamento: _Quais são as dores, as necessidades, as regras e a motivação por trás de uma demanda?_

Ou seja: Se os requisitos explicam **por que** a aplicação existe e **o que** ela precisa fazer, e a base de código expressa o **como** a aplicação funciona, isso significa que o **como** sempre deve ser decidido depois dos demais.

Misturar esses dois momentos do ciclo é uma das principais causas de construção de aplicações de baixa assertividade, baixa qualidade e baixa adoção de usuários.

## Requisitos

Requisitos são aspectos de comportamento que definem o que aplicações devem (ou não) fazer, definidos a partir de uma profunda compreensão sobre as **necessidades e dores do negócio**.

Existe uma disciplina que trata das atividades de elicitação e especificação de requisitos — a engenharia de requisitos. Através dessa disciplina são formados analistas de negócio, analistas de sistemas e [PO](../../dicionario-banrisul.md#po---product-owner)s. Nosso foco não é aprofundar nessa área, mas sim entender algumas práticas que servirão como insumo para o desenvolvimento das aplicações no dia a dia.

**Entender o negócio e os problemas que ele possui é uma habilidade que torna um profissional extremamente valioso**, pois o credencia a atuar também em cima da elicitação, especificação e refinamento dos requisitos do seu contexto de atuação.

### User Story

Existem muitas técnicas de elicitação e especificação de requisitos, porém, em ambientes ágeis, a técnica mais comum para especificação — e a mais prática para quem desenvolve — é a de **[US - User Story](../../dicionario-banrisul.md#us---user-story)**. User stories são curtas, focadas no usuário e funcionam como **acordos de compreensão de necessidades** firmados entre times de negócio, desenvolvimento e qualidade.

> Nota: O modelo de user story apresentado aqui será o nosso padrão ao longo de toda a jornada. Porém, é importante lembrar que **cada empresa adapta a técnica conforme sua cultura — isso se aplica inclusive ao próprio Banrisul**, então variações são completamente normais dependendo do contexto.

User stories são construídas através da representação de um papel, uma intenção e um benefício/valor agregado. Adicionalmente, também vamos agregar um identificador único e uma breve descrição para melhorar compreensão e organização:

```gherkin
US1 - Redefinição de senha <Identificador - Descrição>

Como um usuário cadastrado na aplicação <Papel>
Eu quero redefinir a minha senha <Intenção>
Para que eu possa voltar a utilizar a aplicação <Benefício/Valor agregado>
```

Podem ser agregados às user stories conjuntos de **regras** e **critérios de aceitação**, cujo objetivo é enriquecer o contexto da story e fornecer informações mais objetivas para sua **compreensão e testabilidade**.

As regras definem as **condições obrigatórias** do negócio para a dada story:

```gherkin
Regras
    - Deve ser enviado um e-mail válido já cadastrado na aplicação
    - O link de redefinição expira após 30 minutos
    - O usuário deve definir uma senha que atenda aos requisitos definidos na US2 - Criação de senha
    - A redefinição só pode ser solicitada 1 vez por dia
```

Já os critérios de aceitação descrevem **como saber, de forma objetiva, que a story está pronta**

```gherkin
Critérios de Aceitação
    - Ao informar um e-mail cadastrado, a aplicação exibe mensagem de sucesso e envia o link
    - Ao usar um link expirado, a aplicação informa que o processo deve ser refeito
    - A nova senha só é aceita se atender aos requisitos de complexidade definidos na US2 - Criação de senha
    - Após a redefinição, o usuário consegue acessar normalmente a aplicação com a nova senha
```

> Nota: A US2 — Criação de senha foi omitida por brevidade, para mantermos o foco no necessário.

## Laboratório

Vamos exercitar a criação de algumas user stories com base em depoimentos coletados de representantes do negócio que estão interessados em uma determinada funcionalidade (comumente chamados stakeholders). Será uma atividade que acontecerá somente nesse momento. A partir dos próximos dias (inclusive nas avaliações), vamos partir sempre de uma base de user stories já prontas.

Lembrando, a anatomia de uma user story segue o seguinte padrão:

```gherkin
<Identificador - Descrição>

<Papel>
<Intenção>
<Benefício/Valor agregado>

Regras
    - <Regra 1>
    - <...>

Critérios de Aceitação
    - <Critério 1>
    - <...>
```

### Depoimentos de stakeholders de um ecossistema bancário

- **Analista de operações globais:** "Nos últimos anos, o banco tem lidado com um volume crescente de transações internacionais. Precisamos registrar os idiomas suportados pelas nossas operações, porque essas informações são usadas por diversas áreas para integração e padronização.";
- **Analista de operações globais:** "Quando um idioma deixa de ser necessário, precisamos removê-lo da aplicação para evitar que seja selecionado erroneamente por outras equipes nas transações. Isso reduz erros operacionais.";
- **Analista de operações globais:** "Há casos onde acabamos precisando alterar a descrição do idioma, seja por um cadastro com descrição incorreta, ou mesmo por alguma melhoria a ser feita na descrição do idioma. Quando isso acontece, é fundamental registrar quem realizou a alteração e quando ela foi feita, para mantermos rastreabilidade.";
- **Especialista em regulações globais:** "Cada idioma possui um código numérico que é calculado com base nos códigos regulados pela **ISO 639-1** de idiomas e pela **ISO 3166-1** de países. É essencial que esse código esteja correto, pois qualquer divergência pode gerar problemas de conformidade. A conversão é feita utilizando a nossa ferramenta interna de conversão do banco chamada **FECONID - Ferramenta de conversão de idiomas**, que transforma um código textual ISO combinado, como _pt-BR_ ou _en-US_, em um código numérico único e reversível.";
- **Gerente de produtos digitais:** "Às vezes precisamos consultar rapidamente um idioma específico pelo seu código numérico ou pelo código textual ISO combinado, especialmente quando estamos validando operações com parceiros estrangeiros.";
- **Gerente de expansão global:** "Antes de iniciarmos negociações com instituições de outros países, eu costumo verificar a lista completa de idiomas cadastrados, para confirmar se já possuímos suporte linguístico para determinadas regiões.".

> Nota: O esquema de conversão de idiomas e a própria **FECONID** são fictícios, ou seja, servirão exclusivamente para o treinamento.

### User stories

<!-- ATENÇÃO: Essas user stories são replicadas várias vezes ao longo dos próximos dias e tópicos. Caso modifique algo aqui, certifique-se de efetuar o devido ajuste em todas as réplicas. -->

```gherkin
US1 - Inclusão de novo idioma

Como um analista de operações globais
Eu quero incluir um novo idioma informando seu código textual ISO combinado e sua descrição
Para que o banco possa registrar oficialmente os idiomas suportados nas operações internacionais

Regras
    - O código textual ISO combinado é obrigatório
    - O código textual ISO combinado deve seguir o padrão: ISO 639-1 + "-" + ISO 3166-1 (2 letras para idioma e 2 letras para país)
    - O código textual informado deve ser convertido para um código numérico único e reversível usando a ferramenta FECONID
    - O código numérico resultante deve ser único na base
    - A descrição é obrigatória
    - A descrição deve conter apenas letras, números e acentuação

Critérios de Aceitação
    - Dado que informo um código textual ISO combinado válido e que resulta em um código numérico ainda não utilizado, e uma descrição válida, então a aplicação inclui o idioma com sucesso
    - Dado que informo um código textual ISO combinado inválido ou que resulta em um código numérico que já existe na base, então a aplicação rejeita a inclusão
    - Dado que a descrição não é informada ou é inválida, então a aplicação rejeita a inclusão
```

```gherkin
US2 - Remoção de idioma

Como um analista de operações globais
Eu quero remover um idioma previamente cadastrado
Para evitar que equipes selecionem idiomas obsoletos e reduzir erros operacionais

Regras
    - A remoção deve eliminar o idioma fisicamente da base
    - A remoção deve se dar tanto por código numérico quanto por código textual ISO combinado

Critérios de Aceitação
    - Dado que informo o código numérico de um idioma existente, então a aplicação remove o idioma com sucesso
    - Dado que informo o código textual ISO combinado de um idioma existente, então a aplicação remove o idioma com sucesso
    - Dado que o código (seja textual ISO combinado ou numérico) informado não existe na base, então a aplicação rejeita a remoção e informa que o idioma não foi encontrado
```

> Nota: O analista de operações globais não deixou claro no seu depoimento por qual código o idioma deve ser localizado para ser removido. Mas o gerente de produtos digitais nos deu uma pista importante para uma tomada de decisão, dizendo que na consulta ele deve ser buscado por ambos os códigos.

```gherkin
US3 - Alteração de dados de idioma

Como um analista de operações globais
Eu quero alterar a descrição de um idioma já cadastrado
Para corrigir descrições incorretas ou melhorar sua clareza

Regras
    - Apenas a descrição pode ser alterada
    - O código numérico não pode ser modificado
    - A nova descrição é obrigatória
    - A nova descrição deve conter apenas letras, números e acentuação
    - A alteração deve registrar informações de auditoria: usuário responsável e data/hora atuais

Critérios de Aceitação
    - Dado que informo uma nova descrição válida, então a aplicação atualiza o idioma e registra as informações de auditoria com sucesso
    - Dado que o código numérico informado não existe na base, então a aplicação rejeita a alteração e informa que o idioma não foi encontrado
    - Dado que o código textual ISO combinado informado resulta em um código numérico que não existe na base, então a aplicação rejeita a alteração e informa que o idioma não foi encontrado
    - Dado que a nova descrição não é informada ou é inválida, então a aplicação rejeita a alteração e informa que a descrição é inválida
```

> Nota: O analista de operações globais não deixou claro no seu depoimento por qual código o idioma deve ser localizado para ser alterado. Mas o gerente de produtos digitais nos deu uma pista importante para uma tomada de decisão, dizendo que na consulta ele deve ser buscado por ambos os códigos.

```gherkin
US4 - Listagem de idiomas

Como um gerente de expansão global
Eu quero visualizar a lista de todos os idiomas cadastrados
Para verificar se o banco já possui suporte linguístico para regiões com as quais estamos negociando

Regras
    - A listagem deve retornar todos os idiomas cadastrados
    - A listagem deve exibir: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)

Critérios de Aceitação
    - Ao solicitar a listagem, a aplicação retorna todos os idiomas existentes com suas informações
    - Se não houver idiomas cadastrados, então a aplicação rejeita a consulta e informa que a lista está vazia
```

```gherkin
US5 - Consulta de idioma por código

Como um gerente de produtos digitais
Eu quero consultar um idioma pelo seu código
Para validar rapidamente operações com parceiros estrangeiros

Regras
    - A consulta pode ser realizada pelo código numérico ou pelo código textual ISO combinado
    - A consulta deve retornar exatamente 1 idioma caso cadastrado
    - A consulta deve retornar: código numérico, código textual ISO combinado, descrição e informações de auditoria (última alteração)
    - Caso não exista idioma correspondente, a aplicação deve informar inexistência

Critérios de Aceitação
    - Dado que informo um código numérico válido de um idioma existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código textual ISO combinado que resulta em um código numérico de um idioma existente, então a aplicação retorna seus dados completos com sucesso
    - Dado que informo um código numérico inexistente, então a aplicação rejeita a consulta e informa que o idioma não foi encontrado
    - Dado que informo um código textual ISO combinado inválido ou que resulta em um código numérico inexistente, então a aplicação rejeita a consulta e informa que o idioma não foi encontrado
```

## [Exercícios](02-exercicios.md)
