using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public AudioMixer mixer;
    public float volume;
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        mixer.GetFloat("musicvol", out volume);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
            volume++;
        if (Input.GetKeyDown(KeyCode.Minus))
            volume--;
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0f;
                mixer.SetFloat("cutoffreq", 500f);
            }
            else
            {
                Time.timeScale = 1f;
                mixer.SetFloat("cutoffreq", 22000f);
            }
        }

        volume = Mathf.Clamp(volume, -80f, 20f);
        mixer.SetFloat("musicvol", volume);
    }
}
