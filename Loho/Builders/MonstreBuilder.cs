using System;
using System.Linq;
using System.Reflection;
using Loho.Interfaces;
using static Loho.Utils.Randomize;

namespace Loho.Builders
{
    public class MonstreBuilder
    {
        public readonly Type[] Types;

        public MonstreBuilder()
        {
            Types = (from type in Assembly.GetAssembly(typeof(IMonstre)).GetTypes()
                where type.IsClass && !type.IsAbstract && typeof(IMonstre).IsAssignableFrom(type)
                select type).ToArray();
            //Types = Assembly.GetAssembly(typeof(IMonstre)).GetTypes()
            //    .Where(_ => _.IsClass && !_.IsAbstract && typeof(IMonstre).IsAssignableFrom(_)).ToArray();
        }

        public IMonstre Creer()
        {
            var r =  RandomUnit.Next(Types.Length);
            var type = Types[r];
            return Activator.CreateInstance(type) as IMonstre;
        }
    }
}