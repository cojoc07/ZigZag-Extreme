using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorShift : MonoBehaviour {

    //materials appear to glitch

    Color test;
    public Renderer rend;

    public float Speed = 1;

 
    void Start()
    {
        test = gameObject.GetComponent<Renderer>().material.color;

        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () 
    {
      

        if (Input.GetKeyDown(KeyCode.G))
        {
            rend.material.color = new Color(1.0f, 1.0f, 0.0f);
        }
    }
}
