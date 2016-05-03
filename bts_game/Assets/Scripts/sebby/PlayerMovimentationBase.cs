using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class PlayerMovimentationBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float valor;
    private Transform player;

    public void OnPointerDown(PointerEventData eventData)
    {
        Player.h = valor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.h = 0;
    }

    // Use this for initialization
    void Start () {

     //  player = GameObject.Find("Player").GetComponent<Transform>();

       

    }

    // Update is called once per frame
    

}
