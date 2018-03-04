using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantAI : MonoBehaviour, IHealth
{
	/*	Behaviors:
	 * 		Mill about
	 * 		Raise Alarm
	 * 		Flee
	 */
	private enum Behaviour{Flee, Work, Alert}
	Behaviour currentState;

	public AudioClip death;
	public AudioClip hit;
	[SerializeField] Transform target;
	[SerializeField] int startHealth = 3;
	UnitMover mover;
	Vector3 movement;
	SpriteRenderer spriteRenderer;
	Animator anim;
	int health;
	Color original;
	bool alertRaised, spotEnemy;

	void OnEnable()
	{
		health = startHealth;
	}
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
		mover = GetComponent<UnitMover>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		original = spriteRenderer.color;

	}

	void Update()
	{
		if(target!=null)
		{
			movement = (target.position-transform.position).normalized;
			mover.Move(movement);
			if(anim.runtimeAnimatorController!=null)
			{
				anim.SetFloat("X",movement.x);
				anim.SetFloat("Y",movement.y);
				anim.SetFloat("Speed", movement.magnitude);
			}
			//			Vector3 targetDir  = transform.position + (movement * moveSpeed * Time.deltaTime);//paranthesis for clarity
			//			transform.position = Vector3.MoveTowards(transform.position,targetDir,1f);
		}
	}

	void AsessSituation()
	{
		if(alertRaised)
		{
			if(currentState!= Behaviour.Flee)
			currentState = Behaviour.Flee;
		}
	}
	public void TakeDamage(int amount)
	{
		health -=amount;
		if(health<=0)
		{
			Die();
		}else
		{
			//SoundManager.instance.PlaySingle(hit);
			spriteRenderer.color = Color.white;
			StartCoroutine(FlashDamage());
		}
	}
	IEnumerator FlashDamage()
	{
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = original;
	}
	public void Die ()
	{
		this.gameObject.SetActive(false);
		//SoundManager.instance.PlaySingle(death);
		StopCoroutine(FlashDamage());
		spriteRenderer.color = original;
	}

	public void Heal(int Amount)
	{}
}
