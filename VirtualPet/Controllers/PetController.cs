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
        Pokemon adoptedPokemon = new Pokemon();

        private PetView Menus { get; set; }
        public List<Pokemon> AdoptedPets { get; set; }
        public PetController()
        {
            this.Menus = new PetView();
            this.AdoptedPets = new List<Pokemon>();
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
                    Console.WriteLine("Seus mascotes são: ");
                    AdoptedPets.ForEach(pet => Console.WriteLine(pet.name));
                    InfoPet();
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
                    AdoptPet();
                    AdoptedPets.Add(adoptedPokemon);
                    MainMenu();
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
                Console.WriteLine($"\n\n-----------------------------------INFO DO MASCOTE------------------------------------");
                Console.WriteLine($"Nome do pokemon: {pokemon.name}");
                Console.WriteLine($"Altura: {pokemon.height}");
                Console.WriteLine($"Peso: {pokemon.weight}");
                Console.WriteLine($"Habilidades:");
                pokemon.abilities.ForEach(abil => Console.WriteLine(abil.ability.name));
                adoptedPokemon = pokemon;
                AuxMenu();
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        void AdoptPet()
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon}");
            var request = new RestRequest("", Method.Get);

            var response = client.Execute(request);

            Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);
            adoptedPokemon = pokemon;
        }

        void AuxMenu()
        {
            int option;

            do
            {
                Menus.AuxMenu();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 4);

            switch (option)
            {
                case 1:
                    Console.WriteLine($"\nParabéns! Você adotou um mascote!!! O ovo está chocando...");
                    AdoptPet();
                    AdoptedPets.Add(adoptedPokemon);
                    MainMenu();
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

        public void InfoPet()
        {
            int option;
            do
            {
                Menus.InfoPet();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 4);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o nome do pet que gostaria de visualizar: ");
                    string petName = Console.ReadLine();
                    AdoptedPets.Find(pet => pet.name == petName).Status();
                    InfoPet();
                    break;
                case 2:
                    Console.WriteLine("Digite o nome do pet que gostaria de brincar: ");
                    string pokemonName = Console.ReadLine();
                    PlayWithPet(pokemonName);
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        public void PlayWithPet(string name)
        {
            int option;
            do
            {
                Menus.PlayWithPet();
                option = int.Parse(Console.ReadLine());
            } while (option < 1 || option > 7);

            switch (option)
            {
                case 1:
                    AdoptedPets.Find(pet => pet.name == name).Feed();
                    AdoptedPets.Find(pet => pet.name == name).Status();
                    PlayWithPet(name);
                    break;
                case 2:
                    AdoptedPets.Find(pet => pet.name == name).Kindness();
                    AdoptedPets.Find(pet => pet.name == name).Status();
                    PlayWithPet(name);
                    break;
                case 3:
                    AdoptedPets.Find(pet => pet.name == name).Workout();
                    AdoptedPets.Find(pet => pet.name == name).Status();
                    PlayWithPet(name);
                    break;
                case 4:
                    AdoptedPets.Find(pet => pet.name == name).Study();
                    AdoptedPets.Find(pet => pet.name == name).Status();
                    PlayWithPet(name);
                    break;
                case 5:
                    AdoptedPets.Find(pet => pet.name == name).Clean();
                    AdoptedPets.Find(pet => pet.name == name).Status();
                    PlayWithPet(name);
                    break;
                case 6:
                    MainMenu();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
        }
        
    }
}
