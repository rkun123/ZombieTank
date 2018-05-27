using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float MOUSE_GAIN = 1.0f;
    public GameObject tank;
    public GameObject shooter;
    public GameObject bullet_prefab;
    public float forwardSpeed = 0.1f;
    public float reverseSpeed = 0.1f;
    public float turnSpeed = 1.0f;
    Component rb;
    
    //for shot
    void Shot()
    {
        GameObject bullet =  Instantiate(bullet_prefab);
        bullet.transform.position = shooter.transform.position - shooter.transform.up * 3;
        bullet.transform.rotation = shooter.transform.rotation;
        Rigidbody bullet_rb =  bullet.GetComponent<Rigidbody>();
        bullet_rb.velocity = -shooter.transform.up * 100;
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent("RigidBody");
        Rigidbody tank_rb = tank.GetComponent<Rigidbody>();
        tank_rb.centerOfMass = -Vector3.up;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }

        //Debug.Log("Mouse:" + Input.mousePosition.x + " Width:" + Screen.width+ " mouse(getaxis):"+Input.GetAxis("Mouse X") + " rotation: " + ((mousePosX - latestMousePosX) * MOUSE_GAIN + tankRotX));
        transform.Rotate(0, 0, Input.GetAxis("Mouse X") * MOUSE_GAIN);
        //Debug.Log(Input.GetAxis("Mouse X"));
        Debug.Log(Input.GetAxis("Mouse X"));
        shooter.transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);

        bool isReversing = false;
        //forward
        if (Input.GetKey(KeyCode.W))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            tank.transform.Translate(new Vector3(0,0,forwardSpeed));
            isReversing = false;
        }
        //reverse
        if (Input.GetKey(KeyCode.S))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            tank.transform.Translate(new Vector3(0, 0, -reverseSpeed));
            isReversing = true;
        }
        //left turn
        if (Input.GetKey(KeyCode.A))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            if (isReversing)
            {
                tank.transform.Rotate(new Vector3(0, turnSpeed, 0));
            }
            else
            {
                tank.transform.Rotate(new Vector3(0, -turnSpeed, 0));
            }
        }
        //right turn
        if (Input.GetKey(KeyCode.D))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            if (isReversing)
            {
                tank.transform.Rotate(new Vector3(0, -turnSpeed, 0));
            }
            else
            {
                tank.transform.Rotate(new Vector3(0, turnSpeed, 0));
            }
            
        }
        //recover rotation
        if (Input.GetKeyDown(KeyCode.R))
        {
            tank.transform.position += Vector3.up * 0.5f;
            tank.transform.rotation = Quaternion.identity;
        }

    }
}
