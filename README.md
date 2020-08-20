# ALTERDATA ASP .NET Core API

Esta repositório hospeda o projeto de uma Web API construída para o processo seletivo da Altedata para o Sistema de Votação de Recursos (SVR) desenvolvida com o framework ASP .NET Core. Neste projeto fiz o uso de uma arquitetura multicamada (N-tier) fazendo a separação dos conceitos, adotei alguns padrões de projeto para tornar o código mais reutilizável e fácil de manter e fiz o uso de algumas tecnologias como o Entity Framwork Core e o Microsoft Identity para cuidar da infraestrutura de segurança e acesso a dados da aplicação, tornando o desenvolvimento mais produtivo e focado na implementação do negócio.

## Pré-requisitos:

+ instalar o .NET Core SDK 3.1.5
+ instalar o PostgreSQL 2.1.4
+ instalar o Visual Studio 2019 ou o Visual Studio Code
+ ter acesso de administrador na máquina
+ configurar uma variável de ambiente no sistema operacional como administrador com o nome **SECRET** e um valor  (isto será usado para autenticação JWT durante login e acesso aos endpoints protegidos)

## Configurando o projeto:

1. clonar o repositório no GIT
2. abrir o projeto no visual studio
3. alterar a string de conexão do arquivo **appSettings.json** para apontar para as configurações da sua máquina com um servidor PostgreSQL configurado (configurar a chave **PostgreSQLConnection** do arquivo);
4. abrir o console do Visual Studio (navegue até Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes) ou o interpretador de comandos do sistema apontando para o projeto principal (altedata.api.Web) e digite o seguinte comando para gerar a estrutura do banco de dados: **update-database**

**Obs.:** se o comando update-database não for reconhecido então será necessário configurar o recurso **migrations** digitando o seguinte comando no console apontando para o projeto principal: **dotnet tool install --global dotnet-ef**

5. Pressione F5 

## Solução de problemas

Em caso de problemas para executar o projeto, tente as seguintes opções:

+ Se ao rodar o projeto você visualizar uma mensagem de erro, verifique se o seu Antivírus está bloqueando a execução do projeto. O Avast, por exemplo, faz uma varredura ao iniciar a aplicação e só após sua conclusão é possível iniciar o projeto. 

+ Se os projetos não forem carregados na solução, abra o Visual Studio e rode-o novamente com permissão de Administrador.

+ Se a autenticação apresentar problemas, verifique se uma variável de ambiente de sistema com o nome **SECRET** está configurada no seu sistema operacional.

+ Se o projeto de testes não sinalizar o status dos testes executados, rode o comando **dotnet test** no console do Visual Studio para rodar o projeto do NUnit manualmente.

## Convenção de Nomeclaturas

As regras e entidades de negócio estão escritas em português para facilitar a identificação. As demais partes do código foram mantidades em inglês. Padrões de projeto, quando necessário, foram utilizados com sufixos para facilitar a identificação e permitir um vocabulário comum entre os desenvolvedores no projeto.


## Tecnologias utilizadas

- .NET Core 3.5.1
-  Microsoft Identity Membership
-  Entity Framework Core
-  PostgreSQL 2.1.4
- NUnit Test Runner
