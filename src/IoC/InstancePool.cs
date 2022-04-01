namespace IoC;

public sealed class InstancePool
{
    //This is where the instances will be stored.
    private static Dictionary<string, object>? _implementationStore;
    //Make the contructor unaccessible.
    InstancePool()
    {
        _implementationStore = new Dictionary<string, object>();
    }


    //This is the only way to access to the methods of the class.
    private static InstancePool? _instance = null;
    public static InstancePool Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new InstancePool();
            }
            return _instance;
        }
    }

    //This method register the class.
    public void Register<TClass>() where TClass : class
    {
        if (!_implementationStore.ContainsKey(nameof(TClass)))
        {
            //Creates the instances before to store it.
            TClass instance = (TClass)Activator.CreateInstance(typeof(TClass));

            _implementationStore.Add(nameof(TClass), instance);
        }
    }

    //This method retrieve the instance of the class previowsly registered.
    public TClass GetInstance<TClass>() where TClass : class
    {
        if (_implementationStore.TryGetValue(nameof(TClass), out object instance))
        {
            return (TClass)instance;
        }

        return default;
    }
}
