using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour 
{
	[SerializeField] int variable = 0;//, SecondValue = 0;
	[SerializeField] string variableName;//, SecondString;
	Text text;

	void Start()
	{
		variableName +=": ";
		//SecondString +=": ";
		text = GetComponent<Text>();
		text.text =  string.Format("{0} {1}", variableName, variable);
		//GetComponent<Text>().text =  string.Format("{0} {1}  {2} {3}",FirstString, FirstValue, SecondString, SecondValue);
		//UnityEventManager.StartListeningInt("Score", AddPoints);
		UnityEventManager.StartListening(variableName+"Event", AddValue);
	}
	void OnDisable()
	{
		//UnityEventManager.StopListeningInt("Score", AddPoints);
		UnityEventManager.StopListening(variableName+"Event", AddValue);
	}
	void OnGUI()
	{
		text.text =  string.Format("{0} {1}", variableName, variable);
		//GetComponent<Text>().text =  string.Format("{0} {1} {2} {3}",FirstString, FirstValue, SecondString, SecondValue);
	}

	public void Reset()
	{
		variable = 0;
		//SecondValue = 1;
	}
//	public void AddPoints(int amount)
//	{
//		FirstValue+= SecondValue*amount;
//	
//	}
	public void AddValue()
	{
		variable++;
	}
}
