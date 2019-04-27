using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*private float h, v = 0.0f;

    private RaycastHit2D[] groundHits = null;
    private Collider2D[] colliders = null;

    private Rigidbody2D rb2D = null;
    private PolygonCollider2D boxCollider = null;

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private float maxJumpTime = 1.5f;
    [SerializeField]
    private LayerMask groundLayers;*/

    private List<GameObject> goCharacters = new List<GameObject>(4); // List with all GameObject characters
    private List<IsometricController> characters = new List<IsometricController>(4); // List with all Controller characters
    private int cha = 0; // Current index of the characters list (active character)
    private float h, v = 0.0f;

    private void Start()
    {
        /*rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<PolygonCollider2D>();*/
        string[] tags = { "Velma", "Fred", "Dapne", "Dog" };
        for (int i = 0; i < 4; ++i)
        {
            goCharacters.Add(GameObject.Find(tags[i]));
            characters.Add(goCharacters[i].GetComponent<IsometricController>());
        }
        GameManager.getInstance().CameraFollowObject(goCharacters[cha]);
        characters[cha].Go();
    }

    private void FixedUpdate()
    {
        ProcessMove();
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
       
        ProcessInteract();
        ProcessSwitch();
    }

    // Switch the current character to the next one in the list
    private void Switch()
    {
        characters[cha].Stop();
        ++cha;
        if (cha == characters.Count)
            cha = 0;
        GameManager.getInstance().CameraFollowObject(goCharacters[cha]);
        characters[cha].Go();
    }

    private void ProcessMove()
    {
        characters[cha].Move(h, v);
    }

    private void ProcessInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characters[cha].Interact();
        }
    }

    private void ProcessSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Switch();
        }
    }

    /*private void ProcessInteract()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, boxCollider.points[0].x / 2 + 0.025f);

        foreach (Collider2D collider in colliders)
        {
            switch (collider.tag)
            {
                case "Boulder":
                    Boulder boulder = collider.GetComponent<Boulder>();
                    if (boulder != null && isGrounded)
                    {
                        if (Input.GetKeyDown(KeyCode.S))
                        {
                            boulder.IsPushed = true;
                            boulder.GetComponent<FixedJoint2D>().enabled = true;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = rb2D;

                        }

                        if (Input.GetKeyUp(KeyCode.S))
                        {
                            boulder.IsPushed = false;
                            boulder.GetComponent<FixedJoint2D>().enabled = false;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = null;
                        }
                    }
                    break;
            }
        }
    }*/
}