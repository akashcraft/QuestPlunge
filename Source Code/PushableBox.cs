using UnityEngine;

public class PushableBox : MonoBehaviour
{
    public float pushForce = 1;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Push Direction
            Vector2 pushDirection = collision.contacts[0].normal;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
        }
    }
}
