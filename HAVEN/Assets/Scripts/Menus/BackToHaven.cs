using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHaven : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
