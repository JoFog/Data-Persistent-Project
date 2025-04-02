using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance; // Singleton instance


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


    [System.Serializable]

    class DataToSave
    {
        // Enter below the data to be saved




    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        // Enter below the data to be saved


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



        }

    }
}

