<h1 align="center">Vehicle Fleet Management</h1>
<p align="center">🚀 API Rest - Gestão de Frota de Veículos</p>

### Sobre
Uma solução que seja capaz de gerenciar os veículos de sua frota
possibilitando ao negócio localizá-los de diversas formas para fins de abertura de contratos
de aluguel, para manutenção e etc.

Esta API deve ser capaz de registrar um Cliente (pessoa física) com seus dados básicos
(Nome, CPF, Data de Nascimento, Número CNH e Endereço). Além disso, precisamos
disponibilizar um recurso que realize uma Reserva (Data, Cliente, Veículo, Data Retirada,
Data Prevista Devolução, Data Devolução) de um veículo para aluguel.

### Features

- [x] Cadastro de cliente
- [x] Atualizar endereço do cliente
- [x] Consultar clientes por cpf e nome
- [x] Cadastro de veículo
- [x] Consulta de veículos por placa, modelo e fabricante
- [x] Realizar retirada de veículos com uma reserva em aberto
- [x] Cadastro de Reserva
- [x] Atualizar datas de Reserva
- [x] Encerrar Reserva
- [x] Consultar Reservas por cliente
- [x] Consultar Reservas com veículo retirado
- [x] Consultar Reservas com o retorno atrasado


### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Docker](https://www.docker.com/products/docker-desktop).
Além disto é bom ter um gerenciador de banco de dados para trabalhar com o script de inicialização [SQL Server Management Studio](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15). 

### 🎲 Rodando o BackEnd e Banco de dados

```bash
# Clone este repositório
$ git clone https://github.com/valcaciols/vehicle-fleet-management.git

# Acesse a pasta do projeto no terminal/cmd
$ cd vehicle-fleet-management

# Execute o comando para realizar o build Docker
$ docker compose build

# Execute o comando subir a aplicação e o banco
$ docker compose up -d
```

### 🎲 Executando script de inicialização do Banco de dados

```bash
# Acesse o o seu gerenciador de banco de dados com as credenciais abaixo:
$ User=sa Password=Your_password123

# Abra e copie o conteúdo do arquivo de script na raiz do projeto
$ Arquivo: setup-db.sql

# Execute o script para inicializar banco
```

### 🎲 Acessando a aplicação backend pelo swagger

 O servidor inciará na porta : 8000 - Acesse <http://localhost:8000/swagger>
