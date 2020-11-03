using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInputs : MonoBehaviour
{
    private int xpos = 10;
    private GUIStyle guiStyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        string[] strings = {
                    "Horiz.: " + Input.GetAxis("Horizontal") ,
                    "Vert. : " + Input.GetAxis("Vertical"),
                    "Fire1 : " + Input.GetButton("Fire1"),
                    "Fire2 : " + Input.GetButton("Fire2"),
                    "Fire3 : " + Input.GetButton("Fire3"),
                    "MouseX: " + Input.GetAxis("Mouse X"),
                    "MouseY: " + Input.GetAxis("Mouse Y"),
                    "M. Pos: " + Input.mousePosition
                };
        int ypos = 10;
        foreach (string str in strings)
        {
            GUI.Label(new Rect(xpos, ypos, 100, 20), str, guiStyle);
            ypos += 20;
        }
    }
}
