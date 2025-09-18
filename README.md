# Projeto_Estoque

1 - Programas Utilizados:

    VisualStudio Code para sua codificação com a extensão
C# e .NET Install Tool, não foi utilizado C# DevKit por
ser uma extensão paga.

    .NET 9.0 .

    MySql WorkBench 8.0 .

2 - Configuração:

    Instalação dos seguintes programas atráves de suas plataformas oficiais:

        VS Code <https://code.visualstudio.com/docs/?dv=win64user>

        .NET <https://dotnet.microsoft.com/pt-br/download>

        MySql <https://dev.mysql.com/downloads/installer/> (utilizado versão local e não web)


    Para configuração do banco de dados foi utilizado MySql na sua versão mais recente 
permitindo não ser mais necessário a utilização do Xamp para ter acesso ao banco pois 
a nova versão já possui um inicializador do MySql Server para o windows, na criação dos
bancos foi utilizado um banco com nome "projeto_estoque" para criação das tabelas usando
o seguinte código:

        CREATE TABLE medidas (
        id PRIMARY KEY INT NOT NULL,
        tamanho VARCHAR(150) NOT NULL,
        PRIMARY KEY (id)
        );

        CREATE TABLE produtos (
        id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
        nome VARCHAR(150) NOT NULL,
        medidaid INT NOT NULL,
        preco INT NOT NULL,
        quantidade INT NOT NULL,
        constraint medida FOREIGN KEY (medidaid) REFERENCES medidas (id)
        );

    Código para inserção de dados em medidas:

        INSERT INTO medidas (id, tamanho) VALUES (1, 17), (2, 23);


    Foi utilizado as seguintes linhas de comandos para o início do projeto:

        dotnet new mvc -n Projeto_Estoque

    Instalando as dependencias para conexão ao banco via linha de comando:

        dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        dotnet add package Microsoft.EntityFrameworkCore.Tools

    Dependencia do "codegenerator" para criação das views através da linha de comando:

        dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

    Criação das Views utilizando codegenerator através da linha de comando:

        dotnet aspnet-codegenerator view Index Empty -outDir Views/Produtos --model Projeto_Estoque.Models.Produtos
        dotnet aspnet-codegenerator view Create Create -outDir Views/Produtos --model Projeto_Estoque.Models.Produtos
        dotnet aspnet-codegenerator view Edit Edit -outDir Views/Produtos --model Projeto_Estoque.Models.Produtos
        dotnet aspnet-codegenerator view Details Details -outDir Views/Produtos --model Projeto_Estoque.Models.Produtos
        dotnet aspnet-codegenerator view Delete Delete -outDir Views/Produtos --model Projeto_Estoque.Models.Produtos

3 - Considerações Finais:

    Esse projeto se demonstrou simples no início principalmente
por se parecer muito com o java, porém de acordo que o projeto 
continuava a se desenvolver comecei a reparar que deixei a experiência
passada sobrescrever a documentação do C# alterando nomeclaturas como
a "context/__context" para conexão ao banco de dados e apagando a "views/home"
para tentar acessar as views que criei achando que esse era o problema, admito
que nesse projeto meu erro foi começar a consulta o copilot e gemini (com o
gemini sendo mais difícil de ser evitado por estar atrelado ao pesquisar do google)
por eles darem fragmentos de códigos o qual apenas geraram conflito de lógica com o
código já existente e tutorias do youtube sempre faltando a instalação das dependências
externas de arquivos ou programas.
    Com isso dito tomarei este Teste Técnico como experiência e uma abertura para conhecer
esta nova linguagem do básico até um possível nível avançado. 
