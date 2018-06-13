using Loho.Models;

namespace Loho.Interfaces
{
    public interface IMonstre
    {
        De DeMonstre { get; }
        int DegatsAttaque { get; }
        int Recompense { get; }
        bool EstVivant { get; }
        string Nom { get; }

        int JetAttaque();
        void Meurt();
        string Parle(string texteAdditionnel = null);
    }
}
