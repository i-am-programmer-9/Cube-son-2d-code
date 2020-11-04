using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public static BulletScript _bulletInstance;
    public static BulletScript bullScr
    {
        get
        {
            if (_bulletInstance == null)
            {
                _bulletInstance = GameObject.FindObjectOfType<BulletScript>();
            }
            return _bulletInstance;
        }
    }
    public Rigidbody2D bulletRb;
    [SerializeField] Vector2 speed = new Vector2(13f, 0f);

    void Update()
    {
        if (PauseMenu.paused == false)
        {
            rbVelocityAdder();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    public void rbVelocityAdder()
    {
        bulletRb.velocity = transform.right * speed;
    }
}
