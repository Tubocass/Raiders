using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class IntEvent: UnityEvent<int>
{
}
public class ObjEvent: UnityEvent<GameObject>
{
}
public class BoolEvent: UnityEvent<bool>
{
}
public class UnityEventManager : MonoBehaviour 
{

	private Dictionary <string, UnityEvent> eventDictionary;
	private Dictionary <string, IntEvent> IntEventDictionary;
	private Dictionary <string, BoolEvent> BoolEventDictionary;
	private Dictionary <string, ObjEvent> ObjEventDictionary;

	private static UnityEventManager eventManager;

	public static UnityEventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (UnityEventManager)) as UnityEventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init (); 
				}
			}

			return eventManager;
		}
	}

	void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent>();
			IntEventDictionary = new Dictionary<string, IntEvent>();
			ObjEventDictionary = new Dictionary<string, ObjEvent>();
			BoolEventDictionary = new Dictionary<string, BoolEvent>();
		}
	}

	public static void StartListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}
	public static void StartListeningInt (string eventName, UnityAction<int> listener)
	{
		IntEvent thisIntEvent = null;
		if (instance.IntEventDictionary.TryGetValue (eventName, out thisIntEvent))
		{
			thisIntEvent.AddListener (listener);
		} 
		else
		{
			thisIntEvent = new IntEvent ();
			thisIntEvent.AddListener (listener);
			instance.IntEventDictionary.Add (eventName, thisIntEvent);
		}
	}
	public static void StartListeningBool (string eventName, UnityAction<bool> listener)
	{
		BoolEvent thisBoolEvent = null;
		if (instance.BoolEventDictionary.TryGetValue (eventName, out thisBoolEvent))
		{
			thisBoolEvent.AddListener (listener);
		} 
		else
		{
			thisBoolEvent = new BoolEvent ();
			thisBoolEvent.AddListener (listener);
			instance.BoolEventDictionary.Add (eventName, thisBoolEvent);
		}
	}
	public static void StartListeningObj (string eventName, UnityAction<GameObject> listener)
	{
		ObjEvent thisObjEvent = null;
		if (instance.ObjEventDictionary.TryGetValue (eventName, out thisObjEvent))
		{
			thisObjEvent.AddListener (listener);
		} 
		else
		{
			thisObjEvent = new ObjEvent ();
			thisObjEvent.AddListener (listener);
			instance.ObjEventDictionary.Add (eventName, thisObjEvent);
		}
	}

	public static void StopListening (string eventName, UnityAction listener)
	{
		if (eventManager == null) return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	public static void StopListeningInt (string eventName, UnityAction<int> listener)
	{
		if (eventManager == null) return;
		IntEvent thisEvent = null;
		if (instance.IntEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	public static void StopListeningBool (string eventName, UnityAction<bool> listener)
	{
		if (eventManager == null) return;
		BoolEvent thisEvent = null;
		if (instance.BoolEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	public static void StopListeningObj (string eventName, UnityAction<GameObject> listener)
	{
		if (eventManager == null) return;
		ObjEvent thisEvent = null;
		if (instance.ObjEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}
	public static void TriggerEvent (string eventName, int i)
	{
		IntEvent thisEvent = null;
		if (instance.IntEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (i);
		}
	}
	public static void TriggerEvent (string eventName, bool b)
	{
		BoolEvent thisEvent = null;
		if (instance.BoolEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (b);
		}
	}
	public static void TriggerEvent (string eventName, GameObject g)
	{
		ObjEvent thisEvent = null;
		if (instance.ObjEventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (g);
		}
	}

}