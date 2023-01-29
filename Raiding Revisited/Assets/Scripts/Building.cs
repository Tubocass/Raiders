using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] Character worker;

    public void AssignWorker(Character unit)
    {
        this.worker = unit;
    }
}
