using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifepickup : MonoBehaviour
{
    [SerializeField] AudioClip heal; //sound insert

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().AddLife(); //adds score
        AudioSource.PlayClipAtPoint(heal, Camera.main.transform.position); //plays sound
        Destroy(gameObject); //destroys it so its not infinite
    }
}
