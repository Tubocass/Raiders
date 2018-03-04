using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControls : MonoBehaviour 
{
	[SerializeField] LayerMask mask;
	UnitMover mover;
	Animator anim;
	BoxCollider2D myCollider;
	PlayerHealth myHealth;
	PlayerWeapon myWeapon;
	bool canAttack = true;
	float lastInputX, lastInputY;

	void Start()
	{
		myCollider = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		mover = GetComponent<UnitMover>();
		myHealth = GetComponent<PlayerHealth>();
		myWeapon = GetComponent<PlayerWeapon>();
	}

	void Update () 
	{
		lastInputX = Input.GetAxisRaw ("Horizontal");
		lastInputY = Input.GetAxisRaw ("Vertical");
		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		float lastInputScroll = Input.GetAxis("Mouse ScrollWheel");
//		if(lastInputScroll>0f || lastInputScroll<0f)
//		{
//			Camera.main.orthographicSize -= lastInputScroll* scrollSpeed;
//			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minFOV, maxFOV);
//		}
//
		if(lastInputX != 0f || lastInputY != 0f)
		{
			mover.Move(new Vector3(lastInputX, lastInputY));
			anim.SetFloat("X",lastInputX);
			anim.SetFloat("Y",lastInputY);
			anim.SetFloat("Speed", 1);
		}else {
			anim.SetFloat("Speed", 0);
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			if(canAttack)
			{
				canAttack = false;
				StartCoroutine(CoolDown());
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
	}

	IEnumerator CoolDown()
	{
		float time = 0;
		while(time<0.25f)
		{
			time+= Time.deltaTime;
			yield return null;
		}
		canAttack = true;
	}

	void OnTriggerEnter2D(Collider2D bam)
	{
		if(bam.CompareTag("Treasure")&& bam.GetComponent<Renderer>().enabled)
		{
			IPickup pickup = bam.GetComponent<IPickup>();
			//if(pickup.item.CompareTag("Health"))
			{
				//myHealth.Heal(6);
			}
			//if(pickup.item.CompareTag("Weapon"))
			{
				//myWeapon.EquipWeapon(pickup.item);
				pickup.Pickup();
			}
			bam.gameObject.SetActive(false);
		}
	}
}
