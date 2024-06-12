using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScene : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2; 
    bool bruh;
    //Load Scene
    public void Play()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible=true;
        src.clip = sfx1;
        bruh = true;
        StartCoroutine(wait());
        
    }

    public void Credits()
    {
        src.clip = sfx2;
        StartCoroutine(wait());
    }

    IEnumerator wait(){ 
        src.Play();
        yield return new WaitForSeconds(2);
        if(bruh){
            SceneManager.LoadScene(1);
        }else{
            SceneManager.LoadScene(0);
        }  
   }
}



