using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;



public class Health : MonoBehaviour
{
    
    public int health = 10;
    public TextMeshProUGUI healthDisplay;
    PhotonView view;
    // Update is called once per frame
    public void Start()
    {
        view = GetComponent<PhotonView>();

    }
    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC",RpcTarget.All);
    }

    [PunRPC] // Will let unity know
    void TakeDamageRPC()
    {
        health--;
        healthDisplay.text = health.ToString();
    }
    void Update()
    {
        
    }
}
