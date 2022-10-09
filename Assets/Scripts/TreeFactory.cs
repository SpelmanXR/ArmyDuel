using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFactory : MonoBehaviour
{
    public float MinX = -4f;
    public float MaxX = 4f;
    public int NumTrees = 4;
    public GameObject TreePrefab;
    public float TreeCatchPoint = -1.2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumTrees; i++)
        {
            GameObject tree = Instantiate(TreePrefab);
            tree.transform.position = new Vector2(Random.Range(MinX, MaxX), 5f);
            tree.GetComponent<Tree>().CatchPoint = TreeCatchPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
