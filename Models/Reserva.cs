using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        // Lista de hóspedes da reserva: Defini as propriedades como privadas.
        public List<Pessoa> Hospedes { get; private set; } = new();

        // Suite associada a reserva
        public Suite Suite { get; private set; }

        // Quantidade de dias reservados.
        public int DiasReservados { get; private set; }

        // Inclui a Data e hora da reserva
        public DateTime DataReserva { get; private set; } = DateTime.Now;

        // Inicializa a data da reserva com a data atual
        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
                throw new ArgumentException("A quantidade de dias reservados deve ser maior que zero.");

            DiasReservados = diasReservados;

        }



        // Método para cadastrar a suíte
        public void CadastrarSuite(Suite suite)
        {
            ValidarSuite(suite);
            Suite = suite;
        }

        // Método para cadastrar hóspedes
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            //Verifica se a suíte já foi cadastrada
            if (Suite == null)
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar hóspedes.");

            if (hospedes == null || hospedes.Count == 0)
                throw new ArgumentException("A lista de hóspedes não pode estar vazia.");

            // Verifica se a quantidade de hóspedes é compatível com a capacidade da suíte
            if (hospedes.Count > Suite.Capacidade)
                throw new InvalidOperationException($"A quantidade de hóspedes ({hospedes.Count}) execede a capacidade da suíte ({Suite.Capacidade}).");

            Hospedes = hospedes;
        }

        // Retorna a quantidade de hópedes na reserva
        public int ObterQuantidadeHospedes() => Hospedes.Count;

        public decimal CalcularValorDiaria()
        {   //Verifica se a suíte está cadastrada.
            if (Suite == null)
                throw new InvalidOperationException("A suíte deve estar cadastrada para calcular o valor da diária.");

            //Calcula o valor sem o desconto
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
                valor *= 0.9M; // Aplica 10% de desconto.

            return valor;

        }

        //Faz as validações da suíte.
        private void ValidarSuite(Suite suite)
        {
            if (suite == null)
                throw new ArgumentNullException("A suíte não pode ser nula.");

            if (suite.Capacidade <= 0)
                throw new ArgumentException("Acapacidade da suíte deve ser maior que zero.");

            if (suite.ValorDiaria <= 0)
                throw new ArgumentException("O valor da diária deve ser maior que zero.");

        }
        
    }
}