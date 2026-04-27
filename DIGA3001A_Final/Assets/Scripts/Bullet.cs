using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float bulletSpeed = 8f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        if (transform.position.x > 8f)
        {
            Destroy(this.gameObject);
        }
    }

    public void BulletHit()
    {
        Destroy(this.gameObject);
    }
}
