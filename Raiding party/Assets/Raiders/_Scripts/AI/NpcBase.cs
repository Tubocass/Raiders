using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBase : UnitController 
{
	[SerializeField] protected UnitController Leader;
	[SerializeField] protected bool allowedToFight = false, isFollowing = false;
	protected Transform target;
	protected UnitController targetEnemy;

	protected List<T> FindTargets<T>(string tag, Predicate<T> boo)
	{
		List<T> targets = new List<T>();
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 50, mask);
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
	protected virtual T TargetNearest<T>(List<T> targets) where T:Component
	{
		float nearestDist, newDist;
		T nearestTarget = null;

		if(targets.Count>0)
		{
			nearestDist = (targets[0].transform.position-Location).sqrMagnitude; //compare the squared distances
			for(int f = 0; f<targets.Count;f++)
			{
				if(targets[f]!= null && targets[f].gameObject.activeSelf)
				{
					newDist = (targets[f].transform.position-Location).sqrMagnitude;//compare the squared distances
					if(newDist <= nearestDist)
					{
						nearestDist = newDist;
						nearestTarget = targets[f].GetComponent<T>();
					}
				}
			}
		}

		return nearestTarget;
	}

	protected bool IsTargetingEnemy()
	{
		if(targetEnemy!=null && targetEnemy.isActive)
			return true;
		else return false;
	}
	protected void TargetLost(int id)
	{
		if(targetEnemy!=null && id == targetEnemy.unitID)
		{
			//targets.Clear();
			targetEnemy = null;
			target = null;
			animSpeed = 0f;
		}
	}
}
