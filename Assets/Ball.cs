using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 25;
    float HitFactor(Vector2 BallPosition, Vector2 RacketPosition, float RacketHeight)
    {
        return (BallPosition.x - RacketPosition.x) / RacketHeight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Racket")
        {
            float x = HitFactor(transform.position,
                collision.transform.position,
                collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
