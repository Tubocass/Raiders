﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcBase : UnitController 
{
	[SerializeField] protected UnitController Leader;
	[SerializeField] protected bool allowedToFight = false, isFollowing = false;
	public List<UnitController> enemies = new List<UnitController>();
	protected Transform target;
	protected UnitController targetEnemy;
	NavMeshAgent agent;
	protected float pursuitRange = 50f;

	protected override void OnEnable()
	{
		base.OnEnable();
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
	}
	public IBehaviourState BehaviourState 
	{
		get{ return behaviourState; }
		set 
		{
			if (behaviourState != null)
			{
				behaviourState.ExitState ();
			}
			behaviourState = value;
			behaviourState.EnterState ();
		}
	}
	private IBehaviourState behaviourState;

	public static List<T> FindTargets<T>(string tag, Vector3 position, float distance, LayerMask mask , Predicate<T> boo)
	{
		List<T> targets = new List<T>();
		//Collider2D[] cols = Physics2D.OverlapCircleAll(position, distance, mask);
		Collider[] cols = Physics.OverlapSphere(position, distance, mask);
		if(cols.Length>0)
		{
			for(int f = 0; f<cols.Length;f++)
			{
				if(cols[f].CompareTag(tag))
				{
					var c = cols[f].GetComponent<T>();
					if(boo.Invoke(c))
						targets.Add(cols[f].gameObject.GetComponent<T>());
				}
			}
		}
		return targets;
	}
//	UnitController TargetNearest()
	//	{
	//		float nearestEnemyDist, newDist;
	//		UnitController enemy = null;
	//
	//		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,50,mask);
	//		if(cols.Length>0)
	//		{
	//			for(int f = 0; f<cols.Length-1;f++)
	//			{
	//				if(cols[f].CompareTag("Unit"))
	//				{
	//					UnitController ot = cols[f].GetComponent<UnitController>();
	//					if(ot!=null && !ot.teamID.Equals(teamID) && !enemies.Contains(ot))
	//					{
	//						enemies.Add(ot);
	//					}
	//				}
	//			}
	//		}
	//		if(enemies.Count>0)
	//		{
	//			nearestEnemyDist = (enemies[0].Location-Location).sqrMagnitude; //Vector3.Distance(Location,enemies[0].Location);
	//			for(int f = 0; f<enemies.Count;f++)
	//			{
	//				if(enemies[f].isActive)
	//				{
	//					newDist = (enemies[f].Location-Location).sqrMagnitude;//Vector3.Distance(Location,unit.Location);
	//					if(newDist <= nearestEnemyDist)
	//					{
	//						nearestEnemyDist = newDist;
	//						enemy = enemies[f];
	//					}
	//				}
	//			}
	//		}
	//
	//		return enemy;
	//	}
	public static T TargetNearest<T>(Vector3 position ,List<T> targets) where T:Component
	{
		float nearestDist, newDist;
        int targetIndex = 0;
		T nearestTarget = null;

		if(targets.Count>0)
		{
			nearestDist = (targets[0].transform.position-position).sqrMagnitude; //compare the squared distances
			for(int f = 0; f<targets.Count;f++)
			{
				if(targets[f]!= null && targets[f].gameObject.activeSelf)
				{
					newDist = (targets[f].transform.position-position).sqrMagnitude;//compare the squared distances
					if(newDist <= nearestDist)
					{
						nearestDist = newDist;
                        targetIndex = f;
					}
				}
			}
            nearestTarget = targets[targetIndex].GetComponent<T>();
		}

		return nearestTarget;
	}

	public UnitController NearestEnemy()
	{
		enemies = FindTargets<UnitController>("Unit", Location, pursuitRange, mask, u=> u.isActive && !u.teamID.Equals(teamID));
        enemies.AddRange(collection: FindTargets<UnitController>("Player", Location, pursuitRange, mask, u => u.isActive && !u.teamID.Equals(teamID)));
		targetEnemy = TargetNearest(Location, enemies);
		if(targetEnemy!=null)
		{
			return targetEnemy;
		}
		else return null;
	}

	protected virtual void EnemiesAround()
	{
	}
}
