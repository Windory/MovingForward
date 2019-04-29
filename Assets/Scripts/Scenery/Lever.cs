using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interrupter, Interactable
{
    public void Interact()
    {
        Pull();
    }
}
