using UnityEngine;
using System.Collections;

public class APPTest : MonoBehaviour {

	void Start(){

		//Creating APP
		var prefs = new AdvancedPlayerPrefs ();
		prefs.characterClass = "Mage";
		prefs.characterLevel = 1;
		prefs.characterName = "Teste";

		//Testing Save Method
		if (Serializer.WritePlayerPrefs (prefs))
			Debug.Log ("Teste: Save Successfull");
		else
			Debug.LogError ("Teste: Save Failed");

		//Testing Load Method
		prefs = Serializer.GetPlayerPrefs ();
		if (prefs != null)
			Debug.Log ("Teste: Load Successfull");
		else
			Debug.LogError ("Teste: Load Failed");
	}
}
