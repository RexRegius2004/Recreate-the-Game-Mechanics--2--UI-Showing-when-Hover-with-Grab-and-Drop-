using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class PickupScript : MonoBehaviour
{
    public GameObject player;
    public Transform crosshair;
    public float pickUpRange = 5f; 
    private GameObject heldObj; 
    private Rigidbody heldObjRb; 
    private bool canDrop = true;
    public TMP_Text ui_text;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (heldObj == null) 
            {
                
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        PickUpObject(hit.transform.gameObject);
                        ui_text.text = "Drop Item";
                    }
                }
            }
            else
            {
                if (canDrop == true)
                {
                    DropObject();
                    ui_text.text = "Pickup";
                }
            }
        }
        if (heldObj != null) 
        {
            MoveObject(); 

        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = crosshair.transform; 
           
        }
    }
    void DropObject()
    {
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null; 
    }
    void MoveObject()
    {
        heldObj.transform.position = crosshair.transform.position;
    }
    
}
