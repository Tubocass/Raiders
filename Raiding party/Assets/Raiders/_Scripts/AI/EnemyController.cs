using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour 
{
	public static int TotalCreated;
	public int unitID, teamID;
	public Vector3 Location{get{return transform.position;}}
	public bool isActive{get{return gameObject.activeSelf;}set{gameObject.SetActive(value); if(value==false)OnDisable();}}
	[SerializeField] Transform target;
	[SerializeField] GameObject weapon;
	[SerializeField] LayerMask mask;
	[SerializeField] float refractoryPeriod;
	[SerializeField] int attackStrength;
	EnemyController targetEnemy;
	List<EnemyController> enemies = new List<EnemyController>();
	Weapon currentWeapon;
	BoxCollider2D myCollider;
	UnitMover mover;
	Vector3 movement;
	Animator anim;
	float speed = 1f;
	bool canAttack = true;

	void OnEnable()
	{
		UnityEventManager.StartListeningInt("TargetUnavailable", TargetLost);
	}
	void OnDisable()
	{
		UnityEventManager.StopListeningInt("TargetUnavailable", TargetLost);
	}
	void Start()
	{
		targetEnemy = TargetNearest();
		myCollider = GetComponent<BoxCollider2D>();
		if(targetEnemy!=null)
		target = targetEnemy.transform;
		anim = GetComponent<Animator>();
		mover = GetComponent<UnitMover>();
		unitID = TotalCreated;
		TotalCreated+=1;
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
				movement = (target.position-transform.position).normalized;
				speed = 1f;
				mover.Move(movement);
			}
		}else{
			targetEnemy = TargetNearest();
		}
		Animate();
//		if(target!=null && Vector3.Distance(transform.position,target.position)>1f)
//		{
//			movement = (target.position-transform.position).normalized;
//			mover.Move(movement);
////			if(anim.runtimeAnimatorController!=null)
////			{
////				anim.SetFloat("X",movement.x);
////				anim.SetFloat("Y",movement.y);
////				anim.SetFloat("Speed", 1f);
////			}
//		}else{
//			//anim.SetFloat("Speed", 0f);
//		}
	}
	protected void ArrivedAtTargetLocation()
	{

			if(IsTargetingEnemy())
			{
				if(canAttack && Vector3.Distance(Location,targetEnemy.Location)<1f)
				{
					Attack();
				}else{
					//MoveTo(targetEnemy.Location);
				}
//			}else {
//				targetEnemy = TargetNearest();
//				if(targetEnemy!=null)
//				{
//					MoveTo(targetEnemy.Location);
//				}else MoveRandomly(myMoM.FightAnchor,orbit);
			}

	}
	bool IsTargetingEnemy()
	{
		if(targetEnemy!=null && targetEnemy.isActive)
			return true;
		else return false;
	}
	void Attack()
	{
		if(canAttack)
		{
			canAttack = false;
			StartCoroutine(AttackCooldown());
			myCollider.enabled = false;
			Vector3 movement = new Vector3(anim.GetFloat("X"), anim.GetFloat("Y"));
			Debug.DrawRay(transform.position, movement);
			anim.SetTrigger("Swing");

			RaycastHit2D hit = Physics2D.Raycast (transform.position, movement, 1f, mask);
			if (hit.collider!= null && hit.collider!= myCollider) 
			{
				var enemy = hit.collider.GetComponent<IHealth>();
				if(enemy!=null)
					enemy.TakeDamage(1);
				//myWeapon.PrimaryAttack(Vector2.zero);
			}
			myCollider.enabled = true;
		}
	}
	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(refractoryPeriod);
		canAttack = true;
	}
	EnemyController TargetNearest()
	{
		float nearestEnemyDist, newDist;
		EnemyController enemy = null;

		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position,100,mask);
		if(cols.Length>0)
		{
			foreach(Collider2D f in cols)
			{
				if(f.CompareTag("Unit"))
				{
					EnemyController ot = f.GetComponent<EnemyController>();
					if(ot!=null && !ot.teamID.Equals(teamID) && !enemies.Contains(ot))
					{
						enemies.Add(ot);
						Debug.Log(ot.name);
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
