using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorChecker : MonoBehaviour
{
    public GameObject escapeText;
    void Start()
    {
        escapeText.SetActive(false);
    }
    void OnTriggerStay()
    {
        if(Input.GetKey(KeyCode.E)){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible=true;
            SceneManager.LoadScene(4);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
         
            escapeText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
        
            escapeText.SetActive(false);
        }
    }
}
