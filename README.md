
![cd714d2d-cb93-4e82-95ae-f85feae1546e](https://github.com/allmeidalima/CustomersRegistryAPI/assets/91704800/08b04b62-a8ba-4f14-9d5a-687492a2a893)

## API de Gerenciamento de Clientes
Bem-vindo à documentação da API de Gerenciamento de Clientes. Esta API foi desenvolvida para permitir o cadastro, listagem e obtenção de detalhes de clientes, incluindo informações como nome, telefone, email e endereço..

# :hammer: Funcionalidades do projeto

- `Funcionalidade 1`: Cadastrar clientes;
- `Funcionalidade 2`: Consultar todos os clientes que estão na base;
- `Funcionalidade 2a`: Consultar clientes por id;

## Tecnologias Utilizadas
![lincense](http://img.shields.io/static/v1?label=lincense&message=MIT&color=GREEN&style=for-the-badge)
![linguage](http://img.shields.io/static/v1?label=linguage&message=Csharp&color=purple&style=for-the-badge)
![containers](http://img.shields.io/static/v1?label=containers&message=Docker%20Compose&color=purple&style=for-the-badge)
![data base](http://img.shields.io/static/v1?label=data%20base&message=Sql%20Server&color=purple&style=for-the-badge)

# Índice 

* [Estruturação](#Estruturação)
* [Testes Unitários](#Testes-Unitários)
* [Docker Compose](#Docker-Compose)
* [Abrir e rodar o projeto](#Abrir-e-rodar-o-projeto)


# Estruturação

Modelagem de Dados
A API utiliza as seguintes tabelas com relacionamentos:

:white_check_mark: Tabela RegisteredCustomer:

- ID (Chave Primária)
- Nome Completo
- Telefone
- Data de Criação

:white_check_mark: Tabela CustomerAdresses:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Endereco
- Cidade
- Estado
- CEP

:white_check_mark: Tabela CustomerEmails:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Email
- Tipo do e-mail
- Prioridade

:white_check_mark: Tabela CustomerPhoneNumbers:

- ID (Chave Primária)
- ClienteID (Chave Estrangeira para a tabela Clientes)
- Telefone
- Tipo do Telefone
- Prioridade

## Testes Unitários
Foram implementados testes unitários para validar a integridade e estrutura dos dados. Esses testes asseguram que os dados inseridos dos clientes estão de acordo com o formato esperado.

## Docker Compose
Para facilitar a configuração do ambiente de desenvolvimento, o Docker Compose é utilizado para subir um banco de dados SQL Server. Isso permite que você inicie o projeto sem se preocupar com as dependências de banco de dados.

# 🛠️ Abrir e rodar o projeto

**Rodando o projeto**
* git clone https://github.com/allmeidalima/CustomersRegistryAPI
* Abra o código no Visual Studio, pois ele facilita o uso do docker compose.
* Aperte F5 pra iniciar o programa ou aperte no botão  ![Capturar](https://github.com/allmeidalima/CustomersRegistryAPI/assets/91704800/05aba3c9-b7d0-42f1-9711-e2d7894ba589)
* Com o comando **C + "** abra o terminau da IDE e navegue até a pasta Customer.DBO, o comando para isso é cd Customer.DBO.
* Quando estiver nesse diretório aplique o seguinte comando no terminal: **dotnet ef database update**. Assim criaremos nosso banco de dados.
* Por fim, pode fechar o terminal e uma aba do navegador ja vai estar aberta com a API rodando, use o exemplo de requisição abaixo para cadastrar seu primeiro cliente.

## Exemplo de corpo da requisição:
json
```
{
	"name": "Lucas",
	"lastName": "Lima",
	"email": [
		{
			"priority": 0,
			"typeEmail": 0,
			"email": "allmeida.lima@gmail.com"
		}
	],
	"address": [
		{
			"priority": 0,
			"typeAddress": 0,
			"address": "Rua Pacule",
			"neighborhood": "Jovaia",
			"number": "177",
			"postalCode": "07132-580"
		}
	],
	"phoneNumber": [
		{
			"phoneNumber": "(11)93709-1682",
			"priority": 0,
			"typePhoneNumber": 0
		}
	]
}
```

## Conclusão
Esta API de Gerenciamento de Clientes oferece funcionalidades para cadastrar, listar e obter detalhes de clientes. Ela foi desenvolvida seguindo as melhores práticas do .NET Core e REST, além de incorporar testes unitários e Docker Compose para uma experiência de desenvolvimento otimizada. Sinta-se à vontade para contribuir, reportar problemas ou melhorar este projeto.


