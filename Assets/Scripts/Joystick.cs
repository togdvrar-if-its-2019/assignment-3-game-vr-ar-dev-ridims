using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private float oneOrZero;
    private bool facingRight = true;

    public Transform circle;
    public Transform outerCircle;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

        if (oneOrZero < 0)
        {
            Vector3 playerLocalScale = transform.localScale;
            playerLocalScale.x = -1;
            player.transform.localScale = playerLocalScale;
        } else if(oneOrZero > 0)
        {
            Vector3 playerLocalScale = transform.localScale;
            playerLocalScale.x = 1;
            player.transform.localScale = playerLocalScale;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            oneOrZero = offset.x;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            //moveCharacter(direction * -1);
            moveCharacter(direction);
            oneOrZero = offset.x;
            
            //animation
            animator.SetFloat("Speed", 1);

            //circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            animator.SetFloat("Speed", 0);

            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
