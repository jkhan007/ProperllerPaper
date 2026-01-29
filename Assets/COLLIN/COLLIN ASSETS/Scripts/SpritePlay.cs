using System.Collections;
using UnityEngine;

public class SpritePlay : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sp;

    public Sprite[] sprite;
    IEnumerator PlaySP()
    {
        this.sp.enabled = true;
        for (int s = 0; s < sprite.Length; s++)
        {
            sp.sprite = sprite[s];
            yield return new WaitForSeconds(speed);
        }
        this.sp.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void PlayAnim()
    {
        StartCoroutine(PlaySP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
