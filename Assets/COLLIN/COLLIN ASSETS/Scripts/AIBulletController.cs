using UnityEngine;

public class AIBulletController : MonoBehaviour
{
    public float speed;
    Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition =  (GameObject.FindGameObjectWithTag("Player").transform.position);
        LookAt2D(GameObject.FindGameObjectWithTag("Player").transform);
        
        
    }

    public void LookAt2D(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Update is called once per frame
    void Update()
    {
         //this.transform.position =  Vector3.Lerp(this.transform.position, targetPosition, speed*Time.deltaTime );
         this.transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
