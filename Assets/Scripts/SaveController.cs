using System.IO;
using Unity.Cinemachine;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "save.json");
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData()
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = Object.FindFirstObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = saveData.playerPosition;
            CinemachineConfiner2D confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();
            GameObject mapBoundary = GameObject.Find(saveData.mapBoundary);
            if (mapBoundary != null)
            {
                confiner.BoundingShape2D = mapBoundary.GetComponent<PolygonCollider2D>();
            }
        }
        else
        {
            SaveGame();
        }
    }
}
