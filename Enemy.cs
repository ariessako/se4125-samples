using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
   PlayerController[] players;
   PlayerController nearestPlayer;
   public float speed;

   public void Start()
   {
    players = FindObjectsOfType<PlayerController>();

   }

   public void Update()
   {
     float distanceOne = Vector2.Distance(transform.position,players[0].transform.position);
     float distanceTwo = Vector2.Distance(transform.position, players[1].transform.position);
     Debug.Log(distanceTwo);
     if(distanceOne < distanceTwo)
     {
        nearestPlayer = players[0];
     }else{
        nearestPlayer = players[1];
     }

     if(nearestPlayer != null)
     {
        transform.position = Vector2.MoveTowards(transform.position,nearestPlayer.transform.position,speed * Time.deltaTime);

     }

   }

   private void  OnCollisionEnter2D(Collision2D collision) {
    
     if(collision.gameObject.CompareTag("Shoot"))
        {
            PhotonNetwork.Destroy(this.gameObject);
            Debug.Log("waay ko na igo ang kontra");
        }
   }
       
   
}
