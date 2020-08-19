# alterdata-voting-rest-api

Este projeto hospeda uma web api para o processo seletivo da Alterdata, cujo objetivo é oferecer funcionalidades que permita aos usuários votarem em diferentes recursos  para que sejam selecionados pelo time de desenvolvimento. Estes recursos agregam valor aos clientes da empresa e serão priorizados mediante uma votação onde todos os funcionários da companhia poderão participar.

## Estrutura

O projeto utiliza uma arquitetura multicamadas (n-tier) onde cada uma possui sua responsabilidade e representa uma abstração importante do sistema. Para cada camada foi selecionado um conjunto de padrões de projeto para tornar a solução mais robusta, reutilizável e fácil de dar manutenção, como Repository Pattern, Facades, Adapters, Factories, ORMs e Injeções de dependência.

**luafalcao.api.Web** - camada onde residem os controles, classes responsáveis por receber uma requisição HTTP de outras aplicações e devolver uma solicitação.

**luafalcao.api.Facade** - interface comum para acessar a camadas do sub-sistema e isolar o domínio dos controles, garantindo um código mais fácil de manter

**luafalcao.api.Domain** - camada onde as regras de negócio e serviços ficam armazenados, assim como adapters que se comunicam com a API de autenticação

**luafalcao.api.Persistence** - camada de acesso a dados onde os repositórios que manipulam informações no banco, entidades e outras representações de dados residem

**luafalcao.api.Shared** - camada acessível por todas as demais e que oferece funcionalidades comuns 

**luafalcao.api.IntegrationTests** - camada para ajudar no controle da qualidade com testes para validar a integração entre diferentes classes 



