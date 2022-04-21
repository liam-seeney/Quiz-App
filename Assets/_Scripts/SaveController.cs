using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController
{
    private const string _fileExtension = "/player.data";

    public static void SaveGameData(ScoreController currentGameScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + _fileExtension;
        FileStream stream = new FileStream(path, FileMode.Create);

        GameSessionStats data = new GameSessionStats(currentGameScore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameSessionStats LoadGameData()
    {
        string path = Application.persistentDataPath + _fileExtension;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameSessionStats stats = formatter.Deserialize(stream) as GameSessionStats;
            stream.Close();

            return stats;
        }
        else
        {
            Debug.LogError("No file found at path " + path);
            return null;
        }
    }
}
