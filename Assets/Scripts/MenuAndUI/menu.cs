using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject optionsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ShowOption(bool isActive)
    {
        optionsPanel.SetActive(isActive);
    }
    public void HideOption(bool isActive)
    {
        optionsPanel.SetActive(isActive);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
