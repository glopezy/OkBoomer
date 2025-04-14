using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerRange = 10f;

    private Rigidbody2D rb;

    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool canShoot;
    [SerializeField] private float fireRate = 0.5f;
    public float lastFired;
    [SerializeField] private Transform firePosition;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void TakeDamage()
    {
        hp--;
        if(hp <= 0)
        {
            AudioScript.instance.PlayEnemyDeath();
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            rb.linearVelocity = playerDirection.normalized * moveSpeed;

            if (canShoot)
            {
                Shoot();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void Shoot()
    {
        lastFired -= Time.deltaTime;
        if (lastFired <= 0)
        {
            Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            lastFired = fireRate;
        }
    }
}
