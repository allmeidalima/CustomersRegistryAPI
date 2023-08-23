# ClientRegistryAPI

## API de Gerenciamento de Clientes
Bem-vindo à documentação da API de Gerenciamento de Clientes. Esta API foi desenvolvida para permitir o cadastro, listagem e obtenção de detalhes de clientes, incluindo informações como nome, telefone, email e endereço..

## Funcionalidades
### 1. Cadastrar Cliente
Permite cadastrar um novo cliente com as seguintes informações:

ID (identificador único)
- Nome Completo
- Telefone
- Email
- Endereço

## Exemplo de corpo da requisição:

json
```
{
	"name": "string",
	"lastName": "string",
	"email": [
		{
			"priority": 0,
			"typeEmail": 0,
			"email": "string"
		}
	],
	"address": [
		{
			"priority": 0,
			"typeAddress": 0,
			"address": "string",
			"neighborhood": "string",
			"number": "string",
			"postalCode": "string"
		}
	],
	"phoneNumber": [
		{
			"phoneNumber": "string",
			"priority": 0,
			"typePhoneNumber": 0
		}
	]
}
```
## Tecnologias Utilizadas
[![My Skills](https://skillicons.dev/icons?i=dotnet,docker,github)](https://skillicons.dev)

- .NET Core {Versão Ativa}
- API REST
- Docker Compose

# Modelagem de Dados
### A API utiliza as seguintes tabelas com relacionamentos:

## Tabela Clientes:

- ID (Chave Primária)
- Nome Completo
- Telefone
- Data de Criação

## Tabela Enderecos:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Endereco
- Cidade
- Estado
- CEP

## Tabela Email:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Email
- Tipo do e-mail
- Prioridade

## Tabela Telefone:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Telefone
- Tipo do Telefone
- Prioridade

## Testes Unitários
Foram implementados testes unitários para validar a integridade e estrutura dos dados. Esses testes asseguram que os dados inseridos dos clientes estão de acordo com o formato esperado.

## Docker Compose
Para facilitar a configuração do ambiente de desenvolvimento, o Docker Compose é utilizado para subir um banco de dados SQL Server. Isso permite que você inicie o projeto sem se preocupar com as dependências de banco de dados.

## Iniciando
Clone este repositório: git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/allmeidalima/ClientRegistryAPI.git)
Navegue até o diretório do projeto: cd nome-do-projeto
Inicie os contêineres do Docker Compose: docker-compose up
Acesse a API em: http://localhost:5000

## Conclusão
Esta API de Gerenciamento de Clientes oferece funcionalidades para cadastrar, listar e obter detalhes de clientes. Ela foi desenvolvida seguindo as melhores práticas do .NET Core e REST, além de incorporar testes unitários e Docker Compose para uma experiência de desenvolvimento otimizada. Sinta-se à vontade para contribuir, reportar problemas ou melhorar este projeto.


