using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKey : MonoBehaviour
{
    public Component doorCollider;

    public Component otherKey1;
    public Component otherKey2;
    public Transform key; 
    public GameObject pickUpText;
    public AudioSource keySound;
    public AudioClip bruh; 
    public Image keyPNG; 

    public bool inReach;


    void Start()
    {
        pickUpText.SetActive(false);
    }


    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E)){
            keySound.clip = bruh;
            keySound.Play();
            keyPNG.enabled = true; 
            key.gameObject.SetActive(false);
            pickUpText.SetActive(false);
            if(!otherKey1.gameObject.activeSelf){
                if(!otherKey2.gameObject.activeSelf){
                    doorCollider.GetComponent<BoxCollider>().enabled = true;
                } 
            }
        }
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }
}
