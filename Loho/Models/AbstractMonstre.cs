using System;
using System.Collections.Generic;
using Loho.Interfaces;
using static Loho.Utils.Randomize;

namespace Loho.Models
{
    public abstract class AbstractMonstre : IMonstre
    {
        private readonly List<string> _dialogues = new List<string>
        {
            "Dlukfghkjbx ?!",
            "Kdjfhgldfhg !",
            "Wdlkufghosl."
        };

        public De DeMonstre { get; }
        public int DegatsAttaque { get; protected set; }
        public int Recompense { get; protected set; }
        public bool EstVivant { get; protected set; }
        public string Nom { get; protected set; }

        protected AbstractMonstre()
        {
            DeMonstre = new De();
            DegatsAttaque = 10;
            EstVivant = true;
        }

        public virtual int JetAttaque()
        {
            if (!EstVivant) throw new Exception("Le monstre ne peut pas attaquer s'il est mort...");
            Parle();
            return DeMonstre.LancerLeDe();
        }

        public void Meurt()
        {
            if (!EstVivant) throw new Exception("Le monstre est déjà mort...");
            EstVivant = false;
        }

        public virtual string Parle(string texteAdditionnel = null)
        {
            if (!EstVivant) throw new Exception("Le monstre ne peut pas parler s'il est mort...");
            return _dialogues[RandomUnit.Next(_dialogues.Count)] + texteAdditionnel;
        }
    }
}
