using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    //Floats:
    public float maxSpeed = 7f;
    public float speed = 75f;
    public float jumpPower = 1500f;

    //Booleans: 
    public bool grounded;

    //References:
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //rb2d.AddForce((Vector2.right * speed) * h);
        if (Input.GetButtonDown("Horizontal"))
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(Vector2.right * 2500 * h);
            rb2d.AddForce(Vector2.up * 200);
        }
    }

    void FixedUpdate()
    {


        //limit positive velocity on x
        if (rb2d.velocity.x > 3)
        {
            rb2d.velocity = new Vector2(3, rb2d.velocity.y);
        }
        //limit negative velocity on x
        if (rb2d.velocity.x < -3)
        {
            rb2d.velocity = new Vector2(-3, rb2d.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        grounded = false;
    }
}
