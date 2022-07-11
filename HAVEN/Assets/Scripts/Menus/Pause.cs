using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }
    public void Setup() 
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}