namespace IoC;

public sealed class InstancePool : IInstancePool
{
    //This is where the instances will be stored.
    private static readonly Dictionary<string, object>? _implementationStore;
    //Make the contructor unaccessible.
    static InstancePool()
    {
        _implementationStore = new Dictionary<string, object>();
    }


    //This is the only way to access to the methods of the class.
    private static IInstancePool? _instance = null;
    public static IInstancePool Instance
    {
        get
        {
            return _instance is null ? new InstancePool() : _instance;
        }
    }

    //This method register the class.
    public void Register<TClass>(TClass initializedInstance) where TClass : class
    {
        if (!_implementationStore.ContainsKey(nameof(TClass)))
        {
            //Store the instance passed as parameter.
            _implementationStore.Add(nameof(TClass), initializedInstance);
        }
    }

    //This method retrieve the instance of the class previowsly registered.
    public TClass GetInstance<TClass>() where TClass : class
    {
        //The null coaleasing operator (??) is a shorthand to check if any object is null.
        //If so, will return and alternative value.
        //Else, will return the object originally checked.
        return (TClass)FetchInstance(nameof(TClass)) ?? default;
    }

    internal object FetchInstance(string instanceName)
    {
        //If the key exist in the store, then will return the value.
        if (_implementationStore.TryGetValue(instanceName, out object instance))
            return instance;

        return default;
    }
}
