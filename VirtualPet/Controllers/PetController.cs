using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPet.Views;

namespace VirtualPet.Controllers
{
    public class PetController
    {
        public void Play()
        {
            MainMenu menu = new MainMenu();

            menu.Start();
            menu.Main();

            Console.ReadKey();
        }
    }
}
