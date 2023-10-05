using DesafioFundamentos.Models;

namespace EstacionamentoTestes;

public class EstacionamentoTestes
{
    private Estacionamento _es;

    public EstacionamentoTestes()
    {
        _es = new Estacionamento();
    }
    [Fact]
    public void DeveTestarSeAPlacaEValida()
    {
        //Arrange
        string placa = "ABC1234";
        //Act
        bool resultado = _es.ValidarPlaca(placa);
        //Assert
        Assert.True(resultado);
    }
    [Fact]
        public void MenuExibirESairCorretamente()
        {
            // Arrange
            decimal precoInicial = 10;
            decimal precoPorHora = 5;
            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);
            StringWriter stringWriter = new StringWriter();
            Menu menu = new Menu(estacionamento);
            Console.SetOut(stringWriter);
            string entradaSimulada = "4\n";// Configura a entrada simulada com "4" (para encerrar) e depois "Enter".
            Console.SetIn(new StringReader(entradaSimulada));
            string resultadoEsperado = "Pressione uma tecla para continuar";

            // Act
            menu.ExibirMenu();
            string resultado = stringWriter.ToString();// Captura o conteúdo da saída do console em uma variável string.
            Console.SetOut(Console.Out);// Restaura a saída padrão do console.

            // Assert
            Assert.Contains(resultadoEsperado, resultado);
    }
}