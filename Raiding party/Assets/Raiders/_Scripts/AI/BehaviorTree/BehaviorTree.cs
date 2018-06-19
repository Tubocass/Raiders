using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    Behavior rootNode;

    private void Start()
    {
        Test_Behavior test = new Test_Behavior();
        Repeater repeat = new Repeater(test);
        rootNode = repeat;
    }

    public void Tick()
    {
        rootNode.Tick();
    }

    private void FixedUpdate()
    {
        Tick();
    }

}
