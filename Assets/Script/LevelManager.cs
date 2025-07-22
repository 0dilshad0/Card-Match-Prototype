using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private string LEVEL_MEDIUM = "MEDIUM";
    private string LEVEL_HARD = "HARD";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;    
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string LevelName) //start level
    {
        if(CheckISUnlocked(LevelName))
        {
            SceneManager.LoadScene(LevelName);
        }
    }


    public void UnlockLevel(string LevelName) //unlock level
    {

        if(LevelName == "Medium")
        {
            PlayerPrefs.SetInt(LEVEL_MEDIUM, 1);
        }
        else if(LevelName == "Hard")
        {
            PlayerPrefs.SetInt(LEVEL_HARD, 1);
        }
        PlayerPrefs.Save();

    }

    public bool CheckISUnlocked(string LevelName) //Check Levels are lock or not
    {
        if (LevelName == "Easy")
        {
            return true;
        }
        else if(LevelName == "Medium")
        {
            return PlayerPrefs.GetInt(LEVEL_MEDIUM) == 1;
        }  
        else if(LevelName == "Hard")
        {
            return PlayerPrefs.GetInt(LEVEL_HARD) == 1;
        }
        return false;

    }

    public void ResetKey()//rset seves 
    {
        PlayerPrefs.DeleteKey(LEVEL_HARD);
        PlayerPrefs.DeleteKey(LEVEL_MEDIUM);
    }

    public void Back()
    {
        SceneManager.LoadScene("Home");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
