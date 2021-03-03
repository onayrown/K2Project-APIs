# K2Project-APIs
K2 Partnering - Teste Técnico .NET

A proposta desse projeto era criar duas API's uma com dois endpoints e outra com um endpoint:

# API 1
1) Retorna taxa de juros
Responde pelo path relativo "/taxaJuros"
Retorna o juros de 1% ou 0,01 (fixo no código)
Exemplo: /taxaJuros Resultado esperado: 0,01

# API 2
1) Calcula Juros
Responde pelo path relativo "/calculajuros"
Ela faz um cálculo em memória, de juros compostos, conforme abaixo: Valor Final =
Valor Inicial * (1 + juros) ^ Tempo
Valor inicial é um decimal recebido como parâmetro.
Valor do Juros deve ser consultado na API 1.
Tempo é um inteiro, que representa meses, também recebido como parâmetro.
^ representa a operação de potência.
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais.
Exemplo: /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
2) Show me the code
Este responde pelo path relativo /showmethecode Deverá retornar a url de onde
encontra-se o fonte no github.

## Instruções de instalação e execução
1. Primeiro baixe e compile todos os projetos.
2. Verifique se Start Up Project está definido na solution como Docker-Compose
3. Execute o projeto

## Descrição detalhada de cada API.

# API 1 Taxas
 - Endpoint 1 -> https://localhost:49166/TaxaJuros
 - Swagger -> http://localhost:49166/swagger/index.html

# API 2 Juros
 - Endpoint 1 -> https://localhost:49167/CalculaJuros
 - Endpoint 2 -> https://localhost:49167/ShowMeTheCode
 - Swagger -> http://localhost:49167/swagger/index.html

## Requerimentos Técnicos
 - [.NET Core 2.2](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral)
 - [.NET Core 2.0](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral)
 - [Visual Studio 2017 ou 2019](https://visualstudio.microsoft.com/pt-br/downloads/)
