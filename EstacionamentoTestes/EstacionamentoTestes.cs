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
}