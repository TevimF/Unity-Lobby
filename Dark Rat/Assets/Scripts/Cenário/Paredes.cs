using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
    public float altura = 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, altura, 1);
        transform.position = new Vector3(0, altura / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {   
    }
}
