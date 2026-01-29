using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public Sprite[] idle, walking, hit, shoot, dead,dead2;

    public SpriteRenderer sp;
    

    public float moveSpeed = 5f;  // Speed of movement
    public Rigidbody2D rb;
    private float moveX;
    float lastMoveX;
    public float jumpForce = 10f;


    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public GameObject bullet;
    public Transform bulletPosition;


    private bool isGrounded;
    Coroutine spRoutine;

    bool isDead = false;

    public SpritePlay gunAnim;

    public GameObject [] StickBallUI;
    public GameObject [] PlayerStickBall;

    int stick_ball_index =0;


    public GameObject ExplosionParticle, collectParticle;

    public TextMeshProUGUI coin_txt;

    int coin=0;

    void PlayAnimationEvent(Sprite[] data, float time, bool loop = false)
    {
        if (spRoutine != null)
            StopCoroutine(spRoutine);

        spRoutine = StartCoroutine(playAnimation(data, time, loop));
    }
    
    void PlayAnimationEventWithDelay(Sprite[] data, float time, bool loop = false, float delay=0)
    {
        if (spRoutine != null)
            StopCoroutine(spRoutine);

        spRoutine =  StartCoroutine(playAnimation(data, time, loop,delay));
    }

    void stopAnimationEvent()
    {
         if (spRoutine != null)
            StopCoroutine(spRoutine);
    }

    IEnumerator playAnimation(Sprite[] data, float time, bool loop = false, float delay =0)
    {
        yield return new WaitForSeconds(delay);
        do
        {
            for (int s = 0; s < data.Length; s++)
            {
                sp.sprite = data[s];
                yield return new WaitForSeconds(time);
            }
        }
        while (loop);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayAnimationEvent(idle, 0.1f, true);
    }
    Vector3 angle;
    Vector3 SPangle;
    void Update()
    // Update is called once per frame    void Update()
    {
        if (isDead) return;
        angle = transform.rotation.eulerAngles;
        SPangle  =  sp.transform.localRotation.eulerAngles;
        float moveY = Input.GetAxisRaw("Vertical");
        
        if(moveY >= 1)
        {
            SPangle.z = 40;
            
            

        }
        else
        {
         
            SPangle.z = 0;
            
        }


        
        // Get horizontal input (-1 to 1)
        moveX = Input.GetAxisRaw("Horizontal");
        if (moveX < 0)
        {
            //sp.flipX = true;
            angle.y = -180f;  
            SPangle.y = -180f;    
            //sp.flipX = true;     
            
        }
        else if (moveX >= 0)
        {
            //sp.flipX = false;
            angle.y = 0;
            SPangle.y = 0f;    
            //sp.flipX = false;
    
        }
        else
        {
            
        }
        

        transform.rotation = Quaternion.Euler(angle);
        sp.transform.rotation  = Quaternion.Euler(SPangle);

         // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when space is pressed and player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            stopAnimationEvent();
            lastMoveX = 0;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            iTween.PunchScale(this.gameObject, new Vector3(-0.1f, -0.1f, 0f), 0.3f);
            gunAnim.PlayAnim();
            GameObject bullet_temp = Instantiate(bullet, bulletPosition.position, Quaternion.identity);
            if (angle.y != 0)
            {
                bullet_temp.GetComponent<BulletController>().moveForward = false;
            }

            if(SPangle.z != 0)
            {
                
                 if (angle.y != 0)
                 {
                    Vector3 rot = bullet_temp.transform.eulerAngles;
                    rot.z = -40;
                    bullet_temp.transform.eulerAngles = rot;
                 }
                 else
                 {
                    Vector3 rot = bullet_temp.transform.eulerAngles;
                    rot.z = 40;
                    bullet_temp.transform.eulerAngles = rot;
                 }
            }

        }



        if (isGrounded)
        {
            if (moveX == 0 && lastMoveX != 0)
            {
                lastMoveX = moveX;
                PlayAnimationEvent(idle, 0.1f, true);
            }
            else if (moveX < 0 && lastMoveX >= 0 )
            {

                lastMoveX = moveX;
                PlayAnimationEvent(walking, 0.1f, true);
            }
            else if (moveX > 0 && lastMoveX <= 0 )
            {
                lastMoveX = moveX;
                PlayAnimationEvent(walking, 0.1f, true);
            }
        }
        else
        {
            stopAnimationEvent();
            lastMoveX = 0;
        }

            
    }

    void FixedUpdate()
    {
        if (rb != null )
        {
            // Apply horizontal movement
            if (this.transform.rotation.eulerAngles.y == 0)
            {
                rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

            }
            else
            {
                rb.linearVelocity = new Vector2(moveX * moveSpeed, -rb.linearVelocity.y);
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {
            isDead = true;
            PlayAnimationEvent(dead, 0.07f, false);
            Destroy(rb);
            Invoke("loadscene", 2);
            PlayerStickBall[0].transform.parent.gameObject.SetActive(false);

        }
        else if (collision.gameObject.tag == "ai_bullet")
        {
            StickBallUI[stick_ball_index].SetActive(true);
            PlayerStickBall[stick_ball_index].SetActive(true);
            stick_ball_index++;
            Destroy(collision.gameObject);

            if(stick_ball_index == 5)
            {
                isDead = true;
                PlayAnimationEvent(dead2, 0.07f, false);
                Destroy(rb);
                Invoke("loadscene", 2);
                PlayerStickBall[0].transform.parent.gameObject.SetActive(false);
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
           StartCoroutine(SpawnCoinParticle(this.transform.position));
           coin++;
           coin_txt.text = coin.ToString();
        }
       
    }

    IEnumerator SpawnCoinParticle(Vector3 pos)
    {
        yield return new WaitForSeconds(0.15f);
         Instantiate(collectParticle,pos,Quaternion.identity);
    }



    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "showerON")
        {
            
            if(stick_ball_index -1 >=0)
            {
                stick_ball_index--;
                StickBallUI[stick_ball_index].SetActive(false);
                PlayerStickBall[stick_ball_index].SetActive(false);
                
            }
            else if (stick_ball_index ==0)
            {
                
            }
        }
    }

    void loadscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
