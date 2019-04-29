using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelmaController : IsometricController
{
    private static VelmaController instance;

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

    public override void Interact()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, boxCollider.size.x / 2 + 0.05f);
        foreach (Collider2D collider in colliders)
        {
            Interactable item = collider.GetComponent<Interactable>();
            if (item != null)
                item.Interact();
            GlyphStone glyph = collider.GetComponent<GlyphStone>();
            if (glyph != null)
                glyph.Interact();
        }
    }
}
