using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpiritBehavior : SpiritBehavior
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

    private void OnTriggerStay(Collider other)
    {
        if(state == States.GOING)
        {
            switch (other.tag)
            {
                case "GrowFloor":
                    if(other.gameObject.transform.localScale.y < other.gameObject.GetComponent<GrowFloor>().maxScale)
                    {
                        other.gameObject.transform.localScale += new Vector3(0, Time.deltaTime, 0);
                    }
                    break;
            }
        }
    }
}
