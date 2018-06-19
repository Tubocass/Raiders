using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : NpcBase
{
	public bool alertRaised, spotEnemy;
    //State_Alert alertState;
    State_SeekShelter seekShelterState;//substate of Alert
	State_Flee fleeState;//substate of Alert
    //State_WorkRoutine routineState;//mill about in ignorance of impending doom
	State_Idle idleState;//rewrite as a "blank" state
	/*	Behaviors:
//	 * 		Mill about
//	 * 			Move between a couple of waypoints, animatiting different activities
//	 * 		Raise Alarm // X-Nope
//	 * 			Move to Sound Alarm // X-Nope
//	 * 		Flee
//	 * 			Run away from immediate threats
//	 * 			seek shelter
//	 */
	protected override void OnEnable()
	{
		base.OnEnable();
	}
	protected override void OnDisable()
	{
		base.OnDisable();
	}
	protected override void Start()
	{
		base.Start();
		fleeState = new State_Flee(this, mask);
        fleeState.NoLongerFleeing += Idle;
		idleState = new State_Idle(this);
		idleState.TargetSpotted += Flee;
		BehaviourState = idleState;
	}
    void Assess()
    {
        /*if (bAlert)
         * {
         *    if(targetEnemy !=null)  
         *    {
         *    Vector3 enemyVector = targetEnemy.Location-NpcController.Location;
			  Vector3 homeVector = safeHouse.position-NpcController.Location;
             
              if(enemyVector.magnitude<homeVector.magnitude/2)
			  {
				movement = -enemyVector.normalized;
				animSpeed = 1f;
				NpcController.mover.Move(movement);
				bMovingToSafety = false;
				beingChased = true;
			}
         }
            }
         * 
         * 
         */
    }
    void Flee()
	{
		BehaviourState = fleeState;
	}
    void Idle()
    {
        BehaviourState = idleState;
    }

	public override void Update()
	{
		base.Update();
		BehaviourState.AssesSituation();
		Animate();
	}
		
}
