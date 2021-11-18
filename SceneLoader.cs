using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void LoadNextScene() //Next Scene
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
	public void LoadPrevScene() //Previous Scene
    {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex - 1);
	}
	public void LoadStartScene() //Start
    {
		SceneManager.LoadScene(0);
    }
	public void QuitGame() //Close Game
    {
		Application.Quit();
    }
}
