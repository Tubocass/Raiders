using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMover : MonoBehaviour 
{
	public Vector3 targetDir = Vector3.down;
	[SerializeField] float moveSpeed;
	Transform tran;
	NavMeshAgent agent;
	Rigidbody2D rigid;
	void Start () 
	{
		tran = transform;
		rigid = GetComponent<Rigidbody2D>();
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		float lastInputX = Input.GetAxis ("Horizontal");
//		float lastInputY = Input.GetAxis ("Vertical");
//
//		if(lastInputX != 0f || lastInputY != 0f)
//		{
//			movement = new Vector3(lastInputX, lastInputY, 0);
//			Vector3 targetDir  = tran.position + movement * moveSpeed * Time.deltaTime;
//			tran.position = Vector3.MoveTowards(tran.position,targetDir,1f);
//		}
//	}

	public void MoveTo(Vector3 destination)
	{
		if(agent!=null)
		{
			agent.SetDestination(destination);
		}
	}
	public void Move(Vector3 direction)
	{
//		direction = direction/direction.magnitude;
		targetDir  = tran.position + direction * moveSpeed * Time.deltaTime;
		if(rigid!=null)
		{
			rigid.MovePosition(targetDir);
		}
		else{
			tran.position = Vector3.MoveTowards(tran.position,targetDir,1f);
		}
	}
	public void Stop()
	{
		if(rigid!=null)
		{
			rigid.velocity = Vector2.zero;
		}
		else{
			tran.position = Vector3.MoveTowards(tran.position,tran.position,0f);
		}
	}
}
