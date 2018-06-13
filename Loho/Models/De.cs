using static Loho.Utils.Randomize;

namespace Loho.Models
{
    public class De
    {
        public int Min { get; }
        public int Max { get; }

        public De(int min = 1, int max = 6)
        {
            Min = min;
            Max = max;
        }

        public int LancerLeDe()
        {
            return RandomUnit.Next(Min, Max + 1);
        }
    }
}
