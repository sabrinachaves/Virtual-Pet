using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Text.Json;
using VirtualPet.Models;

namespace VirtualPet.Views
{
    public class MainView
    {
        string name = "";

        public MainView()
        {
            Start();
        }
        public void Start()
        {
            Console.WriteLine("Seja bem-vindo ao Virtual Pet!\n" +
                "\nComo você se chama?");
            name = Console.ReadLine();
        }

        public void MainMenu()
        {
            Console.WriteLine($"\n\n-----------------------------------------MENU------------------------------------------");
            Console.WriteLine($"{name}, o que você deseja fazer?");
                Console.WriteLine("1 - Adotar um mascote;\n" +
                "2 - Ver seus mascotes;\n" +
                "3 - Sair");
        }
        public void PetMenu()
        {
            Console.WriteLine($"\n\n------------------------------------MASCOTES DISPÓNÍVEIS-------------------------------------");
            Console.WriteLine("Escolha um pokemon através do respectivo número:\n");
            Console.WriteLine("1 - Bulbasaur\n" +
                "2 - Ivysaur\n" +
                "3 - Venusaur\n" +
                "4 - Goldeen\n" +
                "5 - Seadra\n");
        }

        public void AdoptionMenu()
        {
            Console.WriteLine($"\n\n-----------------------------------------MENU DE ADOÇÃO-----------------------------------------------");
                Console.WriteLine($"\n{name}, o que deseja fazer?" +
                "\n1 - Ver as infos do pokemon;" +
                "\n2 - Adotar este pokemon;" +
                "\n3 - Voltar ao menu inicial.");
        }

        public void AuxMenu()
        {
                Console.WriteLine($"\n\n--------------------------------------------------------------------------------------------");
                Console.WriteLine($"\n{name}, o que deseja fazer agora?" +
                "\n1 - Adotar este pokemon;" +
                "\n2 - Voltar a lista de mascotes;" +
                "\n3 - Voltar ao menu inicial;" +
                "\n4 - Sair.");
        }
    }
}
