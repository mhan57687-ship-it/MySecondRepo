using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    public GameObject howToPanel;

    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void OpenHowTo()
    {
        howToPanel.SetActive(true);
    }
    public void CloseHowTo()
    {
        howToPanel.SetActive(false);
    }
}
