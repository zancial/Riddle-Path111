using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    [SerializeField] public float speed = 3.0f;
    [SerializeField] private float jumpForce = 15.0f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private bool isGrounded = false;

    private charState State
    {
        get { return (charState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded)
            State = charState.idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButton("Jump"))
            Jump();
    }

    private void Run()
    {
        var direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
        if (isGrounded)
            State = charState.walk;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = charState.jump;
    }

    private void CheckGround()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
            State = charState.jump;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AudioManager.Instance.PlaySFX("Lose");
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }

        else if (other.tag == "Door"
            && GetComponent<coinPicker>().key == 1
            && SceneManager.GetActiveScene().buildIndex == 3)
        {
            AudioManager.Instance.PlaySFX("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Russia");
            UnlockLevel();
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }

        else if (other.tag == "Door"
            && GetComponent<coinPicker>().key == 2
            && SceneManager.GetActiveScene().buildIndex == 4)
        {
            AudioManager.Instance.PlaySFX("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Japan");
            UnlockLevel();
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }

        else if (other.tag == "Door"
            && GetComponent<coinPicker>().key == 3 
            && SceneManager.GetActiveScene().buildIndex == 5)
        {
            AudioManager.Instance.PlaySFX("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("France");
            UnlockLevel();
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }

        else if (other.tag == "Door"
            && GetComponent<coinPicker>().key == 4
            && SceneManager.GetActiveScene().buildIndex == 6)
        {
            AudioManager.Instance.PlaySFX("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Italy");
            UnlockLevel();
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }

        else if (other.tag == "Door"
            && GetComponent<coinPicker>().key == 5
            && SceneManager.GetActiveScene().buildIndex == 7)
        {
            AudioManager.Instance.PlaySFX("Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Italy");
            UnlockLevel();
            GetComponent<coinPicker>().key = 0;
            GetComponent<coinPicker>().coins = 0;
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel > PlayerPrefs.GetInt("levels17"))
            PlayerPrefs.SetInt("levels17", currentLevel - 1);
    }
}

public enum charState
{
    idle,
    walk,
    jump,
}