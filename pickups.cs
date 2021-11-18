using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObject(gameObject); //when touching the object delete it
    }
}