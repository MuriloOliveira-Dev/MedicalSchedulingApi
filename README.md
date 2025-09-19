# 🩺 Medical Scheduling API

API REST para **agendamento médico**, desenvolvida em **ASP.NET Core 8** aplicando **Clean Architecture** e **Domain-Driven Design (DDD)**.

## 🚀 Tecnologias
- ASP.NET Core 8 (Minimal API)
- Swagger / OpenAPI
- Arquitetura em camadas (Api, Application, Domain, Infrastructure)
- C#

## 📂 Estrutura do Projeto
- **Api** → Endpoints REST (Minimal API, Swagger).
- **Application** → Serviços e lógica de negócio.
- **Domain** → Entidades centrais (ex.: `Patient`).
- **Infrastructure** → Persistência (ainda em memória, pode evoluir para banco).

## ⚡ Endpoints disponíveis (Patient)
- `GET /Patient` → Lista todos os pacientes
- `GET /Patient/{id}` → Busca paciente por ID
- `POST /Patient` → Cria um novo paciente
- `PUT /Patient/{id}` → Atualiza dados de um paciente
- `DELETE /Patient/{id}` → Remove paciente

## 📖 Exemplo de JSON (POST /Patient)
```json
{
  "name": "João da Silva",
  "email": "joao@gmail.com"
}
