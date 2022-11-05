using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    AudioSource AudioMic;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        StartCoroutine(CaptureMic());
    }

    IEnumerator CaptureMic()
    {
        if (AudioMic == null) AudioMic = GetComponent<AudioSource>();
        AudioMic.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        AudioMic.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        Debug.Log("Start Mic(pos): " + Microphone.GetPosition(null));
        AudioMic.Play();

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
