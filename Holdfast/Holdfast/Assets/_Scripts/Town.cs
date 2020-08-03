using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Town : MonoBehaviour
{
   [SerializeField] TownInfo myTownInfo;

    // Use this for initialization
    void Start()
    {
        Dictionary<string, string> info = myTownInfo.getTownInfo();
        Dictionary<string,string>.KeyCollection keys = info.Keys;
        foreach(string key in keys)
        {
            string value;
            Debug.Log(info.TryGetValue(key, out value) ? key +": "+ value : "");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
