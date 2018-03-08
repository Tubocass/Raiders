using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour, IHealth
{
	public AudioClip death;
	public AudioClip hit;
	[SerializeField] int startHealth = 3;
	SpriteRenderer spriteRenderer;
	Color original;
	int health;
	UnitController controller;
	//bool isDead = false;

	void OnEnable()
	{
		controller = GetComponent<UnitController>();
		health = startHealth;
		spriteRenderer = GetComponent<SpriteRenderer>();
		original = spriteRenderer.color;
	}

	public void Heal(int Amount)
	{}

	public void TakeDamage(int amount)
	{
		health -=amount;
		if(health<=0)
		{
			Die();
		}else
		{
			//SoundManager.instance.PlaySingle(hit);
			spriteRenderer.color = Color.yellow;
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
		//UnityEventManager.TriggerEvent("Score",pointValue);
		//SoundManager.instance.PlaySingle(death);
		UnityEventManager.TriggerEvent("TargetUnavailable",GetComponent<UnitController>().unitID);
		controller.Dead();
		StopCoroutine(FlashDamage());
		spriteRenderer.color = original;
		this.gameObject.SetActive(false);
	}
}
