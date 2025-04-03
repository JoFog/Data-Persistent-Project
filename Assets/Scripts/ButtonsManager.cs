using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonsManager : MonoBehaviour
{
    public void LoadMainMenu() // Load the main menu scene
    {
        
       SceneManager.LoadScene(0);
    }


    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene(1);

    }

    public void LoadScoreSene()
    {
        // Load the score scene
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        // Quit the application

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif   
    }

   

   
}
