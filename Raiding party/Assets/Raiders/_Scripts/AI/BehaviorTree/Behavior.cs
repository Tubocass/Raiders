using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior: IBehavior
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
