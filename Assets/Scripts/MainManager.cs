using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance; // Singleton instance

    public string[] scoredPlayerName = new string[10]; // Array to store player names
    public int[] scoredPlayerScore = new int[10]; // Array to store player scores
    
    public string currentPlayerName; // Variable to store the current player's name


    private void Awake()
    {
        if (Instance != null) // If there is already an instance of MainManager, destroy this one
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Don't destroy this object when loading a new scene
        
    }


    private void Start()
    {
        
        currentPlayerName = null;
        // Load data when the game starts
        LoadData();

    }


    [System.Serializable]

    class DataToSave
    {
        // Enter below the data to be saved
        public string[] scoredPlayerName = new string[10]; // Array to store player names
        public int[] scoredPlayerScore = new int[10]; // Array to store player scores



    }

    public void SaveData()
    {
        DataToSave data = new()
        {
            // Enter below the data to be saved
            scoredPlayerName = scoredPlayerName,
            scoredPlayerScore = scoredPlayerScore
        };



        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataToSave data = JsonUtility.FromJson<DataToSave>(json);
            // Enter below the data to be loaded
            scoredPlayerScore = data.scoredPlayerScore;
            scoredPlayerName = data.scoredPlayerName;


        }

    }
}

