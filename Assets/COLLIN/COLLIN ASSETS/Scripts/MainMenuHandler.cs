using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}
