using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public Transform plane;
    public float speed = 2;
    private Mesh mesh;
    private Vector3 min;
    private Vector3 max;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        mesh = plane.GetComponent<MeshFilter>().mesh;
        min = mesh.bounds.min;
        max = mesh.bounds.max;
        Debug.Log(min);
        Debug.Log(max);
        target = transform.position;
        // print($"Target: {target}");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 lastPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        // Sem isso, vai dar um aviso quando forem iguais!
        //if(transform.position == lastPos)  // funciona neste caso porque o MoveTowards garante isso
        if (Vector3.Distance(transform.position, lastPos) > 0.0001f)
            transform.forward = transform.position - lastPos;

        // Pode ser colocado dentro do if (mais eficiente)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        if (Input.GetButton("Fire1"))
        {
            RaycastHit rayCastInfo;
            if (Physics.Raycast(ray, out rayCastInfo))
            {
                print(rayCastInfo.transform.gameObject.name
                 + " - " + rayCastInfo.point);
                target = rayCastInfo.point;
                target.y = 0.5f;
            }
        }
    }
}
