using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    [SerializeField] AudioClip boom; //sound insert

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int score = FindObjectOfType<GameManager>().score;
        if (score >= 2) 
        {
            DestroyObject(gameObject); FindObjectOfType<GameManager>().AddScore(-2); //removes boom2
            AudioSource.PlayClipAtPoint(boom, Camera.main.transform.position); //plays sound
        };
    }
}