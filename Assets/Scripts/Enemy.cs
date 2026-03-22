using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float destroyForce = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > destroyForce)
        {
            GameManager.instance.AddScore(100);
            SoundManager.instance.PlaySound(SoundManager.instance.destroySound);
            Destroy(gameObject);
        }
    }
}