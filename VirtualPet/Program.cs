using RestSharp;
using System.Text;
using System.Text.Json;
using VirtualPet.Models;
using VirtualPet.Views;
using VirtualPet.Controllers;

PetController Start = new PetController();

Start.MainMenu();

Console.ReadKey();