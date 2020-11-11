using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToCreateAndDestroy : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Pode ser colocado dentro do if (mais eficiente)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        bool botao1 = Input.GetMouseButtonDown(0);
        bool botao2 = Input.GetMouseButtonDown(1);
        if (botao1 || botao2)
        {
            RaycastHit rayCastInfo;
            if (Physics.Raycast(ray, out rayCastInfo))
            {
                if (botao1 && rayCastInfo.transform.tag == "plane")
                {
                    Vector3 pos = rayCastInfo.point;
                    pos.y = 0.5f;
                    Instantiate(obj, pos, Quaternion.identity);
                }
                else if (botao2 && rayCastInfo.transform.tag == "cube")
                {
                    //Destroy(rayCastInfo.transform.gameObject);
                    StartCoroutine(DestroyAfterSeconds(rayCastInfo.transform.gameObject, 3));
                }
                print(rayCastInfo.transform.gameObject.name
                 + " - " + rayCastInfo.point);
            }
        }
    }

    IEnumerator DestroyAfterSeconds(GameObject obj, float seconds)
    {
        print("Na Corotina");
        yield return new WaitForSeconds(seconds);

        Destroy(obj);
        print("Fim da Corotina");
    }
}
