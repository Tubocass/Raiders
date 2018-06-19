using UnityEngine;
using System.Collections;

public class Test_Behavior : Behavior
{
    public string testPhrase = "I suck at this.";

    public override void OnInitialize()
    {
        base.OnInitialize();

    }
    public override Status Update()
    {
        Debug.Log(testPhrase);
        eStatus = Status.Success;
        return base.Update();
    }
}
