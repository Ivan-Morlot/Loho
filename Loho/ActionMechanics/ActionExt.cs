using System.Collections.Generic;
using System.Linq;

namespace Loho.ActionMechanics
{
    public static class ActionExt
    {
        public static CombatAction Fold(this IEnumerable<CombatAction> actions)
        {
            return actions.Aggregate((accumulator, action) => (ctx, next) => accumulator(ctx, () => action(ctx, next)));
        }
    }
}
