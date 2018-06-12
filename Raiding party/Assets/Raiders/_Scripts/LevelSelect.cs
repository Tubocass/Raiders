using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string startlevel;
    public void LoadLevel()
    {
        SceneManager.LoadScene(startlevel);
    }
}
