using UnityEngine;
using System.Collections;

public class UnitySingleton<T> : MonoBehaviour  where T:Component
{
	private static T m_Instance;

	public static T instance
	{
		get
		{
			if (m_Instance == null)
			{
				m_Instance = FindObjectOfType (typeof(T)) as T;
				if (m_Instance == null) 
				{
					GameObject obj = new GameObject (typeof(T).GetType ().ToString());
					m_Instance = obj.AddComponent<T> ();
					obj.hideFlags = HideFlags.HideAndDontSave;
				}
			}
			return m_Instance;
		}
	}
	protected virtual void Awake()
	{
		DontDestroyOnLoad (this.gameObject);

		if (m_Instance == null) {
			m_Instance = this as T;
		} else {
			//说明该单例已经存在，为了保证单例的唯一性所销毁这个物体
			GameObject.Destroy (this.gameObject);
		}
	}
}
