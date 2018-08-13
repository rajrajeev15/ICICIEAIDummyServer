using System;

namespace ICICI.EAI.DummyServer.Utilities
{
    public static class Validations
    {
        public static void ValidArgument(Func<bool> predicate)
        {
            if (predicate()) return;
            throw new ArgumentException();
        }
    }
}
