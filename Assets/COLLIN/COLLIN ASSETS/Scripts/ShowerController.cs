using System.Collections;
using UnityEngine;

public class ShowerController : MonoBehaviour
{

    public Sprite []ShowerOff;
    public Sprite []ShowerOn;
    public SpriteRenderer sp;

    public float speed = 0.1f;

    public GameObject activeObj;

    IEnumerator playAnim(Sprite [] anim)
    {
        while(true)
        {
            for(int s=0;s<anim.Length;s++)
            {
                sp.sprite = anim[s];
                yield return new WaitForSeconds(speed);
            }
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(playAnim(ShowerOff));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet")
        {
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(collision.gameObject);
            StopAllCoroutines();
            StartCoroutine(playAnim(ShowerOn));
            activeObj.SetActive(true);
            Invoke(nameof(StopShower),7);
            StartCoroutine(blinkobj());
        }
    }

    IEnumerator blinkobj()
    {
        while(true)
        {
            activeObj.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            activeObj.SetActive(false);
            yield return new WaitForSeconds(0.4f);
        }
    }

    void StopShower()
    {
        StopAllCoroutines();
        StartCoroutine(playAnim(ShowerOff));
        activeObj.SetActive(false);
        this.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
