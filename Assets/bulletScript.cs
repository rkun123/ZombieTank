using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {
    Collider colider;
    public GameObject enemy;
    public GameObject expEffect;
	// Use this for initialization
	void Start () {
        colider = GetComponent<Collider>();
        colider.isTrigger = false;
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        colider.isTrigger = true;
        
	}
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit!!");
            Instantiate(expEffect, other.transform.position + Vector3.up*5, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
