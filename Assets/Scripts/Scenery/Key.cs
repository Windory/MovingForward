﻿using UnityEngine;
using System.Collections;

public class Key : Interrupter
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col && col.gameObject.layer == 11)
        {
            if (!on)
            {
                Pull();
                Destroy(gameObject);
            }
        }
    }
}
