Este projeto foi desenvolvido na linguagem C#, utilizando o .NET CORE no framework 5.0, com a IDE Visual Studio 2022.

O projeto se trata de uma API emulada pelo Swagger para facilitar os testes e usabilidade. Simula um sistema que mostra os restaurantes abertos em relação ao horário informado pelo usuário. Existem 2 métodos criados por essa API.

Método POST: Lê o arquivo baseado no caminho informado no parâmetro, e monta uma lista de restaurantes.

Método GET: Filtra a lista baseado no horário informado pelo usuário, exibindo apenas aqueles que estão com o horário de abertura dentro do mesmo.

Passo a passo de utilização: 
-Abra a solution do projeto e execute-o com o IIS Express dentro do Visual Studio (recomenda-se a versão 2022, visto que foi a utilizada no desenvolvimento)

-Uma vez que o swagger estiver aberto, irão aparecer os dois métodos. Primeiramente, copie e cole o caminho do arquivo contendo a lista de restaurantes que se encontra na raiz do projeto (arquivo restaurant-hours.csv, exemplo: C:\Users\usuario\Downloads\restaurant-hours.csv) no método POST. Você deverá receber uma mensagem informando que os restaurantes foram cadastrados com sucesso.

-Após isso, no método GET, insira o horário que deseja verificar quais restaurantes da lista estão abertos, no formato (HH:mm). Você receberá uma string contendo a lista de restaurantes, ou então uma mensagem informando que não há restaurantes abertos.

OBS: Para realizar os testes unitários, deve-se mudar o tipo dos métodos chamados para estático na classe de controllers.