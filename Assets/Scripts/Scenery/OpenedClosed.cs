using UnityEngine;
using System.Collections;

// Script for Spikes and Doors
public class OpenedClosed : MonoBehaviour
{
    public Sprite spriteOpened;
    public Sprite spriteClosed;
    public bool opened;

    private SpriteRenderer sr;
    private Collider2D coll;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

        StateUpdate();
    }

    public void StateChange()
    {
        opened = !opened;
        StateUpdate();
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }
    }

    public void StateUpdate()
    {
        if (opened)
        {
            sr.sprite = spriteOpened;
            coll.enabled = false;
        }
        else
        {
            sr.sprite = spriteClosed;
            coll.enabled = true;
        }
    }
}
