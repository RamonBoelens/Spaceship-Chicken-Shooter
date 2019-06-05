using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public void LoadThisLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
    
}
