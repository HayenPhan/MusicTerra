using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // roomCam = GameObject.Find("Camera");
        // DestroyImmediate(roomCam);
        Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
              Destroy(cam);
              Debug.Log("Test");
    }
}
