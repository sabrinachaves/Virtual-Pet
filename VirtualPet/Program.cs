using RestSharp;
using System.Text;
using System.Text.Json;
using VirtualPet.Models;

Console.WriteLine("Seja bem-vindo ao Virtual Pet!\n");
string chosenPokemon = "";
Menu();

void Menu()
{
    Console.WriteLine("Os pokemons disponíves são:\n");
    Console.WriteLine("1 - Bulbasaur\n" +
        "2 - Ivysaur\n" +
        "3 - Venusaur\n" +
        "4 - Goldeen\n" +
        "5 - Seadra\n");

    Console.WriteLine("Escolha um pokemon através do respectivo número: ");
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

void AuxMenu()
{
    int option2 = 0;

    while (option2 != 1 && option2 != 2)
    {
        Console.WriteLine("\nO que deseja fazer agora?" +
        "\n1 - Adotar este pokemon;" +
        "\n2 - Voltar ao menu inicial.");

        option2 = Int32.Parse(Console.ReadLine());
    }



    switch (option2)
    {
        case 1:
            Console.WriteLine($"\nParabéns! Você adotou o pokemon!");
            break;
        case 2:
            Menu();
            break;
        default:
            Console.WriteLine("Escolha uma opção válida!");
            break;
    }
}


Console.ReadKey();