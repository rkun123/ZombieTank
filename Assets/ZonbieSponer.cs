using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbieSponer : MonoBehaviour {
    public GameObject zombie_prefab;
	// Use this for initialization
	void Start () {
		for(int i=0;i < 20; i++)
        {
            //Instantiate(zombie_prefab, new Vector3(Random.Range(-200,200), Random.Range(-200, 200), 60));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
