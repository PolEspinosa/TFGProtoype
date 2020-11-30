using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTorch : MonoBehaviour
{
    public Material onMaterial, offMaterial;
    public GameObject fireLight;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        fireLight.SetActive(false);
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = offMaterial;
        fireLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
