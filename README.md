# Desafio Dell Academy
## Galactic Converter
### Descrição
Você decidiu abandonar o planeta Terra de vez, após o último colapso ecológico do
planeta. Com os recursos que você possui, você pode comprar uma nave espacial,
deixar a Terra e voar por toda a galáxia para vender metais de vários tipos.
Comprar e vender por toda a galáxia exige que você converta números e unidades, logo
**você decidiu escrever um programa para ajudá-lo**.
Os números usados nas transações intergalácticas seguem convenção similar à dos
numerais romanos, e devem ser traduzidos para que as transações possam se realizar.

As entradas para o seu programa consistem de linhas de texto em um arquivo texto
detalhando as suas anotações sobre a conversão entre unidades intergalácticas e
numerais romanos. Você deve lidar com anotações inválidas de forma apropriada e gerar
a saída na tela.
Como se pode ver abaixo, as entradas podem ter até 7 linhas iniciais indicando a notação
intergaláctica dos símbolos romanos, seguida de 0 ou mais linhas indicando o valor em
créditos do número de unidades (expresso em intergaláctico) de metal sendo vendido.
Na sequência, linhas com perguntas “quanto vale” / ”quantos créditos são”. Na última
linha, um exemplo do que deve acontecer com uma anotação inválida.

**Desenvolva o programa que processa estas entradas e gera estas saídas.**

### Exemplos
#### Entrada
![Exemplo de entrada](/imgs/exemplo_entrada.png)
#### Saída
![Exemplo de saida](/imgs/exemplo_saida.png)

### Requerimentos do Sistema
Como o programa é um .NET Core Console Application, talvez seja necessário instalá-lo, para isso basta clicar [aqui](https://microsoft.com/net/core), escolher seu sistema operacional, baixar e instalar (Next, Next, Finish). Para confirmar o sucesso da instalação, basta entrar no terminal e digitar <code>dotnet --info</code> (Talvez seja necessário reiniciar o sistema). Se o .NET Core SDK foi instalado corretamente, será exibido informações sobre o mesmo.

Qualquer dificuldade, favor enviar e-mail para ceschini@protonmail.com

### Executando
Para executar o programa, basta abrir o terminal, navegar até a pasta do programa e digitar <code>dotnet run</code>.

### Modificando Entradas
O programa está lendo o arquivo entry.txt presente no diretório raiz. Para testar outros valores de entrada, basta modificar as linhas deste arquivo, salvá-lo e rodar o programa novamente. Lembrando que a sintaxe deve ser mantida, as palavras *"representa", "valem", "quanto vale" e "quantos créditos são"* definem como o programa irá obter as informações e que perguntas responder.

#### Disclaimer
O exemplo de entrada acima está com um espaço antes do **?**, infelizmente ao transcrever para um arquivo .txt, acabei colocando o **?** junto, o que mudou totalmente minha lógica e acabou fazendo as entradas padrões acima não funcionarem 100%. Por isso, por favor manter essa nomenclatura ao editar as entradas.

**Como está no exemplo:** quanto vale squid leij snob snob ?

**Como está no entry.txt:** quanto vale squid leij snob snob?
