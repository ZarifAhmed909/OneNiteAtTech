using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2; 
    bool choice;



    public void Play()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible=true;
        src.clip = sfx1;
        choice = true;
        StartCoroutine(wait());
    }

    public void Credits()
    
    {
        src.clip = sfx2;
        StartCoroutine(wait());
        
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("The Player has Quit the game");
    }
    IEnumerator wait(){ 
        src.Play();
        yield return new WaitForSeconds(1);
        if(choice){
            SceneManager.LoadScene(1);
        }else{
            SceneManager.LoadScene(2);
        }  
   }

   
}