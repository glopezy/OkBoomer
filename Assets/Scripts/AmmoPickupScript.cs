using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    [SerializeField] private int ammount = 25;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.instance.currentAmmo += ammount;

            Destroy(gameObject);

            AudioScript.instance.PlayAmmoPickup();

        }
    }
}
