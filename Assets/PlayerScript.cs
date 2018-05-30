using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float MOUSE_GAIN = 1.0f;
    public GameObject tank;
    public GameObject shooter;
    public GameObject bullet_prefab;
    public float vertTurnSpeed = 3.0f;
    public float forwardSpeed = 3.0f;
    public float reverseSpeed = 1.0f;
    public float turnSpeed = 3.0f;
    public float upperLimit = 290.0f;
    public float lowerLimit = 30.0f;
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
        //Visible Pointer
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
        //for intterpt escape
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        transform.Rotate(0, 0, Input.GetAxis("Mouse X") * MOUSE_GAIN);
        shooter.transform.Rotate(Input.GetAxis("Mouse Y")*vertTurnSpeed*Time.deltaTime, 0, 0);
        Debug.Log(shooter.transform.rotation.x);
        /*if (shooter.transform.rotation.x < -0.75f)
        {
            shooter.transform.rotation = new Quaternion(-0.75f ,shooter.transform.rotation.y, shooter.transform.rotation.z, shooter.transform.rotation.w);
        }*/

        bool isReversing = false;
        //forward
        if (Input.GetKey(KeyCode.W))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            tank.transform.Translate(new Vector3(0,0,forwardSpeed)*Time.deltaTime);
            isReversing = false;
        }
        //reverse
        if (Input.GetKey(KeyCode.S))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            tank.transform.Translate(new Vector3(0, 0, -reverseSpeed)*Time.deltaTime);
            isReversing = true;
        }
        //left turn
        if (Input.GetKey(KeyCode.A))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            if (isReversing)
            {
                tank.transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0));
            }
            else
            {
                tank.transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0));
            }
        }
        //right turn
        if (Input.GetKey(KeyCode.D))
        {
            //tank.transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3( 0, 0, forwardSpeed),Time.deltaTime);
            if (isReversing)
            {
                tank.transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0));
            }
            else
            {
                tank.transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0));
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
