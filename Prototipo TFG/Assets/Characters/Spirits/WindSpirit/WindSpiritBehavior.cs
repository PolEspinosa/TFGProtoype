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
        DoAction();
    }

    private void DoAction()
    {
        if (Vector3.Distance(gameObject.transform.position, targetObject.transform.position) <= navAgent.stoppingDistance + 1)
        {
            switch (targetObject.tag)
            {
                case "Vent":
                    
                    break;
            }
        }
    }
}
