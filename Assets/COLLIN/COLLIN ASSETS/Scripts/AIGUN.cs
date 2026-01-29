using System.Collections;
using UnityEngine;

public class AIGUN : MonoBehaviour
{

    public GameObject Bullet;
    public Transform startPos;
    public float time;
    public float distance;
    GameObject Player;

    int hits =4;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(shooting());
        

    }

    IEnumerator shooting()
    {

        while(true)
        {
            float _distance = Vector2.Distance(this.transform.position,Player.transform.position);
            
            if(_distance <= distance)
            {
                GameObject obj = Instantiate(Bullet);
                obj.transform.position = startPos.position;
                yield return new WaitForSeconds(time);
            }

            yield return new WaitForEndOfFrame();
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            hits--;
          
         
                        iTween.PunchScale(this.gameObject, 
            iTween.Hash(
                "amount", new Vector3(1.3f, 1.3f, 1.3f),  // how much it scales outward
                "time", 0.3f,                             // duration of the whole punch
                "easetype", iTween.EaseType.easeOutElastic
            )
        );
            
            if(hits<=0)
            {
                Destroy(this.gameObject, 0.3f);
                this.GetComponent<Collider2D>().enabled = false;
                Instantiate(Player.GetComponent<PlayerController>().ExplosionParticle, this.transform.position,Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
