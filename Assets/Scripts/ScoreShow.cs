using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    private MainManager mainManager;

    private TextMeshProUGUI scoreTable;
    private const float typeSpeed = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = MainManager.Instance; // Get the instance of MainManager

        scoreTable = GetComponent<TextMeshProUGUI>();
        scoreTable.text = "";

        StartCoroutine(TypeText());

        
    }
        
    IEnumerator TypeText()
    {
        for (int i = 0; i < 10; i++)
        {
            string linha = $"{i + 1,-3}-\t {mainManager.scoredPlayerName[i],-15}\t\t:{mainManager.scoredPlayerScore[i],-5} \n";

            foreach (char letter in linha)
            {
                scoreTable.text += letter; // Add each letter to the scoretext
                if (letter != ' ')
                { 
                yield return new WaitForSeconds(typeSpeed); // Wait for a short time before adding the next letter
                }
            }
        }


    }

  
}
