using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }     
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }   
    }
}
