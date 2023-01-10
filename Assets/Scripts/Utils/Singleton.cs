using System;

public class Singleton<T> where T : class, new()
{
	private static T _Instance;
	public static T Instance
	{
		get
		{
			if (Singleton<T>._Instance == null)
			{
				Singleton<T>._Instance = Activator.CreateInstance<T>();
				CollectionElementCount.AddOneNewInstance(Singleton<T>._Instance);
			}
			return Singleton<T>._Instance;
		}
	}
	public static T GetInstance()
	{
		if (Singleton<T>._Instance == null)
		{
			Singleton<T>._Instance = Activator.CreateInstance<T>();
			CollectionElementCount.AddOneNewInstance(Singleton<T>._Instance);
		}
		return Singleton<T>._Instance;
	}
	public static T GetInstance(int i)
	{
		if (i < 0 || i >= 1)
		{
			return (T)((object)null);
		}
		return Singleton<T>._Instance;
	}
	public static void CreateInstance()
	{
		if (Singleton<T>._Instance == null)
		{
			Singleton<T>._Instance = Activator.CreateInstance<T>();
			CollectionElementCount.AddOneNewInstance(Singleton<T>._Instance);
		}
	}
	public static void DestroyInstance()
	{
		if (Singleton<T>._Instance != null)
		{
			Singleton<T>._Instance = (T)((object)null);
		}
	}
}

