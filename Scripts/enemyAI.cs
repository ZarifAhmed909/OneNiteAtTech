using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour
{
   public NavMeshAgent ai;
   public List<Transform> destinations;
   public Animator aiAnim;
   public float walkSpeed, chaseSpeed, minIdleTime,maxIdleTime,idleTime, sightDistance, slaughterDistance, minChaseTime,maxChaseTime,chaseTime, deathTime;
   public int  destinationAmount, prevDest; 
   public bool walking,chasing;
   public Transform player;
   Transform currentDest;
   Vector3 dest; 
   int randNum, counter, chaseCOunter;
   public Vector3 rayCastOffset;

   public AudioSource src, chaseSrc;
   public AudioClip onCatch,chaseOst, walkingSFX; 

   public Transform lights;
   void Start()
   {
    walking = true;
    randNum = Random.Range(0,destinationAmount);
    currentDest = destinations[randNum];
   }
   void Update()
   {
    Vector3 direction = (player.position - transform.position).normalized;
    RaycastHit hit;
      if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance)){ 
         if (hit.collider.gameObject.tag == "Player"){ //did the enemy spot us? 
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
    }
    if(chasing == true){ //Mid-Chase
        if(chaseCOunter==0){
            src.Stop();
            chaseSrc.clip = chaseOst;
            chaseSrc.Play();
            chaseCOunter++;
        }
        dest=player.position;
        ai.destination = dest;
        ai.speed = chaseSpeed;
        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("slaughter");
        float distance = Vector3.Distance(player.position, ai.transform.position);
        if(distance<= slaughterDistance){//Caught the player
            player.gameObject.SetActive(false);
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("slaughter");
            aiAnim.SetTrigger("skullCrusher");
            StartCoroutine(deathRoutine());
            chasing=false;
        }
    }
      if (walking)
        {
            if(counter==0){
                src.clip = walkingSFX;
                src.Play();
                counter++;
            }
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("slaughter");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("walk");
        if (ai.remainingDistance <= ai.stoppingDistance)
            {
            aiAnim.ResetTrigger("slaughter");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    
}
   IEnumerator stayIdle() //how long should the enemy idle?
   {
    src.Stop();
    yield return new WaitForSeconds(4);
    walking = true;
    int nextPlace = getNextLocale();
    currentDest = destinations[nextPlace];
    prevDest = nextPlace;
    counter = 0; 
   }

   IEnumerator chaseRoutine(){//decides how long to chase player
    chaseTime = Random.Range(minChaseTime, maxChaseTime);
    yield return new WaitForSeconds(chaseTime);
    walking = true;
    chasing = false;
    randNum = Random.Range(0, destinations.Count);
    currentDest = destinations[randNum];
    chaseCOunter = 0;
    chaseSrc.Stop();
   }
   IEnumerator deathRoutine(){ //death scene
    lights.GetComponent<Light>().enabled = true;
    src.clip = onCatch;
    src.Play(); 
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible=true;
    yield return new WaitForSeconds(deathTime);
    SceneManager.LoadScene(3);
   }

   public int getNextLocale(){ 
    randNum = Random.Range(0, destinationAmount);
    if (randNum == prevDest){
        return getNextLocale();
    }
    return Random.Range(0,destinationAmount); 
   }
}
