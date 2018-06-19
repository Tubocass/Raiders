using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_SeekShelter : IBehaviourState
{
    NpcBase NpcController;
    List<Safety> safeSpaces;
    Transform safeHouse;
    LayerMask mask;
    public State_SeekShelter(NpcBase unit, LayerMask m)
    {
        NpcController = unit;
        mask = m;
    }
    public void EnterState()
    {
        safeSpaces = NpcBase.FindTargets<Safety>("Safety", NpcController.Location, 100f, mask, s => s.isOpen);
        if (safeSpaces.Count > 0)
        {
            safeHouse = NpcBase.TargetNearest<Safety>(NpcController.Location, safeSpaces).transform;
            if (safeHouse != null)
            {
                NpcController.mover.MoveTo(safeHouse.position);
               // bMovingToSafety = true;
            }
        }
    }
   public void ExitState()
    { }
    public void AssesSituation()
    {
        if (Vector3.Distance(NpcController.Location, safeHouse.position) <= 1f)
        {
            safeHouse.GetComponent<Safety>().EnterSafety(this.NpcController);
            NpcController.gameObject.SetActive(false);
            //EndState Callaback
        }
    }
}
