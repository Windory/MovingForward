using UnityEngine;
using System.Collections;

public class Key : Interrupter
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!on)
        {
            Pull();
            Destroy(gameObject);
        }
    }
}
