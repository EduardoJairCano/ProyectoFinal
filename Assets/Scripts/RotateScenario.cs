using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, .5f, 0));

    }
}
