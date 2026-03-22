using UnityEngine;

public class BlockSound : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 2f)
        {
            SoundManager.instance.PlaySound(SoundManager.instance.hitSound);
        }
    }
}