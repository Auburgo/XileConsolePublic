using System.Reflection;

public class Eventbus
{
    private readonly Dictionary<Type, Delegate> map = new Dictionary<Type, Delegate>();
    private static readonly Eventbus instance = new Eventbus();

    private Eventbus() { }

    public static Eventbus Instance => instance;

    public void Suscribe<T>(EventHandler<T> e) where T : EventArgs
    {
        if (map.TryGetValue(typeof(T), out Delegate handler))
        {
            map[typeof(T)] = Delegate.Combine(handler, e);
        }
        else
        {
            map[typeof(T)] = e;
        }
    }

    public void Unsuscribe<T>(EventHandler<T> e) where T : EventArgs
    {
        if (map.ContainsKey(typeof(T)))
        {
            map[typeof(T)] = Delegate.Remove(map[typeof(T)], e);
        }
    }

    public void Publish<T>(Object sender, T e) where T : EventArgs
    {
        if (map.ContainsKey(typeof(T)))
        {
            var x = map[typeof(T)];
            int amount = x.GetInvocationList().Length;
            map[typeof(T)]?.DynamicInvoke(sender, e);
        }
    }

    public void ClearAll()
    {
        map.Clear();
    }

}
