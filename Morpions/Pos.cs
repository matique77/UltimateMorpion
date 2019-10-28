using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpions
{
    public struct Pos
    {
        private readonly int posX;
        private readonly int posY;

        public Pos(int x, int y)
        {
            this.posX = x;
            this.posY = y;
        }

        public int PosX => posX;

        public int PosY => posY;

        public static Pos operator +(Pos gauche, Pos droite)
        {
            return new Pos(gauche.PosX + droite.PosX, gauche.PosY + droite.PosY);
        }

     
        public static bool operator ==(Pos gauche, Pos droite)
        {
            return Equals(gauche, droite);
        }

        public static bool operator !=(Pos gauche, Pos droite)
        {
            return !(gauche == droite);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Pos position = (Pos)obj;
            return position.PosX == this.PosX &&
                    position.PosY == this.PosY;
        }
    }
}
