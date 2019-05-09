using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interrupter
{
    private int cpt;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col && (col.gameObject.tag == "Boulder" || col.gameObject.layer == 11))
        {
            if (cpt == 0)
                Pull();
            ++cpt;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        --cpt;
        if (cpt == 0)
            Pull();
    }
}
