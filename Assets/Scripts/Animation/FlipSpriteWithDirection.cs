using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
class FlipSpriteWithDirection : MonoBehaviour
{
    public bool isSpriteFacingRight = false;

    SpriteRenderer rend;
    float dir;
    float dirMouse;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void SetDir(float d)
    {
        // Sets the dir if it's not 0 so it can
        // remember the direction when stopping
        if (d != 0)
            dir = d;

        // Checks if the sprite asset of the player is
        // facing right by default and the sign so it can
        // flip the sprite according to that information
        if (isSpriteFacingRight)
            rend.flipX = Mathf.Sign(dir) == 1 ? false : true;
        else
            rend.flipX = Mathf.Sign(dir) == 1 ? true : false;
    }

    public void SetDirMouseDirFlipY(Vector2 d)
    {
        if (d.x != 0)
            dirMouse = d.x;

        if (isSpriteFacingRight)
            rend.flipY = Mathf.Sign(dirMouse) == 1 ? false : true;
        else
            rend.flipY = Mathf.Sign(dirMouse) == 1 ? true : false;
    }
}