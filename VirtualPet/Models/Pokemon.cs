using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPet.Models
{
    public class Pokemon
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<Ability> abilities { get; set; }

        public int hungry = new Random().Next(1, 10);
        public int atention = new Random().Next(1, 10);
        public int intelligence = new Random().Next(1, 10);
        public int hygiene = new Random().Next(1, 10);
        public int mood = new Random().Next(1, 10);
        public int fitness = new Random().Next(1, 10);
        public bool lifeStatus = true;

        

        public void Status()
        {
            Console.WriteLine($"\n\n-----------------------------------------STATUS DO PET-----------------------------------------------");
            Console.WriteLine($"\n\nNome: {name}\n" +
                $"Altura: {height}\n" +
                $"Peso: {weight}\n" +
                $"Habilidades: ");
            this.abilities.ForEach(abil => Console.WriteLine(abil.ability.name));
            Console.WriteLine($"\n\nFome: {hungry}\n" +
                $"Atenção: {atention}\n" +
                $"Inteligência: {intelligence}\n" +
                $"Higiene: {hygiene}\n" +
                $"Humor: {mood}\n" +
                $"Exercícios: {fitness}");
        }

        public void Feed()
        {
            hungry++;
            weight++;
            fitness--;
            mood++;
        }

        public void Kindness()
        {
            atention++;
            mood++;
        }

        public void Study()
        {
            mood--;
            intelligence++;
            hungry--;
        }

        public void Workout()
        {
            hungry--;
            weight--;
            mood--;
            hygiene--;
            atention++;
            fitness++;
        }

        public void Clean()
        {
            hygiene++;
            mood++;
            atention++;
        }

        public bool LifeStatus
        {
            get
            {
                return lifeStatus;
            }
            set
            {
                if (hungry == 0 || atention == 0 || intelligence == 0 || hygiene == 0 || mood == 0)
                {
                    lifeStatus = false;
                }
                else
                    lifeStatus = true;
            }
        }
    }
}
