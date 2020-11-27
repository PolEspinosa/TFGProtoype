using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireSpiritBehavior : SpiritBehavior
{
    public GameObject spiritLight;
    private NavMeshSurface navSurface;
    private bool rebuildNavMesh;
    // Start is called before the first frame update
    void Start()
    {
        InitialiseValues();
        spiritLight.SetActive(false);
        navSurface = GameObject.FindGameObjectWithTag("NavMeshSurface").GetComponent<NavMeshSurface>();
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

    private void OnTriggerEnter(Collider other)
    {
        if(state == States.GOING)
        {
            switch (other.tag)
            {
                case "Burnable":
                    Destroy(other.gameObject);
                    rebuildNavMesh = true;
                    break;
            }
        }
        if (other.CompareTag("DarkTrigger"))
        {
            spiritLight.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DarkTrigger"))
        {
            spiritLight.SetActive(false);
        }
    }
}
