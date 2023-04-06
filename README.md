![Replit](https://img.shields.io/badge/Replit-DD1200?style=for-the-badge&logo=Replit&logoColor=white)![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)![Express.js](https://img.shields.io/badge/express.js-%23404d59.svg?style=for-the-badge&logo=express&logoColor=%2361DAFB)![NodeJS](https://img.shields.io/badge/node.js-6DA55F?style=for-the-badge&logo=node.js&logoColor=white)

![Anurag's GitHub stats](https://github-readme-stats.vercel.app/api?username=KoroHacking&theme=dark&show_icons=true)


# Server
- Este é um aplicativo Node.js que executa um servidor HTTP na porta 3000. Ele usa a estrutura Express.js para lidar com as solicitações recebidas e encaminhá-las para os manipuladores apropriados.

- O aplicativo tem duas rotas, uma para servir o arquivo index.html quando o caminho raiz é solicitado e a outra para lidar com conexões de clientes com um UUID especificado.

- Quando um cliente se conecta à rota '/connect' com um UUID, o aplicativo verifica se há um arquivo no diretório 'vuuid' com esse UUID e uma extensão '.koro'. Se tal arquivo existir, ele lê seu conteúdo e o envia de volta como resposta ao cliente. Se o conteúdo do arquivo corresponder a um valor armazenado na variável 'cmdCheck', o aplicativo registra uma mensagem de sucesso, redefine 'cmdCheck' para "nothing.koro" e chama a função 'cmdListener' passando o UUID como parâmetro.

- Se o arquivo com o UUID não existir, o aplicativo cria um novo arquivo com o UUID e o conteúdo "nothing.koro" e envia a resposta "OK" de volta para o cliente.

- A função 'cmdListener' escuta a entrada do usuário no console e grava a entrada no arquivo com o UUID correspondente. Se a entrada corresponder a "exit", a função retornará e, se corresponder a "clear", limpará o console e chamará a si mesma recursivamente com o mesmo UUID. Caso contrário, ele registra uma mensagem de sucesso, define 'cmdCheck' como entrada e registra uma mensagem indicando que está aguardando a vítima executar o comando.

- A função 'vListener' escuta a entrada do usuário do console para o UUID da vítima. Se a entrada corresponder a "exit", a função retornará e, se corresponder a "clear", limpará o console e chamará a si mesma recursivamente. Se existir um arquivo com o UUID no diretório 'vuuid', a função registra uma mensagem de sucesso e chama a função 'cmdListener' passando o UUID como parâmetro. Se o arquivo não existir, a função registra uma mensagem de erro e chama a si mesma recursivamente.

- Por fim, o aplicativo também lida com um erro 404 enviando um arquivo HTML personalizado como resposta.

# Features

-   [GitHub Stats Card](#github-stats-card)


