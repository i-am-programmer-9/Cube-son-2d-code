using UnityEngine;

public class PlayerOtherWorks : MonoBehaviour
{
    #region variables
    private float health = 100f;
    public GameObject youDeadCanvas;
    public GameObject youWinPanel;
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            HealthDown(100f);
        }
        if (other.CompareTag("Finish"))
        {
            youWinPanel.SetActive(true);
        }
    }
    private void HealthDown(float toMinus)
    {
        health -= toMinus;
        if(health <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        youDeadCanvas.SetActive(true);
    }
    private void YouWin()
    {
        youWinPanel.SetActive(true);
    }
}
