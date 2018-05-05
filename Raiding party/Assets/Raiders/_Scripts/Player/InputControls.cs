using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControls : UnitController 
{
	PlayerHealth myHealth;
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
		canPickupTreasure = true;
		myHealth = GetComponent<PlayerHealth>();
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
			movement.Set(lastInputX, 0, lastInputY);
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
			Attack(movement);
		}
	}
		
	protected override void OnTriggerEnter(Collider bam)
	{
		base.OnTriggerEnter(bam);
	}
}
