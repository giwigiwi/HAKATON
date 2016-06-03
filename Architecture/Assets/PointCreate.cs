using UnityEngine;
using System.Collections;

public class TestRaycast : MonoBehaviour
{
    public GameObject metkaObj;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name + " " + hit.distance);
            Instantiate(metkaObj, hit.point, Quaternion.identity);



        }
    }
}
