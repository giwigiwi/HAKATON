using UnityEngine;
using System.Collections;
using UnityEditorInternal;

[ExecuteInEditMode]
public class PointPath : MonoBehaviour {

    public GameObject[] pathLine;
    public bool monitoring = false;
    public GameObject text;
    private TextMesh textM;
    private GameObject gmText;

   public void Start()
    {
        if (transform.GetChildCount() < 1)
        {
            gmText = (GameObject)Instantiate(text, transform.position, Quaternion.identity);
            gmText.transform.parent = transform;
            textM = gmText.GetComponent<TextMesh>();
        }
        else
        {
            gmText = transform.GetChild(0).gameObject;
            gmText.transform.parent = transform;
            textM = gmText.GetComponent<TextMesh>();
        }

    }

    public void Update()
    {
        if (monitoring)
        {

            for (int i = 0; i < pathLine.Length; i++)
                Debug.DrawLine(transform.position, pathLine[i].transform.position);
            textM.text = gameObject.name;
        }

    }


}
