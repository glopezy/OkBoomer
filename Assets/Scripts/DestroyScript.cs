using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    [SerializeField] float time;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, time);
    }
}
