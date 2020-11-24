using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFloor : MonoBehaviour
{
    public float maxScale = 3;
    private float minScale;
    // Start is called before the first frame update
    void Start()
    {
        minScale = gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
