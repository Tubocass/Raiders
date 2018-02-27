using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControls : MonoBehaviour 
{
	[SerializeField] LayerMask mask;
	UnitMover mover;
	Animator anim;
	PlayerHealth myHealth;
	//PlayerWeapon myWeapon;

	void Start()
	{
		anim = GetComponent<Animator>();
		mover = GetComponent<UnitMover>();
		myHealth = GetComponent<PlayerHealth>();
		//myWeapon = GetComponent<PlayerWeapon>();
	}

	void Update () 
	{
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//		float lastInputScroll = Input.GetAxis("Mouse ScrollWheel");
//		if(lastInputScroll>0f || lastInputScroll<0f)
//		{
//			Camera.main.orthographicSize -= lastInputScroll* scrollSpeed;
//			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minFOV, maxFOV);
//		}
//
		if(lastInputX != 0f || lastInputY != 0f)
		{
			Vector2 movement = new Vector2(lastInputX, lastInputY);
			mover.Move(new Vector3(lastInputX, lastInputY));
//			anim.SetFloat("X",lastInputX);
//			anim.SetFloat("Y",lastInputY);
//			anim.SetFloat("Speed", movement.magnitude);
		}

		if (Input.GetMouseButton (0)) 
		{
			 //Camera.main.ScreenPointToRay (Input.mousePosition);

			GetComponent<BoxCollider2D>().enabled = false;
			RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, 1f, mask);
			if (hit.collider!=null && !hit.collider.CompareTag("Player")) 
			{
				Debug.DrawRay(transform.position, transform.up);
				//myWeapon.PrimaryAttack(dir);
			}
			GetComponent<BoxCollider2D>().enabled = true;
		}
		if (Input.GetMouseButtonUp (1)) 
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 20f, mask)) 
			{
				Vector3 dir = hit.point-transform.position;
				dir = dir/dir.magnitude;
				//myWeapon.SecondaryAttack(dir);
			}

		}
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
