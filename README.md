# Gerador e Verificador de Matrículas

A solução foi desenvolvida utilizando 3 camadas, sendo elas:

| Camada         |           Tipo |
| -------------- | -------------- |
| Apresentação   | Console        |
| Domínio        | ClassLibrary   |
| Infraestrutura | ClassLibrary   |
|                |                |

## Descrição da Solução
Neste projeto foi utilizada uma aplicação de console feita com o framework multiplataforma **.Net Core**, utilizando sua versão 2.0.
Foi criada uma camada de domínio que pode ser enxergada pelas camadas de apresentação e de persistência.
Desacoplando e permitindo que qualquer tipo de persistência ou front end possa ser utilizada na solução.
Foram implementadas os padrões Unit Of Work e Repository para realizar a persistência de uma forma levemente modificada para se adequar a situação.
Na camada de apresentação apenas tentei realizar uma escolha simples sobre salvar uma opção ou outra, onde após escolher é passada via parâmetro uma constante que possui o nome do arquivo que deve ser lido e o nome do arquivo novo que será salvo.

### Utilização

Para utilizar use o powershell e navegue até a pasta onde os arquivos foram extraídos.

#### Requisitos necessário 
* **.Net Core 2.0**

##### Passos

1. <code></code><code>PS C:\> dotnet restore </code><code></code>
2. <code></code><code>PS C:\> dotnet run </code><code></code>
3. Escolha a opção "1" para gerar um arquivo com as matrículas verificadas no Desktop.
4. Escolha a opção 2 para gerar um arquivo de matrículas com dígito verificador no Desktop.
5. Após ambas opções pode se escolher se volta para o menu principal ou sai do programa.
