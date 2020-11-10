using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public Transform plane;
    public float speed = 2;
    private Mesh mesh;
    private Vector3 min;
    private Vector3 max;
    // Start is called before the first frame update
    void Start()
    {
        mesh = plane.GetComponent<MeshFilter>().mesh;
        min = mesh.bounds.min;
        max = mesh.bounds.max;
        Debug.Log(min);
        Debug.Log(max);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 lastPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // Sem isso, vai dar um aviso quando forem iguais!
        //if(transform.position == lastPos)  // funciona neste caso porque o MoveTowards garante isso
        if (Vector3.Distance(transform.position, lastPos) > 0.0001f)
            transform.forward = transform.position - lastPos;
        else
        {
            float x = Random.Range(min.x, max.x);
            float y = 0.5f;
            float z = Random.Range(min.z, max.z);
            target.position = new Vector3(x, y, z);
        }
    }

    void OnGUI()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        GUI.Label(new Rect(10, 10, 100, 20), $"{dist:f2}"); // 2 casas decimais
        GUI.Label(new Rect(10, 30, 100, 20), $"{transform.position}");
        // Ideal armazenar a ref. para cubo 2 no Start!
        Vector3 pos = transform.Find("Cube 2").position;
        GUI.Label(new Rect(10, 50, 100, 20), $"{pos}");
    }
}
