using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable // Implementando Interface para realizar o CLEAN UP
    {
        private Veiculo veiculo; // Conceito de SETUP, pra instanciar os objetos utlizados pelo método como uma variável global
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes( ITestOutputHelper _saidaConsoleTeste) // Injeção de dependência de uma interface com método que permite imprimir uma mensagem no console
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");

            veiculo = new Veiculo();
        }

        [Fact] 
        [Trait("Funcionalidade","Acelerar")] // Trait agrupa os testes utilizando parâmetros "Chave","Valor"
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Padrão AAA

            // Arrange (Preparação do cenário)
            //var veiculo = new Veiculo();
            // Act
            veiculo.Acelerar(10);
            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual); // Testa em tempo de execução, passando valor esperado e destino



        }

        [Fact ]
        [Trait("Funcionalidade","Frear")]

        public void TestaVeiculoFrearComParametro2()
        {
            // Arrange
            //var veiculo = new Veiculo();
            // Act
            veiculo.Frear(2);
            // Assert
            Assert.Equal(-30, veiculo.VelocidadeAtual);



        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (Skip ="Teste ainda não implementado. Ignorar")]

        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]

        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var carro = new Veiculo();
            veiculo.Proprietario = "Marcos Telles";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "PQR-6543";
            veiculo.Cor = "Marrom";
            veiculo.Modelo = "Belina";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo:", dados);

        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDe3Caracteres() //Testando Exceções
        {
            //Arrange
            string nomeProprietario = "AB";

            //Assert
            Assert.Throws<System.FormatException>(
                
                //Act
                () => new Veiculo(nomeProprietario)
                
                );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaracterDaPlaca() // Testando Exceções
        {
            //Arrange
            string placa = "HJKM9000";

            //Act
           var mensagem = Assert.Throws<FormatException>(

                () => new Veiculo().Placa = placa

                );
            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
