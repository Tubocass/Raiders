using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class EnemyController : UnitController 
{
	[SerializeField] GameObject weapon;
	UnitController targetEnemy;
	List<UnitController> enemies = new List<UnitController>();

	protected override void OnEnable()
	{
		base.OnEnable();
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
//		if(weapon!=null)
//		{
//			currentWeapon = weapon.GetComponent<Weapon>();
//		}
	}
	void Animate()
	{
		if(anim.runtimeAnimatorController!=null)
		{
			anim.SetFloat("X",movement.x);
			anim.SetFloat("Y",movement.y);
			anim.SetFloat("Speed", speed);
		}
	}
	void Update()
	{
		if(IsTargetingEnemy())
		{
			if(Vector3.Distance(Location,targetEnemy.Location)<1f)
			{
				if(canAttack)
				{
					Attack();
				}
				speed = 0f;
			}else{
				movement = (targetEnemy.Location-Location).normalized;
				speed = 1f;
				mover.Move(movement);
			}
		}else{
			targetEnemy = TargetNearest();
		}
		Animate();
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

		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,100,mask);
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
			//ArrivedAtTargetLocation();
		}
	}

}
