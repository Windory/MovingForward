using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCanPass : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Dog")
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}