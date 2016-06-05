using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointTemp : MonoBehaviour {

    public struct ObjectUsedVariant
    {
        public GameObject objectPosition;
        public int variant;
    }
    public GameObject positPoint;
    private GameObject tempObject;
    public List<Path> ArrayPath;
    public GameObject target;
    public GameObject scriptPath;
    public List<ObjectUsedVariant> usedInIteration;
    public GameObject realPoint;


    private void AddObjectUsedVariant(GameObject gm, int index)
    {
        ObjectUsedVariant osv;
        osv.objectPosition = gm;
        osv.variant = index;
        usedInIteration.Add(osv);
    }


    // Use this for initialization
    void Start()
    {
        //AddObjectUsedVariant(gameObject, 1);
        
    }

    private bool PoluchIzMassivaBool(GameObject gm, List<ObjectUsedVariant> listObjectVar)
    {
        for (int i = 0; i < listObjectVar.Count;i++)
        {
            if (listObjectVar[i].objectPosition == gm)
                return true;
        }
        return false;
    }

    private GameObject PoluchIzMassivaGm(GameObject gm, List<ObjectUsedVariant> listObjectVar)
    {
        for (int i = 0; i < listObjectVar.Count; i++)
        {
            if (listObjectVar[i].objectPosition == gm)
                return listObjectVar[i].objectPosition;
        }
        return null;
    }
	// Update is called once per frame
	void Update () {

	}
    private Vector2 VectorAbs(Vector2 vec)
    {
        Vector2 abs = new Vector2(Mathf.Abs(vec.x),Mathf.Abs(vec.y));
        return abs;

    }

    private bool AddVariant(GameObject tempGM, int varStep)
    {
        bool finded = false;
        return finded;
    }


    public void PathIteration()
    {
        List<Path> path =null;
        Path pt = Instantiate(scriptPath).GetComponent<Path>();
        pt.pathGameObject.Add(realPoint);
        path.Add(pt);
        FindThePath(path);
    }

    public void FindThePath(List<Path> path)
    {
        int i = 0;
        while (true)
        {
            if (PoluchIzMassivaBool(path[i].gameObject, usedInIteration)) 
            {
                for (int ib=0; ib < path.Count; i++)
                {
                    PoluchIzMassivaGm(path[i].gameObject, usedInIteration);

                }
            }


        }

    }

    private float VectorDistance(Vector2 v1, Vector2 v2)
    {
        float distance;
        float xx = v2.x-v1.x;
        float yy = v2.y-v1.y;
        distance=Mathf.Sqrt((xx*xx)+(yy*yy));

        return distance;
    }


    public GameObject MinimumDistance(Path pathIgnore)
    {
        GameObject gm=null;
        GameObject  tempPosit = positPoint;
        PointPath tempPath = tempPosit.GetComponent<PointPath>();
        float minPosit=1000000;
        int iter = 0;
        for (int i = 0; i < tempPath.pathLine.Length ; i++)
        {
            Debug.Log(i);
            Vector2 point1 = positPoint.transform.position;
            Vector2 point2 = tempPath.pathLine[i].transform.position;
            if (!pathIgnore.IsIgnore(tempPath.pathLine[i]))
            {
            iter++;
            float temp = VectorDistance(point1,point2);
            if (minPosit > temp)
            {
                minPosit = temp;
                gm = tempPath.pathLine[i];
            } 
            }
        }

        ObjectUsedVariant objVar ;
        objVar.objectPosition = gm;
        objVar.variant = iter;



        return gm;
    }
}
