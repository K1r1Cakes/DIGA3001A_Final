using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float bulletSpeed = 8f;


    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
    }

    public void BulletHit()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Bullet hit" +other.name);
}
}
