using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior:  IBehavior
{
    public enum Status {Success, Failure, Invalid, Running, Suspended}
    public Status eStatus;
    public Behavior()
    {
        eStatus = Status.Invalid;
    }
    public virtual void OnInitialize()
    { }
    public virtual void OnTerminate(Status status)
    { }
    public virtual Status Update()
    {
        return Status.Invalid;
    }
    public Status GetStatus()
    {
        return eStatus;
    }
    public Status Tick()
    {
        if (eStatus != Status.Running)
        {
            OnInitialize();
        }

        eStatus = Update();

        if (eStatus != Status.Running)
        {
            OnTerminate(eStatus);
        }
  
        return eStatus;
    }
}

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

public class Condition : Behavior
{
    [SerializeField] bool expression;
    public Condition()
    {

    }
    public override Status Update()
    {
        if (expression)
            return Status.Success;
        else
            return
                Status.Failure;
    }
}

public class MoveTo : Behavior
{
    Vector3 target;
    public MoveTo(Vector3 location)
    {
        target = location;
    }
}


public class Repeater : Behavior
{
    [SerializeField] Behavior childBehavior;
    public int counter = 0, limit = 3;

    public override void OnTerminate(Status status)
    {
        counter = 0;
        base.OnTerminate(status);
    }
    public Repeater(Behavior child)
    {
        childBehavior = child;
    }
    public override Status Update()
    {
        while (counter < limit)
        {
            childBehavior.Tick();
            if (childBehavior.GetStatus() == Status.Running) break;
            if (childBehavior.GetStatus() == Status.Failure) return Status.Failure;
            if (++counter == limit) return Status.Success;

        }
        return Status.Success;
    }
}

public class Composite : Behavior
{
    [SerializeField] protected int currentChild = 0;
    [SerializeField] protected List<Behavior> childBehaviors = new List<Behavior>();

    public override void OnInitialize()
    {
        base.OnInitialize();
        currentChild = 0;
    }
    public void AddChild(Behavior child)
    {
        childBehaviors.Add(child);
    }
    public void RemoveChild(Behavior child)
    {
        childBehaviors.Remove(child);
    }
    public void ClearChildren()
    {
        childBehaviors.Clear();
    }
}

public class Sequence : Composite
{
    public override void OnTerminate(Status status)
    {
        base.OnTerminate(status);
    }
    public override Status Update()
    {
        while (currentChild < childBehaviors.Count)
        {
            Status s = childBehaviors[currentChild].Tick();
            if (s != Status.Success)
            {
                return s;
            }
            if (++currentChild == childBehaviors.Count)
            {
                return Status.Success;
            }
        }
        return Status.Invalid;
    }
}

public class Selector : Composite
{
    public override Status Update()
    {
        while (currentChild <= childBehaviors.Count)//this may be trouble
        {
            Status s = childBehaviors[currentChild].Tick();
            if (s != Status.Failure)
            {
                return s;
            }
            if (++currentChild == childBehaviors.Count)
            {
                return Status.Failure;
            }
        }
        return Status.Invalid;
    }
}
