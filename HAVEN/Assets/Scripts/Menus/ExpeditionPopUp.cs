using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ExpeditionPopUp : MonoBehaviour
{
    public EditMode editMode;
    public Canvas expeditionPopUp;
    public TextMeshProUGUI text;

    void Update()
    {
        if(expeditionPopUp.isActiveAndEnabled && Input.anyKeyDown)
        {
            if(!Input.GetMouseButton(0))
                {
                    CloseExpeditionPopUp();
                }
        }
    }

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
        text.gameObject.SetActive(true);
    }

    public void CloseExpeditionPopUp()
    {
        expeditionPopUp.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void Expedition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
