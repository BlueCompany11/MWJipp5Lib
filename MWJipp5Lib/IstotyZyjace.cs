using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWJipp5Lib
{
    public abstract class IstotaZyjaca  //abstract class nie da sie utworzyc jej instancji
    {
        public int Wiek { get; set; }
        protected abstract int Odpornosc { get; } //abstrakcyjna wlasciwosc - wymuszamy podanie wartosci pola w klasach potomnych
        public abstract void PoruszSie();   //abstract wymusza implementacje metody w klasie potomnej
        
        public event Action Choroba;
        public void PrzezyjRok()
        {
            Random rnd = new Random();
            int prob = rnd.Next(1, 10)% Odpornosc;
            if (prob == 0)
            {
                if (!Szczescie())
                {
                    Choroba?.Invoke();
                }
                else
                {
                    Console.WriteLine("Szczescie dopisalo");
                }
            }
            else
            {
                Console.WriteLine("Szczescie nie musialo Ci dopisywac");
            }
        }
        public virtual bool Szczescie()
        {
            Random rnd = new Random();
            int prob = rnd.Next(1, 10) % 2;
            return prob == 0;
        }
    }

    public class Czlowiek : IstotaZyjaca
    {
        protected override int Odpornosc => 3;
        
        public override void PoruszSie()
        {
            Console.WriteLine("Ruszam sie jak czlowiek");
        }
    }
    public class Pies : IstotaZyjaca
    {
        protected override int Odpornosc => 2;

        public override void PoruszSie()
        {
            Console.WriteLine("Ruszam sie jak pies");
        }

        public override bool Szczescie()
        {
            return base.Szczescie() || base.Szczescie();
        }

    }
}
