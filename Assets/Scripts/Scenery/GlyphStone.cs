using UnityEngine;
using System.Collections;

public class GlyphStone : Interrupter
{
    public void Interact()
    {
        if (!on)
            Pull();
    }
}
