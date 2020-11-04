using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerControls : MonoBehaviour
{
    #region variables
    // Public variables
    public GameObject linesEffect;
    [Space]
    [Header("For Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public Transform sceneCamera;
    public Animator animateIt;
    [Space]
    [Header("Rotation taker")]
    public Quaternion leftRotate;
    public Quaternion rightRotate;
    [Space]
    [Header("AudioClips")]
    public AudioClip jumpSound;
    public AudioClip bulletSound;


    // Private Variables
    Vector3 playerSpeed = new Vector3(11f, 0f, 0f);
    Vector3 jumpForce = new Vector3(0f, 5f, 0f);
    [SerializeField] bool isOnGround;
    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    void Update()
    {
        if (!PauseMenu.paused && EventSystem.current.currentSelectedGameObject == null)
        {
            sceneCamera.position = new Vector3(transform.position.x, transform.position.y, -20);
            float inputHorizontal = Input.GetAxis("Horizontal");
            animateIt.SetFloat("left side", Mathf.Abs(inputHorizontal));
            if (inputHorizontal > 0)
            {
                transform.rotation = rightRotate;
                transform.position += playerSpeed * Time.deltaTime;
                SetDeltaTime(1f, true);
            }
            else if (inputHorizontal < 0)
            {
                transform.rotation = leftRotate;
                transform.position -= playerSpeed * Time.deltaTime;
                SetDeltaTime(1f, true);
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isOnGround)
                {
                    AudioSource.PlayClipAtPoint(jumpSound, transform.position);
                    transform.position += jumpForce;
                    isOnGround = false;
                    SetDeltaTime(1f, true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetMouseButtonDown(0))
            {
                StartCoroutine("Bullet");
            }
            else
            {
                SetDeltaTime(0.05f, false);
            }
            // if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            // {
            //     animateIt.SetBool("isSliding", true);
            //     SetDeltaTime(1f, true);
            // }
            // else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            // {
            //     animateIt.SetBool("isSliding", false);
            //     SetDeltaTime(1f, true);
            // }
        }
    }

    void SetDeltaTime(float timeScaleToChange, bool plus)
    {
        if (plus)
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale = timeScaleToChange;
            }
            linesEffect.SetActive(false);
        }
        else if (!plus)
        {
            if (Time.timeScale > 0.1f)
            {
                Time.timeScale -= timeScaleToChange;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
            linesEffect.SetActive(true);
        }
    }
    IEnumerator Bullet()
    {
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
        SetDeltaTime(1f, true);
        yield return new WaitForSeconds(0.34f);
    }
}
