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
			movement = new Vector3(lastInputX, lastInputY);
			mover.Move(movement);
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
