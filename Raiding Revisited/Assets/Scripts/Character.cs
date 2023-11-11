using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

namespace RaidingParty
{
    public class Character : MonoBehaviour
    {
        PolyNavAgent agent;
        void Start()
        {
            agent = GetComponent<PolyNavAgent>();

        }

        void Update()
        {

        }

        public void MoveTo(Vector3 target)
        {
            agent.SetDestination(target);
        }
    }
}
