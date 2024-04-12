using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(DataManager dataManager)
    {
        //Create a system that convert values into binary
        BinaryFormatter formatter = new BinaryFormatter();

        //create path in file that contain gamefiles
        string path = Application.persistentDataPath + "/data.txt";

        //create file that will contain binary values
        FileStream stream = new FileStream(path, FileMode.Create);

        //Recieve values from dataManager
        GameData data = new GameData(dataManager);

        //convert datas into binary
        formatter.Serialize(stream, data);
        
        //close file
        stream.Close();
    }

    public static GameData LoadData()
    {
        //find the text file where datas are located
        string path = Application.persistentDataPath + "/data.txt";

        if(File.Exists(path))
        {
            //Create a system that convert binary values into readable values for unity 
            BinaryFormatter formatter = new BinaryFormatter();

            //open the file to read into
            FileStream stream = new FileStream(path, FileMode.Open);

            //convert datas into readable values for unity
            GameData data = formatter.Deserialize(stream) as GameData;

            //close file 
            stream.Close();

            //return data to use them 
            return data;
        }
        else
        {
            //if no file, retrun null
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void ResetData()
    {
        string path = Application.persistentDataPath + "/data.txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            return;
        }
    }

    public static bool HaveSave()
    {
        string path = Application.persistentDataPath + "/data.txt";
        return File.Exists(path);
    }

}
