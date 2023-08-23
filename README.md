# ClientRegistryAPI

## API de Gerenciamento de Clientes
Bem-vindo à documentação da API de Gerenciamento de Clientes. Esta API foi desenvolvida para permitir o cadastro, listagem e obtenção de detalhes de clientes, incluindo informações como nome, telefone, email e endereço. A API foi construída utilizando a versão mais recente do .NET Core e segue os princípios REST, incorporando padrões recomendados de desenvolvimento.

## Funcionalidades
### 1. Cadastrar Cliente
Permite cadastrar um novo cliente com as seguintes informações:

ID (identificador único)
Nome Completo
Telefone
Email
Endpoint: POST /api/clientes

Exemplo de corpo da requisição:

json
Copy code
{
    "nome": "Fulano de Tal",
    "telefone": "(11) 98765-4321",
    "email": "fulano@example.com"
}

## 2. Listar Todos os Clientes
Retorna uma lista de todos os clientes cadastrados.

Endpoint: GET /api/clientes

## 3. Listar Detalhes do Cliente
Retorna os detalhes de um cliente, incluindo o endereço principal e o email principal.

Endpoint: GET /api/clientes/{id}

## Tecnologias Utilizadas
.NET Core {Versão Ativa}
REST
Docker Compose

# Modelagem de Dados
### A API utiliza as seguintes tabelas com relacionamentos:

## Tabela Clientes:

ID (Chave Primária)
Nome Completo
Telefone
Email
Tabela Enderecos:

ID (Chave Primária)
ClienteID (Chave Estrangeira para a tabela Clientes)
Endereco
Cidade
Estado
CEP

## Testes Unitários
Foram implementados testes unitários para validar a integridade e estrutura dos campos de email e telefone. Esses testes asseguram que os dados inseridos nos clientes estão de acordo com o formato esperado.

## Docker Compose
Para facilitar a configuração do ambiente de desenvolvimento, o Docker Compose é utilizado para subir um banco de dados SQL Server ou SqlLite. Isso permite que você inicie o projeto sem se preocupar com as dependências de banco de dados.

## Padrão Utilizado
Durante o desenvolvimento da API, foi empregado o padrão de arquitetura {Nome do Padrão}, garantindo a organização, manutenção e escalabilidade do código.

## Iniciando
Clone este repositório: git clone https://github.com/seu-usuario/seu-repositorio.git
Navegue até o diretório do projeto: cd nome-do-projeto
Inicie os contêineres do Docker Compose: docker-compose up
Acesse a API em: http://localhost:5000

## Conclusão
Esta API de Gerenciamento de Clientes oferece funcionalidades para cadastrar, listar e obter detalhes de clientes. Ela foi desenvolvida seguindo as melhores práticas do .NET Core e REST, além de incorporar testes unitários e Docker Compose para uma experiência de desenvolvimento otimizada. Sinta-se à vontade para contribuir, reportar problemas ou melhorar este projeto.


