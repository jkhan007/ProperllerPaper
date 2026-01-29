using System.Collections;
using UnityEngine;

public class AIAgent : MonoBehaviour
{

    public GameObject p1,p2;
    public float speed =0;

    public Vector3 target;

    public SpriteRenderer sp;

    public int health;

    public int impact;

    public GameObject particle;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = p1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target,this.transform.position) <=1)
        {
            if(target == p1.transform.position)
            {
                target = p2.transform.position;
            }
            else
            {
                target = p1.transform.position;
            }
        }

        if(target.x <= this.transform.position.x)
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            sp.flipX = true;
        }
        else if(target.x >= this.transform.position.x)
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            sp.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            this.health -= impact;
            if(health <=0)
            {
                Instantiate(particle, this.transform.position,Quaternion.identity);
                Destroy(this.gameObject);

            }
            else
            {
                              iTween.PunchScale(this.gameObject, 
            iTween.Hash(
                "amount", new Vector3(0.8f, 0.8f, 1.3f),  // how much it scales outward
                "time", 0.3f,                             // duration of the whole punch
                "easetype", iTween.EaseType.easeOutElastic
            )
        );
            }
        }
    }
}
