using TMPro;
using UnityEngine;


public class PlayerMenuBack : MonoBehaviour
{
    
    public TMP_InputField playerNameText;
    private MainManager mainManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = MainManager.Instance; // Get the instance of MainManager
        if (mainManager.currentPlayerName != null)
        {
            playerNameText.text = mainManager.currentPlayerName; // Set the text to the current player's name
        }
        
        
        

    }

   
}
