using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public abstract class Piece
    {
        protected char _nom;
        protected Couleur _couleur;
        public Piece(Couleur couleur)
        {
            _couleur = couleur;
        }

        /// <summary>
        /// Retourne la couleur de la pièce
        /// </summary>
        public Couleur Couleur
        {
            get { return _couleur; }
            set { _couleur = Couleur; }
            
        }

        /// <summary>
        /// Vérifie si la pièce peut être promu
        /// </summary>
        /// <returns>Retourne faux si la pièce ne peut pas être promu</returns>
        public virtual bool peutEtrePromu()
        {
            return false;
        }

        /// <summary>
        /// Vérifie si la pièce peut charger
        /// </summary>
        /// <returns>Retourne faux si la pièce ne peut pas charger</returns>
        public virtual bool peutCharger()
        {
            return false;
        }

        /// <summary>
        /// Fais en sorte que la pièce ne puisse plus charger
        /// </summary>
        public virtual void nePeutPlusCharger()
        { 
            
        }

        /// <summary>
        /// Vérifie si la pièce peut roquer
        /// </summary>
        /// <returns>Retourne faux si la pièce ne peut plus roquerreturns>
        public virtual bool peutRoquer()
        {
            return false;
        }

        /// <summary>
        /// Fais en sorte que la pièce ne puisse plus roquer
        /// </summary>
        public virtual void vientDeBouger(){}

        /// <summary>
        /// Vérifie le mouvement selon les règles de la pièce
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement de la pièce</returns>
        public virtual Mouvement regles(int indexInitiale, int indexDestination)
        {
            return Mouvement.peutPasBouger;
        }
        


    }
}
