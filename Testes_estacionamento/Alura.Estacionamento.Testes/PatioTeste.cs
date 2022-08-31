using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        [Fact]

        void ValidaFaturamento()
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo("Tiago Lima");
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-1989";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Jorge Almeida", "FDE-1991", "Preto", "Palio")] //Anotação que permite passar vários valores para o mesmo teste
        [InlineData("Lucas Almeida", "PDM-1991", "Prata", "Gol")]
        [InlineData("Mauricio Almeida", "ADF-1991", "Azul", "Celta")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo(proprietario);
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Adriano Souza","YUP-8976","Vermelho","HB20")]

        public void LocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo(proprietario);
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]

        public void AlterarDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Cor = "Prata";
            veiculo.Modelo = "Uno";
            veiculo.Placa = "PQP-7777";
            veiculo.Proprietario = "Maria do Carmo";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Cor = "Cinza"; // Alterado
            veiculoAlterado.Modelo = "Uno";
            veiculoAlterado.Placa = "PQP-7777";
            veiculoAlterado.Proprietario = "Maria do Carmo";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculo, veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculo.Cor);
        }
    }
}
