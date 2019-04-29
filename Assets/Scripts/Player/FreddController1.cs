using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddController1 : IsometricController {

    private bool isHoldingBoulder = false;

    private Boulder currentBoulder = null;

    private float fredHeight;
    private float boulderHeight;

    void Start()
    {
        GetComponent<Rigidbody2D>().mass = 500;
    }
}
