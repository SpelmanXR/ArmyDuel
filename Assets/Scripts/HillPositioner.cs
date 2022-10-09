using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillPositioner : MonoBehaviour
{
    public float MinX = 0;
    public float MaxX = 0;
    public float MinY = 0;
    public float MaxY = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
