using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ButtonsManager : MonoBehaviour
{
    public TMP_InputField playerNameText; // Reference to the input field for player name

    public void LoadMainMenu() // Load the main menu scene
    {
        
        SceneManager.LoadScene(0);
        
    }

    


    public void StartGame()
    {
        playerNameText = GameObject.Find("PlayerName InputField (TMP)").GetComponent<TMP_InputField>(); // Find the input field for player name
        if (playerNameText.text == "")
        {
            
            MainManager.Instance.currentPlayerName = "Player";
        }
        else
        {
            MainManager.Instance.currentPlayerName = playerNameText.text;
        }
            

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
