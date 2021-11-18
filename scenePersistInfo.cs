using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenePersistInfo : MonoBehaviour
{
    [SerializeField] int initialSceneIndex;

    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<scenePersistInfo>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        initialSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != initialSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
