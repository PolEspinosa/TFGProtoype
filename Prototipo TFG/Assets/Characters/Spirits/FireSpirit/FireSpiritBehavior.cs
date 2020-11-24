using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpiritBehavior : SpiritBehavior
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
        if(state == States.GOING)
        {
            switch (other.tag)
            {
                case "Bush":
                    Destroy(other.gameObject);
                    break;
            }
        }
    }
}
