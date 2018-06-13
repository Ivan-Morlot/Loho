namespace Loho.Models
{
    public class MonstreFacile : AbstractMonstre
    {
        public MonstreFacile()
        {
            Recompense = 1;
            Nom = "Facile";
        }

        public override string Parle(string texteAdditionnel = null)
        {
            return base.Parle("\"" + texteAdditionnel);
        }
    }
}