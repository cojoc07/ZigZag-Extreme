using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private GameObject target;
    private float lerpRate = 2.0f;
    private Vector3 offset;

	
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        offset = target.transform.position - transform.position;
   	}
	
	
	void Update () {
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
