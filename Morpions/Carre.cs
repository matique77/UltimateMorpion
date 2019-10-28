using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpions
{

    enum EtatLigne
    {
        Complete, 
        Gagne, 
        Incomplete
    }
   
    /// <summary>
    /// Représente un carré de jeu tic tac toe 
    /// </summary>
    public class Carre
    {
        /// <summary>
        /// Nombre de case compléter. 
        /// </summary>
        private int m_nbCaseComplete;

        /// <summary>
        /// Matrice représentant les cases du carré. 
        /// </summary>
        private Case[] m_matrice;
        
        /// <summary>
        /// Nombre de côtés du carré. 
        /// </summary>
        public const byte cote = 3;


        /// <summary>
        /// Constructeur par défaut. 
        /// Initialise toutes les cases du carré comme vide. 
        /// </summary>
        public Carre()
        {
            this.Matrice = new Case[cote*cote];

            for (int i = 0; i < cote*cote; i++)
            {
                this.Matrice[i] = new Case(); 
            }
        }

        /// <summary>
        /// Permet de cocher une case du carré.
        /// </summary>
        /// <param name="etat">Etat à coché sur la case.</param>
        /// <param name="pos">Position de la case à coché.</param>
        /// <returns>Vrai si la case est cochée.</returns>
        public bool Cocher(Etat etat, byte pos)
        {
            if(this.Matrice[pos - 1].Cocher(etat))
            {
                this.NbCaseComplete++; 
                return true; 
            }

            return false; 
        }


        /// <summary>
        /// Permet de vérifier l'état d'une case. 
        /// </summary>
        /// <param name="pos">La position de la case à vérifier. </param>
        /// <returns>L'état de la case à vérifier. </returns>
        public Etat EtatCase(byte pos)
        {
            return this.Matrice[pos - 1].Etat; 
        }

        public  byte[] DeterminerSiLigneComplete(byte pos)
        {

            if (pos < 1 || pos > cote * cote)
            {
                throw new InvalidOperationException("Une position doit être comprise enre 1 et " + cote + ".");
            }

            pos--;

            Etat etatJouer = this.Matrice[pos].Etat;

            if (etatJouer == Etat.VIDE)
            {
                return null; 
            }

            byte[] lesPos = null; 


            //Diagonales 
            if(EstDiagonaleDroite(pos))
            {
                lesPos = DiagonaleDroiteComplete(pos, etatJouer); 
            }
            else if (EstDiagonaleGauche(pos))
            {
                lesPos = DiagonaleGaucheComplete(pos, etatJouer); 
            }

            
            //Verticale 
            lesPos = LigneVerticaleComplete(pos, etatJouer); 
           

            //Horizontale
            lesPos = LigneHorizontaleComplete(pos, etatJouer); 
           

            return lesPos; 

        }

        private byte[] LigneVerticaleComplete(byte pos, Etat etatJoue)
        {
            byte[] lesPos = new byte[cote];

            int index = pos - (cote * (pos / cote));
            byte iter = 0;
            bool estComplete = true;

            while (iter < cote && estComplete)
            {
                if (this.Matrice[index].Etat == etatJoue)
                {
                    lesPos[iter] = (byte)index;
                    iter++;

                    //Important : 
                    index += cote;

                }
                else
                {
                    estComplete = false;
                }
            }


            if (estComplete)
            {
                return lesPos;
            }


            return null;
        }

        private byte[] LigneHorizontaleComplete(byte pos, Etat etatJoue)
        {
            byte[] lesPos = new byte[cote];

            int index = pos / cote * cote;
            byte iter = 0;
            bool estComplete = true;

            while (iter < cote && estComplete)
            {
                if (this.Matrice[index].Etat == etatJoue)
                {
                    lesPos[iter] = (byte)index;
                    iter++;

                    //Important : 
                    index++;

                }
                else
                {
                    estComplete = false;
                }
            }

            if (estComplete)
            {
                return lesPos;
            }

            return null; 

        }

        private byte[] DiagonaleGaucheComplete(byte pos, Etat etatJoue)
        {
            
            byte[] lesPos = new byte[cote];


            if (etatJoue == Etat.VIDE)
            {
                return null;
            }

            int index = pos;
            byte iter = 0;

            bool estComplete = true;

            //Vérifie les diagonales : 

                iter = 0;
                index = 0;
                while (iter < cote && estComplete)
                {
                    if (this.Matrice[index].Etat == etatJoue)
                    {
                        lesPos[iter] = (byte)index;
                        iter++;

                        index += cote + 1;
                    }
                    else
                    {
                        estComplete = false;
                    }
                }
            

            if (estComplete)
            {
                return lesPos;
            }

            return null;

        }
        
        private byte[] DiagonaleDroiteComplete(byte pos, Etat etatJoue)

        {

            byte[] lesPos = new byte[cote];

            bool estComplete = true;
            int index = 2 * cote;
            byte iter = 0;

            while (iter < cote && estComplete)
            {
                if (this.Matrice[index].Etat == etatJoue)
                {
                    lesPos[iter] = (byte)index;
                    iter++;

                    //Important : 
                    index -= cote - 1;

                }
                else
                {
                    estComplete = false;
                }
            }
        

        if (estComplete)
        {
            return lesPos;
        }


        return null;
        }


        private bool EstDiagonaleGauche(byte pos) => pos == 0 || pos == cote * cote - 1; 

        private bool  EstDiagonaleDroite(byte pos) => pos == cote - 1 || pos == 2 * cote;


        /// <summary>
        /// Déterminer si carré complet. 
        /// </summary>
        /// <returns>Vrai si le carré est complet.</returns>
        public bool DeterminerCarreComplet() => NbCaseComplete ==  cote * cote; 
        
  
        /// <summary>
        /// Accède à la matrice
        /// </summary>
        private Case[] Matrice
        {
            get{
                return this.m_matrice; 
            }

            set {

                if(value == null)
                {
                    throw new ArgumentNullException("La matrice ne peut être initialiés à rien. "); 
                }

                this.m_matrice = value;
            } 
        }

        public int NbCaseComplete
        {
            get => this.m_nbCaseComplete; 
            private set => this.m_nbCaseComplete =  value; 
        }

      
    }
}
