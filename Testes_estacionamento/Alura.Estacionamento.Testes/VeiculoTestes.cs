using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // Padr�o AAA

            // Arrange (Prepara��o do cen�rio)
            var veiculo = new Veiculo();
            // Act
            veiculo.Acelerar(10);
            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual); // Testa em tempo de execu��o, passando valor esperado e destino



        }

        [Fact]

        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Frear(2);
            // Assert
            Assert.Equal(-30, veiculo.VelocidadeAtual);



        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
