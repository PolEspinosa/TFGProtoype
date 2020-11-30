using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivable : MonoBehaviour
{
    public bool activate;
    public MeshRenderer meshRenderer;
    public Material onMaterial, offMaterial;
    //the gameobject that will react once this gameobject is activated
    public GameObject activableGameobject;
    private float currentTime;
    public float movingTime;
    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = offMaterial;
        currentTime = movingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate && currentTime > 0)
        {
            activableGameobject.transform.position += Vector3.right * Time.deltaTime;
            currentTime -= Time.deltaTime;
        }
        else if (!activate && currentTime < movingTime)
        {
            activableGameobject.transform.position -= Vector3.right * Time.deltaTime;
            currentTime += Time.deltaTime;
        }
    }
}
