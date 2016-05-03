using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public static class Serializer {

	public static string appPath = Application.dataPath + "/" + "app.xml";

	/// <summary>
	/// Write the APP on xml file
	/// </summary>
	/// <returns><c>true</c>, If can write, <c>false</c> otherwise.</returns>
	/// <param name="app"> current APP </param>
	public static bool WritePlayerPrefs( AdvancedPlayerPrefs app )
	{

		try 
		{
			var serializer = new XmlSerializer(typeof(AdvancedPlayerPrefs));
			using (var writer = new FileStream(appPath, FileMode.Create))
			{
				serializer.Serialize (writer, app);
				return true;
			}
		} 
		catch 
		{
			return false;
		}
	}

	/// <summary>
	/// Get APP from xml file
	/// </summary>
	/// <returns>Return APP if found, else return null.</returns>
	public static AdvancedPlayerPrefs GetPlayerPrefs( )
	{
		try 
		{
			var serializer = new XmlSerializer(typeof(AdvancedPlayerPrefs));
			using(var reader = new FileStream(appPath, FileMode.Open))
			{
				return serializer.Deserialize(reader) as AdvancedPlayerPrefs;
			}
		}
		catch
		{
			return null;
		}
	}
}
