﻿using UnityEngine;
using System.Collections;

public class Pit : MonoBehaviour
{

    public Sprite spriteEmpty;
    public Sprite spriteBlocked;

    private SpriteRenderer sd;
    private bool blocked = false;

    private void Start()
    {
        sd = GetComponent<SpriteRenderer>();
        sd.sprite = spriteEmpty;
    }

    private void Update()
    {
        if (!blocked)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, 0, LayerMask.GetMask("Boulder"));
            if (col && col.gameObject.tag == "Boulder")
            {
                Block(col.gameObject);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                if (audio)
                {
                    audio.Play();
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!blocked && col.gameObject.tag == "Boulder")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.collider);
        }
    }

    void Block(GameObject go)
    {
        blocked = true;
        sd.sprite = spriteBlocked;
        GetComponent<Collider2D>().enabled = false;
        Destroy(go);
    }
}
