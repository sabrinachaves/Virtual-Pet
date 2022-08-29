using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VirtualPet.Views;
using VirtualPet.Models;
using RestSharp;

namespace VirtualPet.Controllers
{
    public class PetController
    {
        string chosenPokemon = "";
        private MainView Menus { get; set; }
        public PetController()
        {
            this.Menus = new MainView();
        }

        public void MainMenu()
        {
            int option;
            do
            {
                Menus.MainMenu();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 3);

            switch (option)
            {
                case 1:
                    PetMenu();
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

        void PetMenu()
        {
            int option;

            do
            {
                Menus.PetMenu();
                option = int.Parse(Console.ReadLine());
            }while(option < 1 || option > 5);

            switch (option)
            {
                case 1:
                    chosenPokemon = "bulbasaur";
                    AdoptionMenu();
                    break;
                case 2:
                    chosenPokemon = "ivysaur";
                    AdoptionMenu();
                    break;
                case 3:
                    chosenPokemon = "venusaur";
                    AdoptionMenu();
                    break;
                case 4:
                    chosenPokemon = "goldeen";
                    AdoptionMenu();
                    break;
                case 5:
                    chosenPokemon = "seadra";
                    AdoptionMenu();
                    break;
                default:
                    Console.WriteLine("Você escolheu uma opção inválida. Escolha novamente!");
                    PetMenu();
                    break;
            }
        }

        void AdoptionMenu()
        {
            int option;

            do
            {
                Menus.AdoptionMenu();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 3);

            switch (option)
            {
                case 1:
                    Feature();
                    break;
                case 2:
                    Console.WriteLine($"\nParabéns! Você adotou um mascote!!! O ovo está chocando...");
                    break;
                case 3:
                    MainMenu();
                    break;
            }
        }

        void Feature()
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

        void AuxMenu()
        {
            int option;

            do
            {
                Menus.AuxMenu();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 5);

            switch (option)
            {
                case 1:
                    Console.WriteLine($"\nParabéns! Você adotou um mascote!!! O ovo está chocando...");
                    break;
                case 2:
                    PetMenu();
                    break;
                case 3:
                    MainMenu();
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
