using System;
using System.Collections.Generic;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Nenhum veículo adicionado.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu no estacionamento:");
                if (decimal.TryParse(Console.ReadLine(), out decimal horas))
                {
                    decimal valorTotal = CalcularValorEstacionamento(horas);
                    Console.WriteLine($"Valor a pagar pelo veículo com placa {placa}: R$ {valorTotal}");
                    veiculos.Remove(placa);
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Remoção cancelada.");
                }
            }
            else
            {
                Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private decimal CalcularValorEstacionamento(decimal horas)
        {
            return precoInicial + (precoPorHora * horas);
        }
    }
}
