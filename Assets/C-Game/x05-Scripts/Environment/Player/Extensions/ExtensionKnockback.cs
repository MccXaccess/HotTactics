using UnityEngine;

public static class ExtensionKnockback
{
    public static void Knockback(this GameObject objectInstance, float force, float forceMultiplier)
    {
        Rigidbody2D rb2d = objectInstance.GetComponent<Rigidbody2D>();
        Transform objectTransform = objectInstance.GetComponent<Transform>();
        rb2d.AddForce(-objectTransform.right * (force * forceMultiplier), ForceMode2D.Impulse);
    }
}