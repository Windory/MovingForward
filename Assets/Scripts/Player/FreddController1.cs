using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddController1 : IsometricController {

    private static FreddController1 instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            instance.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        GetComponent<Rigidbody2D>().mass = 500;
    }
}
