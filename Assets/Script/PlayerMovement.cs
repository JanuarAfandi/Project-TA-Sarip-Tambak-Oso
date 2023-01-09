using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody2D;

    private bool isGround;

    [SerializeField] private LayerMask _layerMask;

    private float speed = 100f;

    // Start is called before the first frame update
    void Awake()
    {
        _playerController = new PlayerController();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _playerController.Land.Jump.performed += _ => Jump();
       
    }

    // Update is called once per frame
    void Update()
    {
        var movementInput = _playerController.Land.Move.ReadValue<float>();
        Flip(movementInput);
        transform.position += new Vector3(movementInput * speed * Time.deltaTime, 0, 0);
    }

    private void Flip(float flip)
    {
        if (flip < 0) transform.localScale = new Vector3(-1f, 1, 1);
        else if (flip > 0) transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Jump()
    {
        if (isGround)
        {
            _rigidbody2D.AddForce(new Vector2(0f, 3000f));
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }
}