using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform plane;
    private Mesh mesh;
    private Vector3 min;
    private Vector3 max;
    private Vector3 start;
    private float currentTime;
    private float totalTime;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        mesh = plane.GetComponent<MeshFilter>().mesh;
        min = mesh.bounds.min;
        max = mesh.bounds.max;
        Debug.Log(min);
        Debug.Log(max);
        ResetPos();
    }

    void ResetPos()
    {
        start = transform.position;
        float distance = Vector3.Distance(start, target.position);
        currentTime = 0f;
        totalTime = distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        float current = currentTime/totalTime;
        currentTime += Time.deltaTime;

        // Ease out:
        float t = current;
        // t = Mathf.Sin(current * Mathf.PI * 0.5f);

        // Ease in:
        // t = 1 - Mathf.Cos(current * Mathf.PI * 0.5f);

        // Smoothstep
        t = t*t * (3f - 2f*t);

        Vector3 newPos = Vector3.Lerp(start, target.position, t);
        transform.position = newPos;

        if (current >= 1f)
        {
            // Se chegar no destino, sorteia uma nova posição
            // e troca a cor do material para amarelo
            mat.color = Color.yellow;
            float x = Random.Range(min.x, max.x);
            float y = 0.5f;
            float z = Random.Range(min.z, max.z);
            target.position = new Vector3(x,y,z);
            ResetPos();
        }
    }
}
