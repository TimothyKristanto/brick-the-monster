using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrick : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // keyboard input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.MovePosition(rigidBody.position + new Vector2(moveSpeed, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.MovePosition(rigidBody.position - new Vector2(moveSpeed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidBody.MovePosition(rigidBody.position - new Vector2(0, 0));
    }
}
