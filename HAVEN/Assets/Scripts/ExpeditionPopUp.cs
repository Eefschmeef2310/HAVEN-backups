using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpeditionPopUp : MonoBehaviour
{
    public EditMode editMode;
    public Canvas expeditionPopUp;

    void OnMouseOver()
    {
        if(!editMode.editing && Input.GetMouseButtonDown(0))
        {
            OpenExpeditionPopUp();
        }
         
    }

    public void OpenExpeditionPopUp()
    {
        expeditionPopUp.gameObject.SetActive(true);
    }

    public void CloseExpeditionPopUp()
    {
        expeditionPopUp.gameObject.SetActive(false);
    }

    public void Expedition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
