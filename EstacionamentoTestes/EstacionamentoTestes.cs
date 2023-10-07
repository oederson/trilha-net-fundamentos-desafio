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
    public void DeveCadastrarUmVeiculo()
    {
        // Arrange
        string entradaSimulada = "DSA1234\n";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        string resultadoE = "Veiculo cadastrado com sucesso!";
        
        // Act       
        Console.SetIn(new StringReader(entradaSimulada));
        _es.AdicionarVeiculo();
        string res = stringWriter.ToString();
        Console.SetOut(Console.Out);

        // Assert
        Assert.Contains(resultadoE, res);
    }
    [Fact]
    public void NaoDeveCadastrarUmVeiculoComPlacaInvalida()
    {
        // Arrange
        string entradaSimulada = "ADSA1234\n"; //Placa com 4 letras nao deve poder ser cadastrada
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        string resultadoE = "Veiculo já cadastrado, ou placa inválida!";
        
        // Act       
        Console.SetIn(new StringReader(entradaSimulada));
        _es.AdicionarVeiculo();
        string ress = stringWriter.ToString();
        Console.SetOut(Console.Out);

        // Assert
        Assert.Contains(resultadoE, ress);
    }
    [Fact]
    public void DeveListarVeiculoCadastrado()
    {
        // Arrange
        string placaSimulada = "VBN9876\n";
        string entradaListarVeiculo = "3\n";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        string resultadoE = $"Os veículos estacionados são:\n{placaSimulada}";
        
        // Act       
        Console.SetIn(new StringReader(placaSimulada));
        _es.AdicionarVeiculo();
        Console.SetIn(new StringReader(entradaListarVeiculo));
        _es.ListarVeiculos();
        string res = stringWriter.ToString();
        Console.SetOut(Console.Out);

        // Assert
        Assert.Contains(resultadoE, res);
    }

    [Fact]
    public void DeveTestarSeAPlacaEValida()
    {
        //Arrange
        string placa1 = "ABC1234";
        //Act
        bool resultado = _es.ValidarPlaca(placa1);
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
        string resultadoEsperado = "Pressione uma tecla para continuar";

        // Act
        Console.SetIn(new StringReader(entradaSimulada));
        menu.ExibirMenu();
        string resultado = stringWriter.ToString();// Captura o conteúdo da saída do console em uma variável string.
        Console.SetOut(Console.Out);// Restaura a saída padrão do console.

        // Assert
        Assert.Contains(resultadoEsperado, resultado);
    }
    [Fact]
    public void DeveRemoverUmVeiculo()
    {
        //Arrange
        decimal precoInicial = 5;
        decimal precoPorHora = 2;
        Estacionamento est = new Estacionamento(precoInicial, precoPorHora);
        string placa = "GHJ5678";
        string entradaSimulada = $"{placa}\n";
        string entradaRemoverVeiculo = $"{placa}\n4\n";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        string resultadoE = $"O veículo {placa} foi removido e o preço total foi de: R$ 13";
        
        // Act       
        Console.SetIn(new StringReader(entradaSimulada));
        est.AdicionarVeiculo();
        Console.SetIn(new StringReader(entradaRemoverVeiculo));
        est.RemoverVeiculo();
        string res = stringWriter.ToString();
        Console.SetOut(Console.Out);

        // Assert
        Assert.Contains(resultadoE, res);
    }
    
}