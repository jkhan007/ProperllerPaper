using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public bool moveForward= true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        else 
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
}
