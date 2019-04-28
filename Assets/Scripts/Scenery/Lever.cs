using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{


 //   public GameObject FenceObject;
    public Sprite opened;
    public Sprite closed;
    public List<OpenedClosed> ocList;

    private bool on;
        
    // Use this for initialization
    void Start()
    {
        on = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }

    public void PullLever()
    {
        Debug.Log("leverPulled");
        on = !on;
        foreach (OpenedClosed oc in ocList)
        {
            oc.StateChange();
        }
        if (on)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
            //FenceObject.gameObject.SetActive(false);
            //gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = closed;
        }
    }

    public override void Interact()
    {
        PullLever();
    }
}
