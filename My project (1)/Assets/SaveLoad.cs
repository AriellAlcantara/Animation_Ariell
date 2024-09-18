using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) SaveData();
        if (Input.GetKeyDown(KeyCode.P)) LoadData();
    }

    void SaveData()
    {
        SaveDataClass data = new SaveDataClass();
        data.playerPosition = player.transform.position;

        for (int i = 0; i < enemies.Length; i++)
        {
            data.enemyPositions.Add(enemies[i].transform.position);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataClass data = JsonUtility.FromJson<SaveDataClass>(json);

            player.transform.position = data.playerPosition;

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.position = data.enemyPositions[i];
            }
        }
    }
}

[System.Serializable]
public class SaveDataClass
{
    public Vector3 playerPosition;
    public List<Vector3> enemyPositions = new List<Vector3>();
}
