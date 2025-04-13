using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed;
    
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity;

    [SerializeField]  private Camera cam;

    [SerializeField] private GameObject impactPrefab;


    [SerializeField] public int currentAmmo;

    [SerializeField] private Animator gunAnim;

    [SerializeField] private int hp;
    [SerializeField] private int maxHp = 100;
    private bool isDead;

    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {

        instance = this;

    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        hp = maxHp;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Move();
            Aim();
            Shoot();
        }
        
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

        cam.transform.localRotation = Quaternion.Euler(cam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentAmmo>0)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("looking at " + hit.transform.name);
                    Instantiate(impactPrefab, hit.point, transform.rotation);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyScript>().TakeDamage();
                    }
                }
                else
                {
                    Debug.Log("looking at nothing");

                }
                currentAmmo--;

                gunAnim.SetTrigger("Shoot");
            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            deathScreen.SetActive(true);
            isDead = true;
        }

        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    
}
