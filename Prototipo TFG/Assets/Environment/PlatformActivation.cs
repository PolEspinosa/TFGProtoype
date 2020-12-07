using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivation : MonoBehaviour
{
    public bool activated;
    public float movingTime;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = movingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * 2;
            }
        }
        else
        {
            if(currentTime < movingTime)
            {
                currentTime += Time.deltaTime/2;
                gameObject.transform.position -= gameObject.transform.forward * Time.deltaTime;
            }
        }
    }
}
