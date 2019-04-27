using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DapneController : IsometricController {


    private DangerousTerrain trap;
    protected override bool DetectInteraction()
    {
        bool ret=
        base.DetectInteraction();
        if (trap != null)
        {
            trap.GetComponent<Collider2D>().enabled = false;
            trap = null;
            ret = true;
        }
        return ret;
     
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DangerousTerrain aux;
        if (aux= other.GetComponent<DangerousTerrain>())
            trap = aux;

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if ( other.GetComponent<DangerousTerrain>())
            trap = null;

    }
}
