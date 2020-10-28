using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSeno : MonoBehaviour
{
    [Range(0.001f,10)]
    public float frameIncrement;
    public Color myColor;
    public float WaveLength = 5f;
    public float WaveAmplitude = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var lastPos = pos;
        pos.x += frameIncrement * Time.deltaTime;
        pos.z = Mathf.Sin(pos.x * 2 * Mathf.PI/WaveLength) * WaveAmplitude/2;
        transform.forward = pos - lastPos;
        transform.position = pos;
    }

}
  