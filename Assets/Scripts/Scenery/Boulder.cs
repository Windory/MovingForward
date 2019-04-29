using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script make the boulder static
public class Boulder : MonoBehaviour {

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = 1000;
        rb.drag = 100;
    }
}
