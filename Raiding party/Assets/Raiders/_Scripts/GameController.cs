using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public string Starlevel;
	public void StartGame()
	{
		SceneManager.LoadScene(Starlevel);
	}
}
