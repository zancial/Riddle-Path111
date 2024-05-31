using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMeneger : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("Germany");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("Russia");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("Japan");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("France");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("Italy");
    }

    public void Level6()
    {
        SceneManager.LoadScene("Level 6");
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("China");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic("Music");
        }
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}