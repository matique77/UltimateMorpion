using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpions
{
    /// <summary>
    /// Etat possible d'un jeu d'une case de tic tac toe. 
    /// </summary>
    public enum Etat
    {
        VIDE,
        X,
        O
    }


    /// <summary>
    /// Représentant une case d'un jeu de Tic Tac Toe. 
    /// </summary>
    public class Case
    {
        private Etat m_etat; 

        /// <summary>
        /// Constructeur par défaut. 
        /// La case est initialisée comme vide. 
        /// </summary>
        public Case() : this(Etat.VIDE)
        {
            
        }

        /// <summary>
        /// Constructeur paramétré. 
        /// </summary>
        /// <param name="etat">L'état de départ de la case.</param>
        public Case(Etat etat)
        {
            this.Etat = etat; 
        }

        /// <summary>
        /// Permet de cocher la case. 
        /// </summary>
        /// <param name="etat"></param>
        /// <returns></returns>
        public bool Cocher(Etat etat)
        {
            if(!EstCocher)
            {
                this.Etat = etat;
                return true;
            }
            return false; 
        }

        /// <summary>
        /// Vérifie si la case est cochée.
        /// </summary>
        public bool EstCocher
        {
             get => this.Etat != Etat.VIDE; 
        }

        /// <summary>
        /// Accède à l'état de la case.
        /// </summary>
        public Etat Etat { get => m_etat; set => m_etat = value; }
    }
}
