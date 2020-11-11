using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColor : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnClicked += TurnColorNow;
    }

    void OnDisable()
    {
        EventManager.OnClicked -= TurnColorNow;
    }

    void TurnColorNow()
    {
        Color color = new Color(UnityEngine.Random.value,
        UnityEngine.Random.value, UnityEngine.Random.value);
        GetComponent<Renderer>().material.color = color;
    }
}
