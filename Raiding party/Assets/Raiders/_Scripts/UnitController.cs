using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour 
{
	public static int TotalCreated;
	public int unitID, teamID;
	public Vector3 Location{get{return transform.position;}}
	public bool isActive{get{return gameObject.activeSelf;}set{gameObject.SetActive(value); if(value==false)OnDisable();}}
	[SerializeField] protected LayerMask mask;
	[SerializeField] protected float refractoryPeriod;
	[SerializeField] protected int attackStrength;
	protected Collider2D myCollider;
	protected UnitMover mover;
	protected Vector3 movement;
	protected Animator anim;
	protected Weapon currentWeapon;
	protected float speed = 1f;
	protected bool canAttack = true;

	protected virtual void OnEnable()
	{

	}
	protected virtual void OnDisable()
	{

	}
	protected virtual void Start()
	{

		myCollider = GetComponent<Collider2D>();
		anim = GetComponent<Animator>();
		mover = GetComponent<UnitMover>();
		unitID = TotalCreated;
		TotalCreated+=1;
		//		if(weapon!=null)
		//		{
		//			currentWeapon = weapon.GetComponent<Weapon>();
		//		}
	}
	public virtual void Attack()
	{
		if(canAttack)
		{
			canAttack = false;
			StartCoroutine(AttackCooldown());
			myCollider.enabled = false;
			Vector3 dir = new Vector3(anim.GetFloat("X"), anim.GetFloat("Y"));
			Debug.DrawRay(transform.position, dir);
			anim.SetTrigger("Swing");

			RaycastHit2D hit = Physics2D.Raycast (transform.position, dir, 1f, mask);
			if (hit.collider!= null && hit.collider.GetComponent<EnemyController>().teamID!= teamID) 
			{
				var enemy = hit.collider.GetComponent<IHealth>();
				if(enemy!=null)
					enemy.TakeDamage(1);
				//myWeapon.PrimaryAttack(Vector2.zero);
			}
			myCollider.enabled = true;
		}
	}
	protected IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(refractoryPeriod);
		canAttack = true;
	}
}
