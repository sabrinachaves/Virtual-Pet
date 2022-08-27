using RestSharp;
using System.Text;
using System.Text.Json;
using VirtualPet;


Console.WriteLine("1 - Bulbasaur\n" +
    "2 - Ivysaur\n" +
    "3 - Venusaur\n" +
    "4 - Goldeen\n" +
    "5 - Seadra\n");

int option = Int32.Parse(Console.ReadLine());
string chosenPokemon = "";

if (option == 1)
    chosenPokemon = "bulbasaur";
else if (option == 2)
    chosenPokemon = "ivysaur";
else if (option == 3)
    chosenPokemon = "venusaur";
else if (option == 4)
    chosenPokemon = "goldeen";
else if (option == 5)
    chosenPokemon = "seadra";
else if (option == 6)
    chosenPokemon = "erro";

Console.WriteLine($"O pokemon escolhido foi {chosenPokemon}");

var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPokemon}");
var request = new RestRequest("", Method.Get);

var response = client.Execute(request);

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);
    Console.WriteLine(pokemon.url);
}
    // Console.WriteLine(response.Content);
    
else
    Console.WriteLine(response.ErrorMessage);

//Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content); 



Console.ReadKey();