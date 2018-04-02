using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : NpcBase
{
	public bool alertRaised, spotEnemy;
	State_Flee fleeState;
	State_Idle idleState;
	/*	Behaviors:
//	 * 		Mill about
//	 * 			Move between a couple of waypoints, animatiting different activities
//	 * 		Raise Alarm
//	 * 			Move to Sound Alarm
//	 * 		Flee
//	 * 			Run away from immediate threats
//	 * 			seek shelter
//	 */
	protected override void OnEnable()
	{
		base.OnEnable();
		//UnityEventManager.StartListening("AlarmEvent", Flee);
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		//UnityEventManager.StopListening("AlarmEvent", Flee);
	}
	protected override void Start()
	{
		base.Start();
		fleeState = new State_Flee(this, mask);
		idleState = new State_Idle(this);
		idleState.TargetSpotted += Flee;
		BehaviourState = idleState;
		//target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Flee()
	{
		BehaviourState = fleeState;
	}

	public override void Update()
	{
		base.Update();
		BehaviourState.AssesSituation();
		Animate();
	}
		
}
