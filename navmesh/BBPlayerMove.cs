using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class BBPlayerMove : MonoBehaviour {
    //float speed = 4;
    bool canGoRight=false;
    bool canGoLeft=false;
    bool canGoForward=false;
    bool canGoBack=false;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray rightRay = new Ray(transform.position, new Vector3(1, -1, 0));
        Ray leftRay = new Ray(transform.position, new Vector3(-1 , -1, 0));
        Ray forwardRay = new Ray(transform.position, new Vector3(0, -1, 1));
        Ray backRay = new Ray(transform.position, new Vector3(0,-1,-1));

        RaycastHit rightHit;
        RaycastHit leftHit;
        RaycastHit forwardHit;
        RaycastHit backHit;
        if (Physics.Raycast(rightRay, out rightHit, 3))
        {
            canGoRight = true;
        }canGoRight = false;
        if (Physics.Raycast(leftRay, out leftHit, 3))
        {
            canGoLeft = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * leftHit.distance, Color.yellow);
        }
        else canGoLeft = false;

        if (Physics.Raycast(forwardRay, out forwardHit, 3))
        {
            canGoForward = true;
        }
        else canGoForward = false;

        if (Physics.Raycast(backRay, out backHit, 3))
        {
            canGoBack = true;
        }
        else canGoBack = false;

        Movement();
	}
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if(canGoLeft)
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (canGoRight) 
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (canGoBack)
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (canGoForward)
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
