# Exercícios de Negócio e requisitos

## 1. Gestão de categorias de produtos bancários

Neste exercício, você vai **construir user stories** a partir de depoimentos de profissionais do negócio que atuam na área de comercial e marketing do banco.

Lembre-se: aqui vamos "brincar" um pouco de PO/Analista. Seu trabalho é elicitar papeis, intenções, benefícios/valores agregados, regras e critérios de aceitação a partir dos depoimentos:

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

- Não "invente" funcionalidades que não estejam implícita ou explicitamente motivadas nos depoimentos dos stakeholders — não queremos construir funcionalidades que não geram valor. São esperadas pelo menos **5 user stories** para esse conjunto de depoimentos;
- Atribua identificadores e breves descrições às stories, assim como foi feito no laboratório.

### Depoimentos de stakeholders

- **Analista de marketing:** "Com o aumento das nossas linhas de negócio, ficou cada vez mais importante manter um cadastro oficial de _categorias de produtos bancários_. Essas categorias são usadas como referência por diversas áreas, desde os times de produto até campanhas de marketing. Por isso, precisamos registrá-las corretamente na aplicação.";
- **Gerente de marketing:** "Às vezes percebemos que uma descrição foi cadastrada de maneira incompleta ou pouco clara. Em outras situações, precisamos renomear uma categoria para refletir uma atualização estratégica. Nessas horas, é fundamental registrar quem realizou a alteração e quando, para manter rastreabilidade e alinhamento entre áreas.";
- **Gerente de marketing:** "Antes de definirmos campanhas e direcionamentos comerciais, eu sempre consulto a lista completa de categorias de produtos bancários. Isso nos permite entender melhor como o portfólio está organizado e ajuda a identificar oportunidades ou lacunas.";
- **Analista comercial:** "Quando uma categoria deixa de fazer sentido para o portfólio atual do banco, precisamos removê-la para evitar que outras equipes a selecionem acidentalmente ao cadastrem novos produtos. Isso reduz ruídos internos e impede classificações erradas.";
- **Especialista em regulações:** "Cada categoria possui um código numérico único que é utilizado em integrações com sistemas legados e ferramentas regulatórias. Esse código precisa ser consistente e imutável. Uma inconsistência pode gerar divergências em relatórios internos e externos, então a aplicação precisa garantir unicidade e confiabilidade.";
- **Gerente de produtos digitais:** "Em reuniões de alinhamento com parceiros e áreas internas, é comum precisarmos consultar rapidamente uma categoria específica pelo seu código ou descrição. Isso ajuda na tomada de decisão e na validação de novos produtos.".
