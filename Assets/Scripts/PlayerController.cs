using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float speed;
    private float horizontalInput;
    public float nitroBoostFacor;
    public GameObject nitroFlames;
    private Rigidbody rb;
    public GameObject engineSound;
    public GameObject woodHitSound;
    private bool isJumping = false;
    public float jumpForce;
    public int playerNumber;
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode boostKey;
    private KeyCode jumpKey;
    public ScoreManager scoreManager;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        if (playerNumber == 1)
        {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
            leftKey = KeyCode.LeftArrow;
            rightKey = KeyCode.RightArrow;
            boostKey = KeyCode.RightShift;
            jumpKey = KeyCode.Return;
        }
        else
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
            boostKey = KeyCode.LeftShift;
            jumpKey = KeyCode.Space;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        DetectNitroBoost();
        FixRotation();
    }

    void FixRotation()
    {
        if (transform.rotation.eulerAngles.y > 2 && transform.rotation.eulerAngles.y < 358)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce * DetectNitroBoost());
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey(upKey) && !isJumping)
        {
            if (DetectNitroBoost() != nitroBoostFacor)
            {
                engineSound.SetActive(true);
            }
            else
            {
                engineSound.SetActive(false);
            }
            rb.AddForce(Vector3.forward * speed * DetectNitroBoost());
        }
        else
        {
            engineSound.SetActive(false);
        }

        if (Input.GetKey(rightKey))
        {
            transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
        }

        if (Input.GetKey(leftKey))
        {
            transform.Translate(Vector3.left * Time.deltaTime * turnSpeed);
        }

        if (Input.GetKey(downKey))
        {
            rb.AddForce(Vector3.back * speed * DetectNitroBoost());
        }
    }

    float DetectNitroBoost()
    {
        if (Input.GetKey(boostKey))
        {
            EnableNitroEffect();
            return nitroBoostFacor;
        }
        else
        {
            DisableNitroEffect();
            return 1;
        }
    }

    void EnableNitroEffect()
    {
        // TODO: Add motion blur.
        nitroFlames.SetActive(true);
    }

    void DisableNitroEffect()
    {
        nitroFlames.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "WoodBox")
        {
            other.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
            scoreManager.AddScore(-100, playerNumber);
            woodHitSound.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.tag == "Road")
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WoodBox")
        {
            scoreManager.AddScore(100, playerNumber);
            other.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
        }
    }
}
