using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControls : UnitController 
{
	PlayerHealth myHealth;
	PlayerWeapon myWeapon;
	float lastInputX, lastInputY;

	protected override void OnEnable()
	{
		base.OnEnable();
	}
	protected override void OnDisable()
	{
		base.OnDisable();
	}
	protected override void Start()
	{
		base.Start();
		myHealth = GetComponent<PlayerHealth>();
		myWeapon = GetComponent<PlayerWeapon>();
	}

	public override void Update()
	{
		base.Update();
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
			movement.Set(lastInputX, lastInputY, 0);
			if(!IsFacingWall(movement))
			{
				mover.Move(movement);
			}
			animSpeed = 1f;
		}else {
			animSpeed = 0f;
		}
			
		Animate();
		if (Input.GetMouseButtonDown (0)) 
		{
			Attack();
		}
	}

	bool IsBlocked(Vector3 dir)
	{
		RaycastHit2D hit = Physics2D.Raycast(Location,dir,1,mask);
		if(hit.collider!=null&& hit.collider.CompareTag("Impass"))
		{
			Debug.Log("Blocked");
			return true;
		}else{
			return false;
		}
	}
	protected override void OnTriggerEnter2D(Collider2D bam)
	{
		base.OnTriggerEnter2D(bam);
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
