using System;
using System.Collections.Generic;
using Loho.Interfaces;
using Loho.Models;
using Loho.Utils;

namespace Loho.ActionMechanics
{
    public class CombatContext
    {
        public Dictionary<Type, int> MapMonstresTues { get; }
        public Joueur Joueur { get; }
        public IMonstre Monstre { get; }
        public Timer Timer { get; set; }

        public CombatContext(Joueur joueur, IMonstre monstre, Dictionary<Type, int> mapMonstresTues, Timer timer)
        {
            Joueur = joueur;
            Monstre = monstre;
            MapMonstresTues = mapMonstresTues;
            Timer = timer;
        }

        public (Joueur, IMonstre, Dictionary<Type, int>, Timer) Deconstruct()
        {
            return (Joueur, Monstre, MapMonstresTues, Timer);
        }

    }
}
