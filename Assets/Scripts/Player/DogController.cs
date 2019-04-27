using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : IsometricController {

    private GameObject nearBone;
    private GameObject myBone;
    private Vector3 offset;
    public void Start()
    {
        Sprite aux;
        offset= Vector3.zero;
        aux = this.GetComponent<SpriteRenderer>().sprite;
        offset.y = aux.textureRect.height / aux.pixelsPerUnit * this.transform.localScale.y/2;
    }
    protected override void Update()
    {
    }
}
