using System;
using Loho.Models;
using Loho.Utils;
using static Loho.Utils.Style;
using static Loho.Utils.LineBreak;

namespace Loho.ActionMechanics
{
    public static class Actions
    {
        public static void AttaqueJoueur(CombatContext ctx, Action next)
        {
            var (joueur, monstre, mapMonstresTues, timer) = ctx.Deconstruct();
            Console.Write("   Vous attaquez le monstre.");
            if (joueur.JetAttaque() >= monstre.JetAttaque())
            {
                timer.Wait();
                monstre.Meurt();
                Console.WriteLine("   Vous l'avez vaincu !");
                timer.Wait();
                mapMonstresTues[monstre.GetType()]++;
                Console.WriteLine();
                joueur.Points += monstre.Recompense;
                return;
            }
            Console.Write(".. mais loupez votre attaque.");
            timer.Wait();
            Console.WriteLine("   Le monstre se défend : \"" + monstre.Parle());
            timer.Wait();
            next();
        }

        public static void MonstreLanceSort(CombatContext ctx, Action next)
        {
            if (ctx.Joueur.EstVivant && ctx.Monstre is MonstreDifficile monstreDifficile)
            {
                var degatsSort = monstreDifficile.Sort();
                Console.WriteLine("   Le sort vous inflige {0} de dégâts.", degatsSort);
                ctx.Timer.Wait();
                ctx.Joueur.SubitDegats(degatsSort);
            }
            next();
        }

        public static void SeDefendre(CombatContext ctx, Action next)
        {
            if (ctx.Joueur.EstVivant && ctx.Joueur.CanDefend())
            {
                Console.WriteLine("   Vous parez l'attaque !");
                ctx.Timer.Wait();
                if (!(ctx.Monstre is MonstreDifficile)) return;
                AfficherVieJoueur(ctx);
                ctx.Timer.Wait();
                return;
            }
            next();
        }

        public static void MonstreLoupe(CombatContext ctx, Action next)
        {
            if (ctx.Joueur.EstVivant && ctx.Monstre.JetAttaque() <= ctx.Joueur.JetAttaque())
            {
                Console.WriteLine("   Il loupe son attaque.");
                ctx.Timer.Wait();
                if (!(ctx.Monstre is MonstreDifficile)) return;
                AfficherVieJoueur(ctx);
                ctx.Timer.Wait();
                return;
            }
            next();
        }

        public static void MonstreAttaque(CombatContext ctx, Action next)
        {
            if(ctx.Joueur.EstVivant)
            {
                Console.WriteLine("   L'attaque vous inflige {0} de dégâts.", ctx.Monstre.DegatsAttaque);
                ctx.Timer.Wait();
                ctx.Joueur.SubitDegats(ctx.Monstre.DegatsAttaque);
                AfficherVieJoueur(ctx);
                ctx.Timer.Wait();
            }
            next();
        }

        public static void FinDuJeu(CombatContext ctx, Action next)
        {
            if (ctx.Joueur.EstVivant) return;
            ctx.Timer = null;
            Write();
            NiceColors();
            Write("  Snif, vous êtes mort...  ", Both);
            BaseColors();
            Pause();
            Write();
            NiceColors();
            Write("  Bravo !!! Vous avez tué "
                  + ctx.MapMonstresTues[typeof(MonstreFacile)]
                  + " monstres faciles et " + ctx.MapMonstresTues[typeof(MonstreDifficile)]
                  + " monstres difficiles. Vous avez "
                  + ctx.Joueur.Points
                  + " points.  ", Both);
            BaseColors();
            Pause();
            next();
        }

        private static void AfficherVieJoueur(CombatContext ctx)
        {
            if (ctx.Joueur.PdV > 0) Console.WriteLine("   Il vous reste {0} points de vie.", ctx.Joueur.PdV);
            else Console.WriteLine("   Il ne vous reste plus aucun point de vie.");
        }
    }
}
