using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBehavior : MonoBehaviour
{
    public Material offMat, onMat;
    private MeshRenderer meshRenderer;
    public float activatedTime; // time before deactivating
    private float currentTime; //time passed since it is activated
    public bool activated;
    public bool hasSpirit; //whether the spirit is fueling the vent or not
    // Start is called before the first frame update
    void Start()
    {
        //by default the vent is off
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = offMat;
        activatedTime = 5f;
        activated = false;
        currentTime = 0;
        hasSpirit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (hasSpirit)
            {
                currentTime = 0;
            }
            else
            {
                //if the active time hasn't reached the limit, continue active and increasing time
                if (currentTime < activatedTime)
                {
                    currentTime += Time.deltaTime;
                }
                //if the active time is over, deactivate
                else
                {
                    activated = false;
                    meshRenderer.material = offMat;
                    currentTime = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WindSpirit"))
        {
            activated = true;
            hasSpirit = true;
            meshRenderer.material = onMat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WindSpirit"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WindSpirit"))
        {
            hasSpirit = false;
        }
    }
}
