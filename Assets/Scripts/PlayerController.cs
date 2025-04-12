using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Aim();
    }

    private void Move()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveH = transform.up * -moveInput.x;
        Vector3 moveV = transform.right * moveInput.y;

        rb.linearVelocity = (moveH + moveV) * moveSpeed;
    }

    private void Aim()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);  
    }
}
