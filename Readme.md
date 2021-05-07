# Como criar templates no visual studio 2019

Autor: Pedro Pagotto

**Objetivo:**

Criar templates de código no visual studio 2019 para melhoria de produtividade.

**Introdução:**

O nosso dia a dia como dev é uma grande correria pingando de um projeto para outro, e com isso vem as copias de estruturas e de códigos existente para criar uma nova funcionalidade, basicamente copiamos o esqueleto de arquivos e depois renomearmos para ai começar a desenvolver o que realmente importa, isso é tão natural e também muito repetitivo.

Seria uma maravilha se simplesmente apenas com um clique no menu **New Item e a escolha de um arquivo o** nosso amigo **vs2019** criasse toda a estrutura para nós.

Então comemore pois esse dia chegou, neste artigo vou te ensinar como você pode melhorar a produtividade do seu dia a dia, fazendo você deixar de copiar e colar código e criar templates de projeto para facilitar o desenvolvimento de novas funcionalidades.

**Mão na massa:**

Basicamente estaremos criando um simples template um serviço onde será criado a partir de uma ção do vs2019 os arquivos:

- Interface (onde fica declarado a assinatura do metodo)
- Classe de Request (basicamente é o objeto que será enviado para este serviço)
- Classe de implementação (Onde será implementada a interface criada enviando como parametro o request).

É algo bem proximo do recurso de scaffold no ASPNET CORE MVC onde é gerado os controllers com as ações de forma atomatica.

Primeiro passo:

Crie um projeto do tipo **Console Application** para ficar mais fácil de criarmos os arquivos que envolvem a nossa automação de template.

Vou criar o projeto via vs2019, porem nada impede de ser criado via dotnet CLI.

![assets/Untitled.png](assets/Untitled.png)

![assets/Untitled%201.png](assets/Untitled%201.png)

![assets/Untitled%202.png](assets/Untitled%202.png)

![assets/Untitled%203.png](assets/Untitled%203.png)

Após o projeto estar criado, iremos realizar a seguinte ação:

![assets/Untitled%204.png](assets/Untitled%204.png)

Crie uma pasta chamada Template e dentro desta Pasta uma interface chamada IRepository

![assets/Untitled%205.png](assets/Untitled%205.png)

crie uma interface:

- Interface (pode chama-la como quiser)

![assets/Untitled%206.png](assets/Untitled%206.png)

No meu caso vou montar esta estrutura:

- IServiceTemplate.cs (interface)

Ficou desta forma:

![assets/Untitled%207.png](assets/Untitled%207.png)

![assets/Untitled%208.png](assets/Untitled%208.png)

logo após criar toda a estrutura realize a exportação como template:

navegue até a aba **Project→ Export Template:**

![assets/Untitled%209.png](assets/Untitled%209.png)

selecione a opção de Item Template

![assets/Untitled%2010.png](assets/Untitled%2010.png)

no caso selecione a interface:

![assets/Untitled%2011.png](assets/Untitled%2011.png)

caso queira pode selecionar algumas dependências, pois com isso o arquivo gerado via template já vem com essas importações por exemplo System.Linq.

![assets/Untitled%2012.png](assets/Untitled%2012.png)

Realize o preenchimento do nome do seu template e da descrição do mesmo.

No caso existe a possibilidade de colocar um icon customizado, eu não vou colocar pois não é obrigatório, mais você pode colocar o logo da empresa ou do projeto para que se destina este template.

logo após click em **Finish**

![assets/Untitled%2013.png](assets/Untitled%2013.png)

Será aberto uma pasta com um template zip conforme abaixo, realize a copia deste template para outro diretorio onde seja possivel abri-lo no VSCode ou outro editor de sua preferencia:

![assets/Untitled%2014.png](assets/Untitled%2014.png)

realize a extração da pasta e abra no vscode, note que foi gerado 3 arquivos:

- Icon (que será exibido no vs2019)
- Classe de template
- Arquivo de configuração do .vstemplate

![assets/Untitled%2015.png](assets/Untitled%2015.png)

Agora como o nosso template tem 3 arquivos iremos editar manualmente o vstemplate para aceitar os demais arquivos.

O arquivo padrão de configuração está desta forma:

![assets/Untitled%2016.png](assets/Untitled%2016.png)

