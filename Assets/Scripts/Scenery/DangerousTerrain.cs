using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousTerrain : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Daphne")
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
