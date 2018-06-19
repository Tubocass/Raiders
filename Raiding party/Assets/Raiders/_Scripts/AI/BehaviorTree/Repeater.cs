using UnityEngine;
using System.Collections;

public class Repeater : Behavior
{
    Behavior childBehavior;
    public int counter = 0, limit=3;

    public Repeater(Behavior child)
    {
        childBehavior = child;
    }
    public override Status Update()
    {
        while (counter<limit)
        {
            childBehavior.Tick();
            if (childBehavior.GetStatus() == Status.Running) break;
            if (childBehavior.GetStatus() == Status.Failure) return Status.Failure;
            if (++counter == limit) return Status.Success;
            
        }
        return Status.Success;
    }

    }
