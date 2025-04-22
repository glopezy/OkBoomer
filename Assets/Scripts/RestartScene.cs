using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        Debug.Log("Restarting Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