Vamos editar para esse modelo:

![assets/Untitled%2017.png](assets/Untitled%2017.png)

note que existe uma variavel chamada $fileinputname$, que corresponde ao nome do arquivo digitado na criação via vs2019.

Note que você pode definir padrões de nomes de arquivos com prefixo e sufixo, tudo vai de acordo com o padrão do seu projeto.

Logo após adicionar essas linhas de configuração no VSCODE crie os metodos padrões da sua interface como por exemplo o metodo abaixo:

![assets/Untitled%2018.png](assets/Untitled%2018.png)

Criei um metodo chamado EXECUTE onde receberá um Servicerequest que será criado via template.

Crie um arquivo chamado ServiceTemplateRequest.cs (pode ser o nome que você desejar) e crie o seguinte codigo dentro deste arquivo:

![assets/Untitled%2019.png](assets/Untitled%2019.png)

Essa classe será a classe de request que será passada como parâmetro para o nosso método e para nossa interface.

Na sequencia crie um arquivo chamado ServiceTemplate.cs (pode ser o nome que você desejar), dentro desse arquivo será realizado a implementação da nossa interface conforme o exemplo abaixo:

![assets/Untitled%2020.png](assets/Untitled%2020.png)

no caso foi realizado a implementação da interface em conjunto com o metodo **Execute** que criamos anteriormente.

Após finalizar as configurações e implementações destes arquivos, agora vamos importar esse template dentro do vs2019:

[]()

Primeiramente realize o zip desses arquivos, desta forma:

![assets/Untitled%2021.png](assets/Untitled%2021.png)

![assets/Untitled%2022.png](assets/Untitled%2022.png)

O seu arquivo .zip deverá conter somente os arquivos de template conforme a print abaixo:

![assets/Untitled%2023.png](assets/Untitled%2023.png)

Agora dentro do vs2019 navegue até o caminho :

Tools→ Options

![assets/Untitled%2024.png](assets/Untitled%2024.png)

Pesquise pela palavra **Locations**, entre no menu **Projects and Solutions,** copie o caminho presente no passo 2

![assets/Untitled%2025.png](assets/Untitled%2025.png)

abra esse caminho via executar (Tecla Windows + R)

![assets/Untitled%2026.png](assets/Untitled%2026.png)

Caso já exista algum zip com o mesmo nome devido ao processo de exportação realizado anteriormente, realize a exclusão do arquivo existente e cole o arquivo que você acabou de gerar o zip.

![assets/Untitled%2027.png](assets/Untitled%2027.png)

Caso você queira manter os templates de forma organizada, você pode movimentar para a pasta Visual C# ou para as demais linguagens de sua preferência.

Agora feche o seu vs2019.

Abra novamente no projeto de console

![assets/Untitled%2028.png](assets/Untitled%2028.png)

Agora vamos testar o template, crie uma nova pasta chamada TemplateTest, para que possamos criar os arquivos dentro dela.

![assets/Untitled%2029.png](assets/Untitled%2029.png)

Logo na sequencia vá ate o menu Add → New Item

![assets/Untitled%2030.png](assets/Untitled%2030.png)

Note que o template criado já esta em primeiro, porem caso não esteja pesquise pelo nome na barra de pesquisa do lado direito.

![assets/Untitled%2031.png](assets/Untitled%2031.png)

Selecione o template e coloque o nome que desejar, eu vou criar por exemplo um serviço de CEP

![assets/Untitled%2032.png](assets/Untitled%2032.png)

Note que nao preciso colocar a extensão '.cs' e nem o prefixo ou sufixo de Service etc..

![assets/Untitled%2033.png](assets/Untitled%2033.png)

Note que a estrutura padrão de um **Service** foi criada com sucesso, agora basta você implementar a sua logica, sem se preocupar em copiar arquivos e estruturas de outros lugares.

![assets/Untitled%2034.png](assets/Untitled%2034.png)

![assets/Untitled%2035.png](assets/Untitled%2035.png)

![assets/Untitled%2036.png](assets/Untitled%2036.png)

Espero que tenha gostado desta dica, acredito que os templates vieram para agregar em nossas vidas, para focarmos no que realmente importa que é gerar valor para o nosso cliente/negocio.

Até a próxima!
