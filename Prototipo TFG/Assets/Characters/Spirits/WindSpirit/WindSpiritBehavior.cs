using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpiritBehavior : SpiritBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        InitialiseValues();
    }

    // Update is called once per frame
    void Update()
    {
        FollowOrder();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vent"))
        {
            if(state == States.GOING)
            {
                other.gameObject.GetComponent<VentBehavior>().activated = true;
                other.gameObject.GetComponent<MeshRenderer>().material = other.gameObject.GetComponent<VentBehavior>().onMat;
            }
        }
    }
}
