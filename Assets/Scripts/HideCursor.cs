using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MusicLobby") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Music Terra new")){
            Cursor.visible = false;
        }
    }
}
