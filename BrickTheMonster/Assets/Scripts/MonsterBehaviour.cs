using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBehaviour : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameController gameController;

    private float xMove;

    // Start is called before the first frame update
    void Start()
    {
        xMove = Random.Range(0, 2) == 0 ? 0.5f : -0.5f;

        rigidbody2D.velocity = new Vector2(xMove, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            Destroy(gameObject);
            gameController.countDeath();
        }

        if(collision.tag == "ScreenBorder")
        {
            xMove = -xMove;
            transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.5f);
            rigidbody2D.velocity = new Vector2(xMove, 0f);
        }

        if(collision.tag == "GameOver")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
