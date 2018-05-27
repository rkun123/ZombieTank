using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownShooter : MonoBehaviour {
    public GameObject shooter;
    float upperLmt = 10.0f;
    float lowerLmt = 10.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float shooterDelta = Input.GetAxis("Mouse Y");
        Debug.Log(shooterDelta);
        
        
	}
}
