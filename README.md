# alterdata-voting-rest-api

Esta branch hospeda o projeto de uma Web API construída para o processo seletivo da Altedata para o Sistema de Votação de Recursos (SVR) desenvolvida com o framework ASP .NET Core. 

## Pré-requisitos:

+ instalar o .NET Core SDK 3.1.5
+ instalar o PostgreSQL 2.1.4
+ instalar o Visual Studio 2019 ou o Visual Studio Code
+ ter acesso de administrador na máquina
+ configurar uma variável de ambiente no sistema operacional como administrador com o nome **SECRET** e um valor  (isto será usado para autenticação JWT durante login e acesso aos endpoints protegidos)

## Configurando o projeto:

+ clonar o repositório no GIT
+ abrir o projeto no visual studio
+ alterar a string de conexão para apontar para as configurações da sua máquina com um servidor PostgreSQL configurado;
+ abrir o console do Visual Studio ou o interpretador de comandos do sistema apontando para o projeto principal (altedata.api.Web) e digitar o seguinte comando para gerar a estrutura do banco de dados: **dotnet ef update-database**

**Obs.:** se o comando update-database não for reconhecido então será necessário configurar o recurso **migrations** digitando o seguinte comando no console apontando para o projeto principal:

**dotnet tool install --global dotnet-ef**

## Tecnologias utilizadas

- .NET Core 3.5.1
-  Microsoft Identity Membership
-  Entity Framework Core
-  PostgreSQL 2.1.4
