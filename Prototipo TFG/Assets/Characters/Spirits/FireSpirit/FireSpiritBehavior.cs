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
                    //rebuild nav mesh surface to update the spot where the burnable object was
                    rebuildNavMesh = true;
                    break;
                case "Torch":
                    //change the material of the torch
                    other.gameObject.GetComponent<LightTorch>().meshRenderer.material = other.gameObject.GetComponent<LightTorch>().onMaterial;
                    //activate the light/fire
                    other.gameObject.GetComponent<LightTorch>().fireLight.SetActive(true);
                    break;
                case "FireActivable":
                    other.gameObject.GetComponent<FireActivable>().activate = true;
                    other.gameObject.GetComponent<FireActivable>().meshRenderer.material = other.gameObject.GetComponent<FireActivable>().onMaterial;
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
        else if (other.CompareTag("FireActivable"))
        {
            other.gameObject.GetComponent<FireActivable>().activate = false;
            other.gameObject.GetComponent<FireActivable>().meshRenderer.material = other.gameObject.GetComponent<FireActivable>().offMaterial;
        }
    }
}
