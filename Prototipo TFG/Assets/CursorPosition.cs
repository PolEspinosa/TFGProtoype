using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    public GameObject positionReference;
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = positionReference.transform.position;
        gameObject.transform.rotation = mainCamera.transform.rotation;
        
    }
}
