using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCreation : MonoBehaviour
{
    public float ventForce = 3;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = gameObject.transform.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.GetComponentInParent<VentBehavior>().activated)
        {
            if (other.gameObject.CompareTag("Cube"))
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<Rigidbody>().AddForce(direction * ventForce);
            }
            if (other.gameObject.CompareTag("Player"))
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
