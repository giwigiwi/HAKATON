using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {
    public List<GameObject> pathGameObject;
    public LineRenderer lineRend;
    public List<GameObject> ignoreList;


     public void Start(){

         lineRend = gameObject.GetComponent<LineRenderer>();
         
    }


     public bool IsIgnore(GameObject ignoreObject)
     {
         bool ignoreIs = false;

         for (int i = 0; i < ignoreList.Count; i++)
         {
             if (ignoreList[i] == ignoreObject)
                 ignoreIs = true;
         }
         return ignoreIs;
     }

     public void ConstructPath()
     {
         lineRend = gameObject.GetComponent<LineRenderer>();
         lineRend.SetVertexCount(pathGameObject.Count);
         Debug.Log(pathGameObject.Count);
         Vector3[] pos = new Vector3[pathGameObject.Count];
         for (int i = 0; i < pathGameObject.Count; i++)
         {
             lineRend.SetPosition(i,pathGameObject[i].transform.position);
         }
         //lineRend.SetPositions(pos);
     }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ConstructPath();
        }
    }
}