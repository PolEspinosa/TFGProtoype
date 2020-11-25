using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpiritBehavior : SpiritBehavior
{
    public float journeyTime = 1.0f;
    private float startTime;
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
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "GrowFloor":
    //            other.gameObject.GetComponent<GrowFloor>().decrease = true;
    //            break;
    //    }
    //}
}