using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFloor : MonoBehaviour
{
    public float maxY;
    public Vector3 newPosition, startPosition;
    public bool decrease;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        newPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + maxY, gameObject.transform.position.z);
        decrease = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(decrease);
        //if (decrease)
        //{
        //    if (Vector3.Distance(gameObject.transform.position, startPosition) > 0)
        //    {
        //        gameObject.transform.position -= new Vector3(0, Time.deltaTime, 0);
        //    }
        //    else
        //    {
        //        decrease = false;
        //    }
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.transform.parent = gameObject.transform;
                break;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "Player":
    //            other.gameObject.transform.parent = null;
    //            break;
    //        case "EarthSpirit":
    //            decrease = true;
    //            break;
    //    }
    //}
}
