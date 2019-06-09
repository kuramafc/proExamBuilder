Passo a passo de como rodar o projeto.

Primeiro vc precisará do visual studio 2017 ou superior instalado no computador e também precisara do do sql server.
Com o Sql server aberto, abrir a pasta Migrations e executar o script mais recente para gerar as tabelas.
Após executar os scripts abrir o projeto no visual studio.
Com o projeto aberto verificar o arquivo appsettings.json no nó DefaultConnection se está apontando para o banco local e se o usuario e a senha do banco local estão corretos.

Após efetuar os passos anteriores executar o projeto.
Se tudo der certo ele abrirá uma página com os endpoints no swagger