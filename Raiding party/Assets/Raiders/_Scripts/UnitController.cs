using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour 
{
	public static int TotalCreated;
	public int unitID, teamID;
	public UnitMover mover;
	public Vector3 Location{get{return transform.position;}}
	public bool isActive{get{return gameObject.activeSelf;}set{if(value==false)OnDisable(); gameObject.SetActive(value); }}

	[SerializeField] protected GameObject treasureDrop;
	[SerializeField] protected LayerMask mask;
	[SerializeField] protected float refractoryPeriod, distToFeet = 0.35f;
	[SerializeField] protected int attackStrength;

	protected Collider myCollider;
	protected Vector3 movement = Vector3.zero;
	protected Animator anim;
	protected float animSpeed = 1f;
	protected bool canAttack = true;
	protected bool bCarryingTreasure = false, canPickupTreasure = false;
	Treasure carriedTreasure;

	protected virtual void OnEnable()
	{

	}
	protected virtual void OnDisable()
	{

	}
	protected virtual void Start()
	{

		myCollider = GetComponent<Collider>();
		anim = GetComponent<Animator>();
		if(anim==null)
			anim = GetComponentInChildren<Animator>();
		mover = GetComponent<UnitMover>();
		unitID = TotalCreated;
		TotalCreated+=1;
		//transform.position = new Vector3(Location.x,Location.y,ZOrderer.NormalZ(Location.y));
		//		if(weapon!=null)
		//		{
		//			currentWeapon = weapon.GetComponent<Weapon>();
		//		}
	}
	public virtual void Update()
	{
		//transform.position = new Vector3(Location.x, ZOrderer.NormalHeight(Location.z-distToFeet), Location.z);
	}
	public void Animate()
	{
		if(anim.runtimeAnimatorController!=null)
		{
			anim.SetFloat("X",movement.x);
			anim.SetFloat("Y",movement.z);
			anim.SetFloat("Speed", animSpeed);
		}
	}
	public void Animate(Vector3 dir, float speed)
	{
		if(anim.runtimeAnimatorController!=null)
		{
			anim.SetFloat("X",dir.x);
			anim.SetFloat("Y",dir.z);
			anim.SetFloat("Speed", speed);
		}
	}
	public virtual void Attack(Vector3 dir)
	{
		if(canAttack)
		{
			canAttack = false;
			StartCoroutine(AttackCooldown());
			myCollider.enabled = false;
			anim.SetTrigger("Swing");
			//RaycastHit[] results = new RaycastHit[10];
			RaycastHit hit = new RaycastHit();
			Debug.DrawRay(Location, dir);
			if(Physics.Raycast(Location, dir, out hit, 2, mask))
			{
				UnitController uni;
//				for(int r=0; r<results.Length-1;r++)
//				{
				if(hit.collider!=null)
					{
						uni = hit.collider.GetComponent<UnitController>();
						if (uni!= null && uni.teamID!= teamID) 
						{
							var enemyHealth = uni.GetComponent<IHealth>();
							if(enemyHealth!=null)
								enemyHealth.TakeDamage(attackStrength);
							//myWeapon.PrimaryAttack(Vector2.zero);
						}
					}
//				}
			}
//			RaycastHit2D hit = Physics2D.Raycast (transform.position, dir, 1f, mask);
//			if (hit.collider!= null && hit.collider.GetComponent<UnitController>().teamID!= teamID) 
//			{
//				var enemy = hit.collider.GetComponent<IHealth>();
//				if(enemy!=null)
//					enemy.TakeDamage(1);
//				//myWeapon.PrimaryAttack(Vector2.zero);
//			}
			myCollider.enabled = true;
		}
	}
	protected IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(refractoryPeriod);
		canAttack = true;
	}
	public bool IsFacingWall(Vector3 dir)
	{
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast (transform.position+(dir*0.3f), dir, 0.2f, mask))
		{
			if (hit.collider!= null && hit.collider.CompareTag("Impass")) 
			{
				return true;
			}
		}
		return false;
	}
	public void Dead()
	{
		GameObject.Instantiate(treasureDrop,Location,Quaternion.identity);
		isActive = false;
		UnityEventManager.TriggerEvent("TargetUnavailable",unitID);
	}
	protected virtual void OnTriggerEnter(Collider bam)
	{
		if(bam.CompareTag("Treasure")&& canPickupTreasure && !bCarryingTreasure)
		{
			Treasure pickup = bam.GetComponent<Treasure>();//treasure implements IPickup
			if(pickup.IsAvailable)
			{
				pickup.Pickup(transform);
				bCarryingTreasure = true;
				carriedTreasure = pickup;
			}
			//bam.gameObject.SetActive(false);
		}
		if(bam.CompareTag("Capture") && carriedTreasure!=null)
		{
			UnityEventManager.TriggerEvent("TreasureEvent", carriedTreasure.Value);
			bCarryingTreasure = false;
			carriedTreasure.PutDown();
			carriedTreasure = null;
		}
	}
//	protected virtual void OnTriggerStay2D(Collider2D other)
//	{
//		if(other.CompareTag("Impass"))
//		{
//			Debug.Log("stop!");
//			movement = Vector3.zero;
//			mover.Stop();
//		}
//	}
//	protected virtual void OnCollisionEnter2D(Collision2D other)
//	{
//		if(other.collider.CompareTag("Impass"))
//		{
//			Debug.Log("stop!");
//			movement = Vector3.zero;
//			mover.Move(movement);
//		}else return;
//	}
}
