using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public CanvasGroup hudGroup;
    
    public void OpenOptions()
    {
        Time.timeScale = 0f;

        hudGroup.alpha = 0.3f;
        hudGroup.interactable = false;
        hudGroup.blocksRaycasts = false;
    }

    public void CloseOptions()
    {
        Time.timeScale = 1f;

        hudGroup.alpha = 1f;
        hudGroup.interactable = true;
        hudGroup.blocksRaycasts = true;
    }
}
