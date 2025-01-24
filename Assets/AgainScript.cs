using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainScript : MonoBehaviour
{
   public void playAgain()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
