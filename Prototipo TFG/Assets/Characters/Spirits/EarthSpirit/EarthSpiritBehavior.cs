using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EarthSpiritBehavior : SpiritBehavior
{
    private float startTime;
    private bool rebuildNavMesh;
    private NavMeshSurface navSurface;
    // Start is called before the first frame update
    void Start()
    {
        InitialiseValues();
        navSurface = GameObject.FindGameObjectWithTag("EarthNavMesh").GetComponent<NavMeshSurface>();
        rebuildNavMesh = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowOrder();
        if (rebuildNavMesh)
        {
            navSurface.BuildNavMesh();
            rebuildNavMesh = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(state == States.GOING)
        {
            switch (other.tag)
            {
                case "GrowFloor":
                    if(Vector3.Distance(other.gameObject.transform.position,other.gameObject.GetComponent<GrowFloor>().newPosition) > 0)
                    {
                        other.gameObject.transform.position += new Vector3(0, Time.deltaTime, 0);
                    }
                    break;
                case "BrokenWall":
                    Destroy(other.gameObject);
                    rebuildNavMesh = true;
                    break;
                case "PressurePlate":
                    other.gameObject.GetComponent<PressurePlate>().activated = true;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "GrowFloor":
                other.gameObject.GetComponent<GrowFloor>().decrease = true;
                break;
            case "PressurePlate":
                other.gameObject.GetComponent<PressurePlate>().activated = false;
                break;
        }
    }
}