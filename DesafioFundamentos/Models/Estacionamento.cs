using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento()
        {
            
        }

        public Estacionamento(decimal precoInicial = 0, decimal precoPorHora = 0)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Para a placa ser válida deve conter 3 letras e 3 números, ex: ABC1234");
            Console.ResetColor();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine(); // Lê a placa digitada pelo usuário
            bool placaAprovada = ValidarPlaca(placa) && !veiculos.Contains(placa);
            if(placaAprovada)
            {
                veiculos.Add(placa);   
                Console.WriteLine("Veiculo cadastrado com sucesso!");
            }     
            else
            {      
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Veiculo já cadastrado, ou placa inválida!");
                Console.ResetColor();
            }
        }
        public bool ValidarPlaca(string placa)
        {            
            string pattern = @"^[A-Z]{3}\d{4}$";
            return Regex.IsMatch(placa, pattern);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                decimal valorTotal = 0;
                string inputHoras = Console.ReadLine();
                if (int.TryParse(inputHoras, out int horas))
                    {
                        valorTotal = precoInicial + precoPorHora * horas;

                        // Remover a placa digitada da lista de veículos
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                else
                    {
                        Console.WriteLine("Entrada inválida. Certifique-se de digitar um número inteiro para a quantidade de horas.");
                    }
                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
            
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
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
    }
}
