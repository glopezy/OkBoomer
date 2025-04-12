using UnityEngine;

public class BillBoardScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);

    }
}
