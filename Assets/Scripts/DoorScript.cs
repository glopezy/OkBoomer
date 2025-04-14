using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform doorPosition;
    [SerializeField] private GameObject col;

    [SerializeField] private float openSpeed;
    private bool canOpen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && doorPosition.position.z != 1f)
        {
            Open();

        }

        else if (!canOpen && doorPosition.position.z != 0f)
        {
            Close();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
           canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = false;
        }
    }

    private void Open()
    {
        doorPosition.position = Vector3.MoveTowards(doorPosition.position, new Vector3(doorPosition.position.x, doorPosition.position.y, 1f), openSpeed*Time.deltaTime);
        if (doorPosition.position.z == 1f)
        {
            col.SetActive(false);
        }
    }

    private void Close()
    {
        doorPosition.position = Vector3.MoveTowards(doorPosition.position, new Vector3(doorPosition.position.x, doorPosition.position.y, 0f), openSpeed * Time.deltaTime);
        if (doorPosition.position.z == 0f)
        {
            col.SetActive(true);
        }
    }
}
