using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpirits : MonoBehaviour
{
    //references to the spirits
    public GameObject fireSpirit, waterSpirit, earthSpirit, windSpirit;
    //instantiated object
    private GameObject fireSpiritClone, waterSpiritClone, earthSpiritClone, windSpiritClone;
    public Transform spiritInvokingPosition;
    public bool aiming;
    private RaycastHit hit;
    private Ray ray;
    //position the player has ordered the spirit to go to
    public Vector3 goToPosition;
    private GameObject currentSpirit;
    
    // Start is called before the first frame update
    void Start()
    {
        aiming = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //invoke fire spirit
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InvokeSpirit(ref fireSpiritClone, ref waterSpiritClone, ref windSpiritClone, ref earthSpiritClone, fireSpirit);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InvokeSpirit(ref earthSpiritClone, ref waterSpiritClone, ref windSpiritClone, ref fireSpiritClone, earthSpirit);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InvokeSpirit(ref waterSpiritClone, ref fireSpiritClone, ref earthSpiritClone, ref windSpiritClone, waterSpirit);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InvokeSpirit(ref windSpiritClone, ref fireSpiritClone, ref earthSpiritClone, ref waterSpiritClone, windSpirit);
        }
        //aim
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
            Cursor.visible = true;
        }
        //stop aiming
        else if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            Cursor.visible = false;
        }
        //cast the ray
        if(aiming && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                goToPosition = hit.point;
                currentSpirit.GetComponent<SpiritBehavior>().GoTo();
            }
        }
        //make the spirit follow
        else if(!aiming && Input.GetMouseButtonDown(0))
        {
            currentSpirit.GetComponent<SpiritBehavior>().Follow();
        }
    }
    //manage spirit invokation 
    private void InvokeSpirit(ref GameObject  _cloneSpirit, ref GameObject _cloneSpirit2, ref GameObject _cloneSpirit3, ref GameObject _cloneSpirit4, GameObject _spirit)
    {
        if(_cloneSpirit == null)
        {
            _cloneSpirit = Instantiate(_spirit, spiritInvokingPosition.position, Quaternion.identity);
            //remove other spirits if invoked
            if (_cloneSpirit2 != null) Destroy(_cloneSpirit2);
            else if (_cloneSpirit3 != null) Destroy(_cloneSpirit3);
            else if (_cloneSpirit4 != null) Destroy(_cloneSpirit4);
            currentSpirit = _cloneSpirit;
        }
        else
        {
            Destroy(_cloneSpirit);
            currentSpirit = null;
        }
        
    }
}
