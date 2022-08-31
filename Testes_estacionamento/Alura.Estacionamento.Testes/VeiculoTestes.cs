using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Teste N� 1")] 
        [Trait("Funcionalidade","Acelerar")] // Trait agrupa os testes utilizando par�metros "Chave","Valor"
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

        [Fact (DisplayName ="Teste N� 2")]
        [Trait("Funcionalidade","Frear")]

        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Frear(2);
            // Assert
            Assert.Equal(-30, veiculo.VelocidadeAtual);



        }

        [Fact(DisplayName ="Teste N� 3")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (DisplayName= "Teste N�4",Skip ="Teste ainda n�o implementado. Ignorar")]

        public void ValidaNomeProprietario()
        {

        }

        [Fact]

        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Marcos Telles";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "PQR-6543";
            carro.Cor = "Marrom";
            carro.Modelo = "Belina";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Tipo do Ve�culo:", dados);

        }
    }
}
