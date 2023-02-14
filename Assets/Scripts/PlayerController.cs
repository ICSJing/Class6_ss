using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameManager gameManager;
    private float jumpForce = 12f;
    private bool grounded = true;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);  //forceMode.Impulse only do one times. 
            grounded = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        } else if(collision.gameObject.tag == "Obstacle")
        {
            gameManager.EndGame();
        }
    }
}
