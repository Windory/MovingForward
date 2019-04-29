using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController.GetInstance().CharacterExit();
        }
    }
}
