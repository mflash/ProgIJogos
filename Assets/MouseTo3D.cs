using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTo3D : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        RaycastHit rayCastInfo;
        if (Physics.Raycast(ray, out rayCastInfo))
            print(rayCastInfo.transform.gameObject.name
             + " - " + rayCastInfo.point);
    }
}
