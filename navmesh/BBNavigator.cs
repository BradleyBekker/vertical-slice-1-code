using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BBNavigator : MonoBehaviour {

    public Camera camera;
    public NavMeshAgent agent;
    Vector3 safepos;
    private bool onOverLap;
    // Update is called once per frame
    void Update () {






        Ray edge = new Ray(transform.position,new Vector3(0,-1,0));
        
        RaycastHit check;

        if (!Physics.Raycast(edge, out check,3))
        {
            agent.SetDestination(safepos);



        }
        else
        {
            print("safepos");
            safepos = transform.position;

        }
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Overlap platform")
                {
                    agent.SetDestination(new Vector3(5.163997f, -0.5f, 3.049447f));
                    print("hit");
                    
                }

               


                if (hit.collider.name != "Midden_hendel_Toren"&& hit.collider.name != "Overlap platform")
                agent.SetDestination(hit.point);
                print(hit.collider.name);
                if (onOverLap && hit.collider.name != "Overlap platform" && hit.collider.name != "Platform 4" && hit.collider.name != "Midden_hendel_Toren")
                {
                    print("warped");
                    agent.Warp(new Vector3(6.3f, -0.455f, 3.039447f));
                    onOverLap = false;
                   
                }

            }
            else print("no hit");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "teleport_panel")
        agent.Warp(new Vector3(11.634f, 4.7f, -3.0f));

        if (other.name == "Overlap platform")
        {
            onOverLap = true;
            print(onOverLap);
        }
       
    }




}
