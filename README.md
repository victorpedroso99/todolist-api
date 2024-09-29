# Todolist api

Foi criada uma api utilizando o modelo API MVC do C#, para esse caso poderia até ser utilizo o modelo de minimal api, porém optei por um modelo com controllers para melhor organização e caso sejam implantadas melhorias futuras, como autenticação, ficaria melhor para essa implementação.

Esse projeto utiliza:
- SQL Server como SGBD para armazenamento dos dados
- Entity Framework como ORM para manipulação do banco de dados
- Entity Framework Tools para aplicação das migrations
- AutoMapper para mapeamento das DTOs para os modelos (entidades)

Foram feitas as injeções de dependência necessárias, tanto com o arquivo de contexto do banco de dados, como a interface e a classe que a implementa (ITodoTaskService e TodoTaskService)

Como mencionei na documentação do app, gostaria de ter implementado uma autenticação, protegendo as rotas e enviando tokens de acesso de volta ao aplicativo, nesse caso poderia ser implementado manualmente ou com o auxílio do identity.

Essa api esta hospedada na Azure sob o link: [todolistapp-agbqetcef4bwcpcu.brazilsouth-01.azurewebsites.net](https://todolistapp-agbqetcef4bwcpcu.brazilsouth-01.azurewebsites.net/swagger/index.html)

O banco de dados SQL Server também esta hospedado na Azure, no servidor: victorpedroso-todolistapp.database.windows.net

Caso seja necessário, a cadeia de conexão com o banco de dados se encontra no arquivo appsettings.json.

Na pasta migrations se encontram as migrações feitas para criação e ajuste do banco de dados.

