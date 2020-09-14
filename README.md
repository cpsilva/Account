# Account

## Análise de Código
[![CodeFactor](https://www.codefactor.io/repository/github/cpsilva/chamadofacil/badge)](https://www.codefactor.io/repository/github/cpsilva/chamadofacil)

## Objetivo:

Criado um serviço responsavel por realizar uma operação de débito e crédito entre contas, recebendo atraves de um POST um JSON conforme o exemplo a abaixo 

{
  "contaOrigem": "B27F745D-F088-4259-8B84-932F8257AF5D",
  "contaDestino": "B623272E-CD42-47C4-BFD0-B4AC2776E4B0",
  "valor": 1000.0
}

Como resultado caso todos os dados sejam validos será retornado um 200 (Ok) por parte da API caso tenha algum erro seja de no Guid das contas ou valores a API devolverá um erro 400 com o erro correspondente

Para fins de teste já foi criado duas contas para realizar as operações de teste conforme abaixo o seed já é aplicado junto a aplicação.

![](https://github.com/cpsilva/Account/blob/master/Screenshots/Seed.PNG)

## Execução do Projeto:

1. No Visual Studio selecionar o projeto Account.Api como Startup Project.

2. Executar o projeto com o IIS Express.

3. Neste momento a API da aplicação já está disponivel para acesso e uso da controller.

   Segue exemplo do request via postman

![](https://github.com/cpsilva/Account/blob/master/Screenshots/request-example.png)

