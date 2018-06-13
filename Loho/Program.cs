using System;
using Loho.Models;
using Loho.Utils;
using static System.Console;
using static System.ConsoleColor;
using static Loho.Utils.Style;
using static Loho.Utils.LineBreak;

namespace Loho
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetWindowSize(160, 44);
            BaseColors();
            Cc();
            BackgroundColor = DarkCyan;
            ForegroundColor = White;
            Write(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            Write("                                  ", None);
            Write("               Loho               ", None);
            Write("                                  ", None);
            BaseColors();
            WriteLine(Environment.NewLine + Environment.NewLine);
            Write("Loho est un jeu de hasard.", After);
            Write("Lancez votre aventurier dans une forêt maudite et regardez combien de temps il peut tenir.",
                Both);
            Write("Affrontez le plus de monstres possible et gagnez un maximum de points !", After);
            Write("- Monstre facile     :   1 point", None);
            Write("- Monstre difficile  :   2 point", After);
            Write("Vous pouvez changer la vitesse d'action de 0.1s à 2,5s (1,3s par défaut) :", Both);
            Write("- Flèche Haut (augmenter)", None);
            Write("- Flèche Bas   (réduire) ", After);
            Pause("start playing");
            while (true)
            {
                Cc();
                new Jeu().Lancer();
                if (ReadBool("Voulez-vous rejouer ? (O/N)", Before)) continue;
                Cc();
                Write();
                NiceColors();
                Write("  A bientôt !  ", Both);
                BaseColors();
                Pause("exit");
                break;
            }
        }
    }
}
