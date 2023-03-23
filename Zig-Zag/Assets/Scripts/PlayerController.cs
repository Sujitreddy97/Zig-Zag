using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    bool gameStarted;
    public bool gameOver;
    public GameObject particle;
    public AudioSource playerAudio;
    public AudioClip tapSound;
    public AudioClip diamondSound;
    public AudioClip gameOverSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                gameStarted = true;
                GameManager.instance.GameStart();
                playerAudio.PlayOneShot(tapSound, 0.5f);
            }
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
            playerAudio.PlayOneShot(tapSound, 0.5f);
        }

        if (!Physics.Raycast(transform.position,Vector3.down,3f))
        {
            gameOver = true;
            Camera.main.GetComponent<FollowCamera>().gameOver = true;
            GameObject.Find("FollowLight").GetComponent<FollowLight>().gameOver = true;
            GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().gameOver = true;
            Destroy(gameObject,1f);
            GameManager.instance.GameOver();
            playerAudio.PlayOneShot(gameOverSound, 0.2f);
        }

       
    }
    void SwitchDirection()
    {
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if(rb.velocity.z > 0)
        {
            rb.velocity=new Vector3(speed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Diamond")
        {
            playerAudio.PlayOneShot(diamondSound, 1f);
            GameObject part= Instantiate(particle, other.gameObject.transform.position, Quaternion.identity);
            Destroy(part.gameObject, 1f);
            Destroy(other.gameObject);
            ScoreManager.instance.IncrementScore(2);
           
        }
    }
}
