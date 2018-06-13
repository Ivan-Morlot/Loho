using System;

namespace Loho.Models
{
    public class MonstreDifficile : AbstractMonstre
    {
        private readonly int _puissanceSort;

        public MonstreDifficile()
        {
            _puissanceSort = 5;
            Recompense = 2;
            Nom = "Difficile";
        }

        public int Sort()
        {
            if (!EstVivant) throw new Exception("Le monstre ne peut pas lancer de sort s'il est mort...");
            return DeMonstre.LancerLeDe() * _puissanceSort;
        }

        public override string Parle(string texteAdditionnel = null)
        {
            return base.Parle(" Tu vas bouffer un sort !\"" + texteAdditionnel);
        }
    }
}