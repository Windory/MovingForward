using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : IsometricController {

    private static DogController instance;

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
}
