using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coin; //sound insert

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddScore(1); //adds score
        AudioSource.PlayClipAtPoint(coin, Camera.main.transform.position); //plays sound
        Destroy(gameObject); //destroys it so its not infinite
    }
}
