using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpions;

namespace JeuSansInterface
{
    public class JeuMorpions
    {
        private Plateau plateau;

        public JeuMorpions()
        {
            this.Plateau = new Plateau();
        }

        public Plateau Plateau { get => plateau; set => plateau = value; }

        public bool Jouer(Carre carre, Etat etat, byte action)
        {
            return carre.Cocher(etat, action);
        }

    }
}
