using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

        // Cria os modelos de hóspedes e cadastra na lista de hóspedes
        try
        {
            var hospedes = new List<Pessoa>
            {
                new("Hóspede"),
                new("Hóspede"),
                new("Hóspede"),
                new("Hóspede"),
                new("Hóspede")
            };


            // Cria a suíte
            var suite = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 20);

            // Cria uma nova reserva, passando a suíte e os hóspedes
            var reserva = new Reserva(diasReservados: 10);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total da estadia: {reserva.CalcularValorDiaria():C2}");

        }

        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

}