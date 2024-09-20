using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CharaterAnimation characterAnimation;


    private bool isFacingRight = true;
    private void Update()
    {
        PlayerMovie();
    }

    private void PlayerMovie()
    {
        float xHorizontal = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(xHorizontal* speed, rb.velocity.y);
        rb.velocity = velocity;

        characterAnimation.SetFloat("velocity", Mathf.Abs(velocity.x));

        FlipHandler(velocity);
    }
    private void FlipHandler(Vector2 velocity)
    {
        Vector3 localScale = transform.localScale;
        if (isFacingRight)
        {
            if(velocity.x < 0)
            {
                isFacingRight = false;
                localScale.x = -1;
            } 
        }
        else
        {
            if (velocity.x > 0)
            {
                isFacingRight=true;
                localScale.x = 1;
            }
        }
        transform.localScale = localScale;
            
    }

}
