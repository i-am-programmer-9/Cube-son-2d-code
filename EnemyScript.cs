using UnityEngine;
using System.Collections;
public class EnemyScript : MonoBehaviour
{
    #region variables
    // Public Variables
    public bool isDummy;
    public Transform player;
    public bool isPlayerInRange;
    [Space]
    [Header("For Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletPosition;

    //Private Variables
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            DieTheEnemy();
        }
    }
    void Update()
    {
        if (!isDummy && player != null && PauseMenu.paused == false)
        {
            if(Mathf.Abs(transform.position.x - player.position.x) <= 10)
            {
                isPlayerInRange = true;
            }
            if (isPlayerInRange)
            {
                StartCoroutine("Bullet");
            }
        }
    }
    IEnumerator Bullet()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
    }
    void DieTheEnemy()
    {
        Destroy(gameObject);
    }
}
