using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introSequence : MonoBehaviour
{
    public Animator aiAnim;
    public Transform player;
    public Transform trueEnemy;
    public Transform clipBoard;
    public AudioSource src,src2;
    public AudioClip monologue, nerd,powerDown;

    public GameObject subtitle1,subtitle2,subtitle3;

    public Transform light1, light2,light3,light4,light5,light6,light7,light8,light9,light10,light11,light12,light13,light14,light15;

    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.SetActive(false);
        trueEnemy.gameObject.SetActive(false);
        aiAnim.SetTrigger("clipFall");

        StartCoroutine(Zoom());
        StartCoroutine(PlaySound());
        StartCoroutine(SlowturnOff());
    }

    IEnumerator Zoom()
    {
        yield return new WaitForSeconds(11);
        clipBoard.gameObject.SetActive(false);
        aiAnim.SetTrigger("startZoom");

        yield return new WaitForSeconds(11);
        player.gameObject.SetActive(true);
        trueEnemy.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    IEnumerator PlaySound()
    {
        src.clip = nerd;
        src.Play();
        yield return new WaitForSeconds(11);
        src.clip = monologue;
        src.Play();
        
    }

    IEnumerator SlowturnOff(){
        yield return new WaitForSeconds(11);
        src2.clip = powerDown;
        src2.Play();
        light1.GetComponent<Light>().enabled = false;
        light10.GetComponent<Light>().enabled = false;
        light11.GetComponent<Light>().enabled = false;
        light12.GetComponent<Light>().enabled = false;
        light15.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        subtitle1.SetActive(true);
        src2.Play();
        light2.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light3.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light4.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        subtitle1.SetActive(false);
        subtitle2.SetActive(true);
        src2.Play();
        light5.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light6.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light7.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light8.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        subtitle2.SetActive(false);
        subtitle3.SetActive(true);
        src2.Play();
        light9.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(1);
        src2.Play();
        light9.GetComponent<Light>().enabled = false;
        
        light13.GetComponent<Light>().enabled = false;
        light14.GetComponent<Light>().enabled = false;  
    }

    public void Skip(){
        player.gameObject.SetActive(true);
        trueEnemy.gameObject.SetActive(true);
        clipBoard.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }



}

