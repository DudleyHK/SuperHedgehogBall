using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        LevelManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        LevelManager.QuitGame();
    }
	
    public void MainMenu()
    {
        LevelManager.LoadScene("MainMenu");
    }
}
