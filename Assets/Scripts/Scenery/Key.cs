using UnityEngine;
using System.Collections;

public class Key : Interrupter
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col && col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!on)
            {
                Pull();
                Destroy(gameObject);
            }
        }
    }
}
