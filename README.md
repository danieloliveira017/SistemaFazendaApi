🌾 SistemaFazendaApi

API desenvolvida em .NET 8 para gerenciamento de fazendas, usuários, plantações e máquinas.
Projeto voltado para portfólio e aprendizado prático de arquitetura em camadas, boas práticas e integração com banco de dados Sqlite.

🧱 Arquitetura do Projeto

O projeto segue uma arquitetura em camadas, separando responsabilidades de forma clara:

SistemaFazendaApi:
    
    ├── Api/             # Controllers (camada de apresentação)
    ├── Application/     # Serviços e regras de negócio
    ├── Domain/          # Entidades, DTOs e enums
    ├── Infrastructure/  # Banco de dados, repositórios e contexto
    ├── Tests/           # Testes unitários e de integração (futuro)
    └── README.md


Vantagens:

- Manutenção mais fácil

- Testabilidade

- Escalabilidade futura

-------------------------------------------------------------------------------------------------------------------------------------------

⚙️ Tecnologias Utilizadas

- .NET 8 e ASP.NET Core Web API

- Entity Framework Core + PostgreSQL

- Autenticação JWT

- C#

- Docker (planejado)

- xUnit (para testes futuros)

-------------------------------------------------------------------------------------------------------------------------------------------

📡 Funcionalidades Principais

- Cadastro e autenticação de usuários com JWT

- Cadastro e vinculação de fazendas a usuários

- Consulta de fazendas vinculadas ao login autenticado

Estrutura planejada para incluir:

    - Máquinas agrícolas (tipo, ano, número de série, manutenção)

    - Plantações e tipos de cultivo (quantidade, área, custos)

    - Gestão financeira de insumos, produção e manutenção

    - Relatórios e dashboards

-------------------------------------------------------------------------------------------------------------------------------------------

🔧 Futuras Funcionalidades IoT

O sistema está planejado para integrar sensores e dispositivos IoT no ambiente agrícola, permitindo:

- Monitoramento em tempo real do solo, clima e irrigação

- Coleta automática de dados de máquinas e equipamentos

- Alertas e notificações baseados em parâmetros definidos

- Armazenamento seguro e processamento de grandes volumes de dados

- Visualização de dashboards para análises de desempenho e produtividade

Tecnologias futuras:

Azure IoT Hub ou AWS IoT Core

Banco PostgreSQL

Suporte para microserviços

---------------------------------------------------------------------------------------------------------------------------------------------

🚀 Como Executar o Projeto
Pré-requisitos

- .NET SDK 8

- PostgreSQL

- IDE: Visual Studio Code ou Visual Studio

- Ferramenta de testes de API: Insomnia, Postman, etc.

-----------------------------------------------------------------------------------------------------------------------------------------------

💡 Objetivos do Projeto

Demonstrar POO e boas práticas em C#

Desenvolver APIs RESTful em .NET

Aplicar Clean Architecture em projetos complexos

Integrar banco de dados e autenticação segura

Planejar coleta de dados IoT para agricultura

------------------------------------------------------------------------------------------------------------------------------------------------

👨‍💻 Autor

Daniel Dourado de Oliveira
📍 Jales-SP
📧 danieloliveirask891@gmail.com
