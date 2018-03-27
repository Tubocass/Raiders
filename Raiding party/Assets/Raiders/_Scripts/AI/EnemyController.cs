using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyController : UnitController 
{
	[SerializeField] GameObject weapon;
	[SerializeField] bool allowedToFight = false, isFollowing = false;
	[SerializeField] UnitController Leader;
	Transform target;
	UnitController targetEnemy;
	List<UnitController> enemies = new List<UnitController>();
	NavMeshAgent agent;

	protected override void OnEnable()
	{
		base.OnEnable();
		//agent = GetComponent<NavMeshAgent>();
		UnityEventManager.StartListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		UnityEventManager.StopListeningInt("TargetUnavailable", TargetLost);
	}
	protected override void Start()
	{
		base.Start();
		targetEnemy = TargetNearest();
		if(targetEnemy!=null)
		target = targetEnemy.transform;
//		if(weapon!=null)
//		{
//			currentWeapon = weapon.GetComponent<Weapon>();
//		}
	}

	public override void Update()
	{
//		if(IsTargetingEnemy())
//		{
//			if(Vector3.Distance(Location,targetEnemy.Location)<1f)
//			{
//				if(canAttack)
//				{
//					Attack();
//				}
//				animSpeed = 0f;
//			}
//		}else{
//			
//		}

		//if(isFollowing)
		base.Update();
		if(target!=null && Vector3.Distance(Location,target.position)>1f)//Am I going somewhere
		{
			movement = (target.position-Location).normalized;
			animSpeed = 1f;
			//agent.destination = target.position;
			mover.Move(movement);
		}else{//we don't have a target, or we've arrived
			animSpeed = 0f;
			if(IsTargetingEnemy())
			{
				Vector3 enemyVector = targetEnemy.Location-Location;

				if(Vector3.Dot(enemyVector,movement)>0)//am I facing the enemy
				{
					if(canAttack)
					{
						Attack();
					}
				}else{
					//mover.Move(enemyVector);
				}
			}else if(allowedToFight)
				{
					targetEnemy = TargetNearest();
				if(targetEnemy!=null)
					target = targetEnemy.transform;
				else
					FollowLeader();//Can't find any targets, follow the Leader
				}
			}
			
		Animate();
	}
	void FollowLeader()
	{
		if(Leader != null && Leader.isActive)
		{
			isFollowing = true;
			target = Leader.transform;
		}
	}
	bool IsTargetingEnemy()
	{
		if(targetEnemy!=null && targetEnemy.isActive)
			return true;
		else return false;
	}

	UnitController TargetNearest()
	{
		float nearestEnemyDist, newDist;
		UnitController enemy = null;

		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,50,mask);
		if(cols.Length>0)
		{
			for(int f = 0; f<cols.Length-1;f++)
			{
				if(cols[f].CompareTag("Unit"))
				{
					UnitController ot = cols[f].GetComponent<UnitController>();
					if(ot!=null && !ot.teamID.Equals(teamID) && !enemies.Contains(ot))
					{
						enemies.Add(ot);
					}
				}
			}
		}
		if(enemies.Count>0)
		{
			nearestEnemyDist = (enemies[0].Location-Location).sqrMagnitude; //Vector3.Distance(Location,enemies[0].Location);
			for(int f = 0; f<enemies.Count;f++)
			{
				if(enemies[f].isActive)
				{
					newDist = (enemies[f].Location-Location).sqrMagnitude;//Vector3.Distance(Location,unit.Location);
					if(newDist <= nearestEnemyDist)
					{
						nearestEnemyDist = newDist;
						enemy = enemies[f];
					}
				}
			}
		}

		return enemy;
	}
	protected void TargetLost(int id)
	{
		if(targetEnemy!=null && id == targetEnemy.unitID)
		{
			enemies.Clear();
			targetEnemy = null;
			target = null;
			animSpeed = 0f;
			//ArrivedAtTargetLocation();
		}
	}
}
