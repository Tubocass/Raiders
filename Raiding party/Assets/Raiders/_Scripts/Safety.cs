using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safety : MonoBehaviour, ISafety
{
	public bool isOpen = true;
    private UnitController[] slots;

    private void Start()
    {
        slots = new UnitController[5];
    }
    public void EnterSafety(UnitController uc)
    {
        for (int s = 0; s < slots.Length; s++)
        {
            if (slots[s] == null)
            {
                slots[s] = uc;
                return;
            }
        }
    }
    public void Evacuate()
    {
        isOpen = false;
        for (int s = 0; s < slots.Length; s++)
        {
            if (slots[s] != null)
            {
                slots[s].isActive = true;
                slots[s].transform.position = this.transform.position - Vector3.forward;
            }
        }
    }

}
