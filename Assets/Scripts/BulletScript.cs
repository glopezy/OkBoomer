using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private int dmg = 10;
    [SerializeField] private float shootSpeed = 3f;

    private Rigidbody2D rb;

    private Vector3 direction;


    void Start()
    {

        Debug.Log("Shot");
        rb = GetComponent<Rigidbody2D>();

        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * shootSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * shootSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.TakeDamage(dmg);
            Destroy(gameObject);

        }

        
    }
}
