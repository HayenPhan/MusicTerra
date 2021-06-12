using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string LevelName;
    //public int LevelIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        Debug.Log("Hello: ");
        // This loads in the background, it will teleport you to the scene when done.
        SceneManager.LoadScene(LevelName);
    }
}
