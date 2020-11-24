using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCreation : MonoBehaviour
{
    public float ventSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponentInParent<VentBehavior>().activated)
        {
            other.gameObject.transform.position += new Vector3(0, ventSpeed, 0) * Time.deltaTime;
        }
    }
}
