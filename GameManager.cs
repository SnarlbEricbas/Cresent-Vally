using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 1; //lives count
    [SerializeField] public int score = 0; //score count
    [SerializeField] Text life; //to connect life to ui textbox
    [SerializeField] Text tasks; //to connect score to ui textbox

    private void Awake() //when it starts up
    {
        int numGameManager = FindObjectsOfType<GameManager>().Length;
        if (numGameManager > 1)
        {
            Destroy(gameObject); //destroy if game manager exists
        }
        else
        {
        }
    }

    public void ProcessPlayerDeath() //if player is hurt this function goes off
    {
        if(playerLives > 1) //if character revives then reduce life by 1 and update textbox
        {
            ReduceLife();
            life.text = playerLives.ToString();
        }
        else
        {
            ResetGame(); //person is dead game resets
        }
        
    }

    public void AddScore(int scoreToBeAdded) //updates score after getting a point
    {
        score = score + scoreToBeAdded;
    }

    public void AddLife() //updates score after getting a point
    {
        playerLives++;
    }

    private void ReduceLife() //takes away life and restarts the level
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGame() //loads the lose scene and destroys current self
    {
        SceneManager.LoadScene(6);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        tasks.text = score.ToString(); //textbox
        life.text = playerLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tasks.text = score.ToString(); //updates textbox
        life.text = playerLives.ToString();
    }

    public void ResetScore() //resets count for level transitions
    {
        score = 0;
        playerLives = 1;
    }
}
