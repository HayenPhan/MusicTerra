using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherOnclick : MonoBehaviour
{
    // Start is called before the first frame update
    public void playGame(string scene_name)
    {
        Debug.Log("TEST");
        // This loads in the background, it will teleport you to the scene when done.

        SceneManager.LoadScene(scene_name);
    }
    // Update is called once per frame

    void Update() {
        Cursor.lockState = CursorLockMode.None;
    }
}
