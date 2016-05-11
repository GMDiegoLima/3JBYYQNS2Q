using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class ControllerStates {
    [SerializeField]
    public List<CState> states;
}
[System.Serializable]
public class CState
{
    [SerializeField]
    public string name;
    [SerializeField]
    public PlayerVariables obj;
#if UNITY_EDITOR
    public TextAsset asset;
#endif
}
public class ControllerSerialization
{
#if UNITY_EDITOR
    public static void Save(object t,string path)
    {
        try
        {
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
            }
        }
        catch (System.UnauthorizedAccessException e)
        {
            Debug.LogError("ERROR TO SAVE: " + e.ToString());
        }
    }
#endif
    public static object Load(string path)
    {
        object state = null;
        try
        {
            IFormatter formatter = new BinaryFormatter();
            using(Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                state = formatter.Deserialize(stream);
            }
        }
        catch (System.UnauthorizedAccessException e)
        {
            Debug.LogError("ERROR TO LOAD: " + e.ToString());
        }
        return state;
    }
    public static object Load(byte[] buffer)
    {
        object state = null;
        using(MemoryStream stream = new MemoryStream(buffer))
        {
            state = new BinaryFormatter().Deserialize(stream);
        }
        return state;
    }
}
