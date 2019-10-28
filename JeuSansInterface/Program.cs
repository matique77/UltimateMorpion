using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpions;

namespace JeuSansInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Jeu 
            JeuMorpions jeu = new JeuMorpions();

            //Affichage : 

           

            //Test des coups : 
            bool estTermine = false;
            string choix = "";

            byte carre = 0;
            byte posPion = 0;

            while (!estTermine)
            {
                Console.WriteLine(); 
                Console.WriteLine("========Menu========" + Environment.NewLine +
                                  "1-Jouer un coup" + Environment.NewLine + 
                                  "2-VerifierSiGagner" + Environment.NewLine + 
                                  "3-Quitter"+Environment.NewLine + 
                                  "==================" + Environment.NewLine); 
               
                Console.Write("Entrez votre choix : ");
                choix = Console.ReadLine(); 
                switch(choix)
                {
                    case  "1":

                        bool estValide = false;
                        
                        do
                        {
                            Console.Write("Carré? : ");
                            estValide = byte.TryParse(Console.ReadLine(), out carre);

                        } while (!estValide);
                        estValide = false;
                      

                       
                        do
                        {
                            Console.Write("PosPion : ");
                            estValide = byte.TryParse(Console.ReadLine(), out posPion);
                        } while (!estValide);
                        estValide = false; 


                        jeu.Jouer(jeu.Plateau.Jeu[1], Etat.X, 1);
                        jeu.Jouer(jeu.Plateau.Jeu[1], Etat.X, 2);
                        jeu.Jouer(jeu.Plateau.Jeu[1], Etat.X, 3); 

                        break;

                    case "2":

                        Console.Write("Carré? : ");
                        carre = byte.Parse(Console.ReadLine());

                        Console.Write("PosPion : ");
                        posPion = byte.Parse(Console.ReadLine());

                        byte[] ligne = jeu.Plateau.Jeu[carre].DeterminerSiLigneComplete(posPion); 

                        if(ligne!=null)
                        {
                            Console.WriteLine("Gagner");
                        }
                        else
                        {
                            Console.WriteLine("Pas encore");
                        }
                        Console.ReadLine(); 
                        break;

                    case  "3":
                        estTermine = true;
                        break;

                    default:
                        Console.WriteLine("Choix invalide!");
                        Console.ReadLine();
                        break; 
                }

                Console.Clear();
            }

        }
    }
}
