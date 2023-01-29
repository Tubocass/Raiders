using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;
using UnityEditor.Tilemaps;

public class Character : MonoBehaviour
{
    PolyNavAgent agent;
    public Transform target;
    void Start()
    {
        agent = GetComponent<PolyNavAgent>();
        // agent.SetDestination(target.position);
        
    }

    void Update()
    {
        
    }
    public void MoveTo(Vector3 target)
    {
        agent.SetDestination(target);
    }
}
