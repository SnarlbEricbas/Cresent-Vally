using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //character touch = next level
    {
        StartCoroutine(loadnextlevel());
    }

    IEnumerator loadnextlevel() //function to load next level
    {
        Time.timeScale = 0.1f; //slow mo
        yield return new WaitForSecondsRealtime(2f); //wait 2 seconds
        Time.timeScale = 1f; //regular speed
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex; //gets active level
        SceneManager.LoadScene(currentLevelIndex + 1); //proceeds to next level
        FindObjectOfType<GameManager>().ResetScore(); //resets score
    }
}
