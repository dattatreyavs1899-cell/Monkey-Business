using UnityEngine;

public class BirdLaunch : MonoBehaviour
{
    Rigidbody2D rb;

    public Trajectory trajectory;
    Vector2 startPos;
    bool dragging;

    public float power = 10f;

    public float lifeTime = 3f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDown()
    {
        dragging = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDrag()
    {
        if (!dragging) return;

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouse;

        Vector2 velocity = (startPos - (Vector2)transform.position) * power;

        trajectory.Show(startPos, velocity);
    }

    void OnMouseUp()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.shootSound);
        GameManager.instance.UseBird();

        dragging = false;

        rb.bodyType = RigidbodyType2D.Dynamic;

        Vector2 force = startPos - (Vector2)transform.position;

        rb.AddForce(force * power, ForceMode2D.Impulse);

        trajectory.Hide();
        Invoke(nameof(FinishBird), lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 1f)
        {
            SoundManager.instance.PlaySound(SoundManager.instance.hitSound);
        }
    }
    void FinishBird()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.destroySound);
        GameManager.instance.BirdFinished(gameObject);
    }
}