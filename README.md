# ALTERDATA - AVALIAÇÃO - ASP .NET Core API

Esta repositório hospeda o projeto de uma Web API construída para o processo seletivo da Altedata Sofware para o Sistema de Votação de Recursos (SVR) desenvolvida com o framework ASP .NET Core. Neste projeto fiz o uso de uma arquitetura multicamada (N-tier) fazendo a separação dos conceitos, adotei alguns padrões de projeto para tornar o código mais reutilizável e fácil de manter e fiz o uso de algumas tecnologias como o Entity Framwork Core e o Microsoft Identity para cuidar da infraestrutura de segurança e acesso a dados da aplicação, tornando o desenvolvimento mais produtivo e focado na implementação do negócio. A API possui funcionalidades para permitir votos de funcionários em recursos que serão selecionados para desenvolvimento. Consulte a documentação na pasta **docs** para maiores detalhes.

## Documentação da API:

https://localhost:44332/swagger/index.html

## Pré-requisitos:

Antes de executar o projeto certifique-se de ter as configurações abaixo instaladas no seu ambiente.

+ .NET Core SDK 3.1
+ PostgreSQL 2.1.4
+ Visual Studio 2019 ou o Visual Studio Code
+ Privilégios de administrador no Sistema Operacional
+ Configurar uma variável de ambiente no sistema operacional como administrador com o nome **SECRET** e um valor  (isto será usado para autenticação JWT durante login e acesso aos endpoints protegidos)
+ GIT 2.26.2 ou uma versão superior
+ pgAdmin 4
+ Postman 

## Rodando o projeto:

Siga os passos abaixo para rodar o projeto.

1. Clone este repositório utilizando o GIT para um diretório na sua máquina: **git clone** https://github.com/luafalcaocode/alterdata-aspnetcore-api.git
2. Abra o projeto no Visual Studio 2019 (em modo Administrador).
3. Altere a string de conexão **PostgreSQLConnection** configurada no arquivo **appsettings.json** para apontar para as configurações da sua máquina com um servidor PostgreSQL;
4. Abra o console do Visual Studio (**navegue até Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes**), verifique se o projeto principal está selecionado (**alterdata.api.Web**) e execute os dois comandos a seguir para configurar e gerar a estrutura do banco de dados:

- **Add-Migration InitialCreate** (este comando registra o modelo de dados e habilita a sincronização com a estrutura física)
- **Update-Database** (este comando cria o banco de dados baseado na configuração do arquivo **appsettings.json**)

**Obs.:** Se os comandos acima não forem reconhecidos no seu sistema então será necessário configurar o recurso **migrations** executando o seguinte comando no console: **dotnet tool install --global dotnet-ef**. Em seguida, execute novamente os comandos acima.

Alternativamente você pode rodar o projeto utilizando o Visual Studio Code ou outra ferramenta executando os comandos da .NET CLI para rodar o projeto. 

5. Pressione F5 

## Solução de problemas

Em caso de problemas para executar o projeto, tente as seguintes opções:

+ Se ao rodar o projeto você visualizar uma mensagem de erro, verifique se o seu Antivírus está bloqueando a execução do projeto. O Avast, por exemplo, faz uma varredura ao iniciar a aplicação e só após sua conclusão é possível iniciar o projeto (nesse caso pressione F5 novamente). 

+ Se os projetos não forem carregados na solução, abra o Visual Studio e rode-o novamente com permissão de Administrador.

+ Se a autenticação apresentar problemas, verifique se uma variável de ambiente de sistema com o nome **SECRET** está configurada no seu sistema operacional. Isto é necessário para garantir a segurança da API.

## Cálculo do Fuso Horário ao registrar data e hora 

O cálculo da data e hora do voto foi realizado levando em consideração que o sistema será implantado em um servidor que fica localizado na matriz da Alterdata, na cidade de Teresópolis, que usa o fuso horário em relação à região de Brasilia. Através da UF da filial onde o funcionário trabalha (que é informada durante o cadastro do funcionário) foi feito um mapeamento do fuso horário daquela região, e tomando o fuso horário de Brasilia como referência foi calculado a diferença das horas:

- **Região de Fernando de Noronha:** 1 hora adiantada em relação ao fuso horário de Brasília
- **Região da Amazônia:** 1 hora de atraso em relação ao fuso horário de Brasília
- **Região do Acre:** 2 horas de atraso em relação ao fuso horário de Brasília
- **Região de Brasilia:** Tomado como referência para calcular os demais horários


## Autenticação e Autorização

- Segundo a regra de negócio um usuário é um funcionário. Então através do cadastro de funcionários é criado automaticamente um usuário para ele. Alternativamente é possível cadastrar um usuário sem associá-lo a um funcionário utilizando outro endpoint. 

- Existem 2 permissões que são inseridas na tabela durante a criação do banco de dados (**Administrador** e **Todos**). O perfil **Administrador** tem permissão para manter funcionários e recursos, enquanto que o perfil **Todos** tem permissão para votar e acessar o sistema. Ao cadastrar um funcionário você pode informar um desses dois perfis na propriedade **Perfis** do JSON usado para cadastro (consulte o Swagger para ver o formato dos dados esperados pelo servidor).

- Para utilizar alguns endpoints é necessário fazer autenticação através do endpoint de login informando o usuário e senha do funcionário após ter sido cadastrdado. Com isso, a cada requisição é preciso informar o token de segurança que será obtido no login e inserir o token no cabeçalho Authorization de cada requisição. Isso pode ser feito via ferramenta Postman durante os testes.

## Convenção de nomeclaturas

As regras e entidades de negócio estão escritas em português para facilitar a identificação. As demais partes do código foram mantidadas em inglês. Padrões de projeto, quando necessário, foram utilizados com sufixos para facilitar a identificação e permitir um vocabulário comum entre os desenvolvedores no projeto.

## Testando a API

Para testar a API recomendo usar a ferramenta Postman. Na Pasta **docs/Exemplo de Requisicoes a API** tem uma coleção de requisições que pode ser importada na ferramenta com os dados e endpoints configurados para consumir. Basta substituir o token no cabeçalho da requisição pelo token gerado na sua máquina para fazer a autenticação.

## Tecnologias utilizadas

- .NET Core 3.1
-  Microsoft Identity Membership
-  Entity Framework Core
-  PostgreSQL 2.1.4
-  pgAdmin 4

## Contato:

Em caso de dúvidas para fazer a configuração do projeto no seu ambiente, pode entrar em contato comigo pelos meios abaixo:

E-mail: lpjfalcao@gmail.com ou lcodeveloper@outlook.com

Whats App: (21) 99023-8300

LinkedIn: https://www.linkedin.com/in/luafalcao/?locale=pt_BR

