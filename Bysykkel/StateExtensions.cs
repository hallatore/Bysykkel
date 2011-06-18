using System.Collections.Generic;

namespace Bysykkel
{
    public static class StateExtensions
    {
        public static void Save(this IDictionary<string, object> state, string name, object item)
        {
            state.Remove(name);
            state.Add(name, item);
        }
    }
}
