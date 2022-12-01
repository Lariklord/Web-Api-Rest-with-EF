namespace Web_Api
{
    public static class IoCContainer
    {
        private static readonly Dictionary<Type,Type> _registeryObjects = new Dictionary<Type,Type>();
        public static dynamic Resolve<TKey>()
        {
            return Activator.CreateInstance(_registeryObjects[typeof(TKey)])!;
        }
        public static void Register<TKey,TConcrete>() where TConcrete:TKey
        {
            _registeryObjects[typeof (TKey)] = typeof (TConcrete);
        }
    }
}
