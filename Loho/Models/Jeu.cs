using System;
using System.Collections.Generic;
using Loho.ActionMechanics;
using Loho.Builders;
using Loho.Interfaces;
using Loho.Utils;
using static Loho.Utils.Style;

namespace Loho.Models
{
    public class Jeu
    {
        public Timer Timer { get; }
        public Joueur Joueur { get; }
        private MonstreBuilder MonstreProche { get; }
        public Dictionary<Type, int> MapMonstresTues { get; set; }
        public List<CombatAction> CombatActions { get; set; }

        public Jeu(Joueur joueur = null)
        {
            CombatActions = new List<CombatAction>
            {
                Actions.AttaqueJoueur,
                Actions.MonstreLanceSort,
                Actions.SeDefendre,
                Actions.MonstreLoupe,
                Actions.MonstreAttaque,
                Actions.FinDuJeu
            };

            Timer = new Timer();
            Joueur = joueur ?? new Joueur();
            MonstreProche = new MonstreBuilder();
            MapMonstresTues = new Dictionary<Type, int>();
            foreach (var t in MonstreProche.Types)
                MapMonstresTues.Add(t, 0);
        }

        public void Lancer()
        {
            Write();
            Console.WriteLine("   Vous avez 150 points de vie, à l'aventure !");
            Timer.Wait();
            while (Joueur.EstVivant)
            {
                Write();
                var monstre = GenererMonstre();
                CombatActions.Fold()(new CombatContext(Joueur, monstre, MapMonstresTues, Timer), () => {});
            }
        }

        private IMonstre GenererMonstre()
        {
            var monstre = MonstreProche.Creer();
            Console.Write("   Un monstre {0} surgit !", monstre.Nom.ToLower());
            Timer.Wait();
            return monstre;
        }
    }
}