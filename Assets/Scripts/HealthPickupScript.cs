using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    [SerializeField] private int ammount = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.hp += ammount;

            Destroy(gameObject);


        }
    }
}
