using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameManager gameManager;
    private float jumpForce = 12f;
    private bool grounded = true;
    [SerializeField] private Animator anim;
    private bool dead = false;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource audioSrc;
    private Coroutine coroutine;
   

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        // StartCoroutine(OnCollisionEnter());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded && !dead)
        {
            dirtParticle.Stop();
            audioSrc.PlayOneShot(jumpSound);
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);  //forceMode.Impulse only do one times. 
            grounded = false;
            anim.SetTrigger("Jump_trig");
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            dirtParticle.Play();
        } else if(collision.gameObject.tag == "Obstacle")
        {
            dirtParticle.Stop();
            audioSrc.PlayOneShot(crashSound);
            explosionParticle.Play();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dead = true;
            gameManager.EndGame();
        }
    }

    public void Reset()
    {
        anim.SetBool("Death_b", false);
        anim.Play("Alive", -1, 0f);
        dead = false;
        dirtParticle.Play();
    }

}
