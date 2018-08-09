using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tuba
{
    public class BehaviorTree : MonoBehaviour
    {
        [SerializeField] Behavior rootNode;
        [SerializeField] Sequence sequence;

        private void Start()
        {
            //Test_Behavior test = new Test_Behavior();
            //Repeater repeat = new Repeater(test);
            //Sequence sequence = new Sequence();
            //sequence.AddChild(new Condition(1<0));
            //sequence.AddChild(repeat);
            //sequence.AddChild(new Repeater(test));
            // rootNode = sequence;
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
}
