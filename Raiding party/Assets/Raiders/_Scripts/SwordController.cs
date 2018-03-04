using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : Weapon 
{
	Animator anim;
	[SerializeField]LayerMask mask;

	void Start()
	{
		//anim = transform.root.GetComponent<Animator>();
	}
	void LateUpdate()
	{
		if(isEquipped)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
//			transform.rotation = rot;
			
			if(Vector3.Dot(mousePos-transform.position,Vector3.right)>0)//mouse is to the right of us
			{
				//transform.eulerAngles = new Vector3 (0, 0, -50);
				//GetComponent<SpriteRenderer>().flipY = false;

			}else
			{
				//transform.eulerAngles = new Vector3 (0, 0, 50);
				//GetComponent<SpriteRenderer>().flipY = true;
			}
		}
	}

	public override void PrimaryAttack(Vector2 direction)
	{
		//anim.SetTrigger("Swing");
		transform.parent.parent.GetComponent<BoxCollider2D>().enabled = false;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, 1f, mask);
		if (hit.collider!=null && !hit.collider.CompareTag("Player")) 
		{
			Debug.DrawRay(transform.position, transform.up);
			var enemy = hit.collider.GetComponent<IHealth>();
			if(enemy!=null)
				enemy.TakeDamage(1);
		}
		transform.parent.parent.GetComponent<BoxCollider2D>().enabled = true;

	}
	public override void SecondaryAttack(Vector2 direction)
	{

	}
	public override void Equip()
	{}
	public override void UnEquip()
	{}
}
