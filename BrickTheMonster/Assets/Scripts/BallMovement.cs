using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float horizontalMovement = 5f;
    public float verticalMovement = -5f;

    public Rigidbody2D rigidbody2D;

    private Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("move", 1.5f);
    }

    private void move()
    {
        horizontalMovement = Random.Range(0, 2) == 0 ? -1.5f : 1.5f;
        rigidbody2D.velocity = new Vector2(horizontalMovement, verticalMovement);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

        if(collision.gameObject.tag == "Player")
        {
            horizontalMovement = Random.Range(0, 2) == 0 ? -1.5f : 1.5f;
            rigidbody2D.velocity = new Vector2(horizontalMovement, 5);

        }
        else
        {
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rigidbody2D.velocity = direction * Mathf.Max(lastVelocity.magnitude, 0f);
        }
    }
}
