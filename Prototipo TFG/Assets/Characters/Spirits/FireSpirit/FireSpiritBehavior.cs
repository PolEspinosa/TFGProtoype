using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpiritBehavior : SpiritBehavior
{
    public GameObject spiritLight;
    // Start is called before the first frame update
    void Start()
    {
        InitialiseValues();
        spiritLight.SetActive(false);
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
