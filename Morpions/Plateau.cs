using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpions
{
    public class Plateau
    {
        public const int cote = 3 ;

        public Plateau()
        {
            this.Jeu = new Carre[cote*cote];

            for (int i = 0; i < cote*cote; i++)
            {
                this.Jeu[i] = new Carre(); 
            }
        }

        public bool Jouer(Carre carre, byte action, Etat etat)
        {
            return carre.Cocher(etat, action); 
        }

        public Carre[] Jeu { get; private set; }

    }
}
