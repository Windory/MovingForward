using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interrupter : MonoBehaviour
{
    public Sprite spriteOn;
    public Sprite spriteOff;
    public List<OpenedClosed> ocList;

    private SpriteRenderer sr;

    protected bool on;

    // Use this for initialization
    void Start()
    {
        on = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteOff;
    }

    public void Pull()
    {
        foreach (OpenedClosed oc in ocList)
            oc.StateChange();

        on = !on;
        if (on)
            sr.sprite = spriteOn;
        else
            sr.sprite = spriteOff;
    }
}
