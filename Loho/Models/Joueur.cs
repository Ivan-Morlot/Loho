using System;

namespace Loho.Models
{
    public class Joueur
    {
        public De DeJoueur { get; }
        public int PdV { get; set; }
        public int Bouclier { get; set; }
        public bool EstVivant => PdV > 0;
        public int Points { get; set; }

        public Joueur()
        {
            DeJoueur = new De();
            PdV = 150;
            Bouclier = 2;
            Points = 0;
        }

        public int JetAttaque()
        {
            if (!EstVivant) throw new Exception("Le joueur ne peut pas attaquer s'il est mort...");
            return DeJoueur.LancerLeDe();
        }

        public bool CanDefend()
        {
            if (!EstVivant) throw new Exception("Le joueur ne peut pas se défendre s'il est mort...");
            var tirageBouclierJoueur = DeJoueur.LancerLeDe();
            return tirageBouclierJoueur <= Bouclier;
        }

        public void SubitDegats(int degatsSubis)
        {
            if (!EstVivant) throw new Exception("Le joueur ne peut pas se défendre s'il est mort...");
            PdV -= degatsSubis;
            if (PdV >= 0) return;
            PdV = 0;
        }
    }
}
