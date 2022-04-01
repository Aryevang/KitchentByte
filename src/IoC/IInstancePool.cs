namespace IoC;

public interface IInstancePool
{
    public void Register<TClass>(TClass initializedInstance) where TClass : class;
    public TClass GetInstance<TClass>() where TClass : class;
}
