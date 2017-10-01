using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuManager : MonoBehaviour
{
    public void LoadLevel1()
    {
<<<<<<< HEAD:Assets/MenuManager.cs
        SceneManager.LoadScene(2);
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
=======
        LevelManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> 45ec420650383b86f2687ec356390f797678bbd8:Assets/Objects/Menu/MenuManager.cs
    }

    public void QuitGame()
    {
        LevelManager.QuitGame();
    }
	
}
