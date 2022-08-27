using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;
using VirtualPet.Models;

namespace VirtualPet
{
    public class MainMenu
    {
        
        string chosenPokemon = "";
        string name = "";
        
        public void Start()
        {
            Console.WriteLine("Seja bem-vindo ao Virtual Pet!\n" +
                "\nComo você se chama?");
            name = Console.ReadLine();
        }

        public void Main()
        {
            Console.WriteLine($"\n\n-----------------------------------------MENU------------------------------------------");
            Console.WriteLine($"{name}, o que você deseja fazer?");

            int option;

            do
            {
                Console.WriteLine("1 - Adotar um mascote;\n" +
                "2 - Ver seus mascotes;\n" +
                "3 - Sair");
                option = Int32.Parse(Console.ReadLine());
            } while (option < 1 || option > 3);

                switch (option)
            {
                case 1:
                    Menu();
                    break;
                case 2:
                    Console.WriteLine("Seus mascotes são: 'Em construção....'");
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Você escolheu uma opção inválida!");
                   break;
            }
        }
        public void Menu()
        {
            Console.WriteLine($"\n\n------------------------------------MASCOTES DISPÓNÍVEIS-------------------------------------");
            Console.WriteLine("Escolha um pokemon através do respectivo número:\n");
            Console.WriteLine("1 - Bulbasaur\n" +
                "2 - Ivysaur\n" +
                "3 - Venusaur\n" +
                "4 - Goldeen\n" +
                "5 - Seadra\n");
            int option = Int32.Parse(Console.ReadLine());


            switch (option)
            {
                case 1:
                    chosenPokemon = "bulbasaur";
                    feature();
                    break;
                case 2:
                    chosenPokemon = "ivysaur";
                    feature();
                    break;
                case 3:
                    chosenPokemon = "venusaur";
                    feature();
                    break;
                case 4:
                    chosenPokemon = "goldeen";
                    feature();
                    break;
                case 5:
                    chosenPokemon = "seadra";
                    feature();
                    break;
                default:
                    Console.WriteLine("Você escolheu uma opção inválida. Escolha novamente!");
                    Menu();
                    break;
            }

            void feature()
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon}");
                var request = new RestRequest("", Method.Get);

                var response = client.Execute(request);

                Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine($"\n\n-----------------------------------INFO DOS MASCOTES------------------------------------");
                    Console.WriteLine($"Nome do pokemon: {pokemon.name}");
                    Console.WriteLine($"Altura: {pokemon.height}");
                    Console.WriteLine($"Peso: {pokemon.weight}");
                    Console.WriteLine($"Habilidades:");
                    pokemon.abilities.ForEach(abil => Console.WriteLine(abil.ability.name));
                    AuxMenu();
                }
                else
                {
                    Console.WriteLine(response.ErrorMessage);
                }
            }
        }

        public void AuxMenu()
        {
            int option = 0;


            do
            {
                Console.WriteLine($"\n\n--------------------------------------------------------------------------------------------");
                Console.WriteLine($"\n{name}, o que deseja fazer agora?" +
                "\n1 - Adotar este pokemon;" +
                "\n2 - Voltar a lista de mascotes;" +
                "\n3 - Voltar ao menu inicial;" +
                "\n4 - Sair.");

                option = Int32.Parse(Console.ReadLine());
            } while (option < 1 || option > 4);



                switch (option)
            {
                case 1:
                    Console.WriteLine($"\nParabéns, {name}! Você adotou um mascote!!! O ovo está chocando...");
                    break;
                case 2:
                    Menu();
                    break;
                case 3:
                    Main();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }
        }
    }
}
