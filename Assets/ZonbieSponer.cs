using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbieSponer : MonoBehaviour {
    public GameObject zombie_prefab;
	// Use this for initialization
	void Start () {
		for(int i=0;i < 20; i++)
        {
            Instantiate(zombie_prefab, new Vector3(Random.Range(0, 250), 100, Random.Range(0, 250)), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
