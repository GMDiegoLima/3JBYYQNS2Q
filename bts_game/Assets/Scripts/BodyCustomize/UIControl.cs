using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIControl : MonoBehaviour {

	public BodyCustomize player;

	public bool change; // caso tenha sido modificado
	public bool customize; // abrir e fechar menu de customização
	public GameObject customizeMenu; // menu de customização

	public Slider magoSlider; // Slider de alteração do mago
	public Slider hairSlider; // Slider de alteração do cabelo
	public Slider skinSlider; // Slider de alteração da pele

	private MeshFilter hairBKP; // backup de textura para cabelo / Para save e load apenas esse valor deverá ser alterado
	private MeshFilter skinBKP; // backup de textura para pele / Para save e load apenas esse valor deverá ser alterado

	public int hairValueBKP; // backup de textura para cabelo
	public int skinValueBKP; // backup de textura para pele

	public List<Magos> magos = new List<Magos>();

	[System.Serializable]
	public class Magos {
		public string name; // nome para caso queira mostrar ao menu de opções
		public List<HairParts> hairs = new List<HairParts>();
		public List<SkinParts> skins = new List<SkinParts>();
	}
	[System.Serializable]
	public class HairParts {
		public string name; // nome para caso queira mostrar ao menu de opções
		public Mesh hair; // textura para cabelo
		public Material material; // textura para cabelo
	}
	[System.Serializable]
	public class SkinParts {
		public string name; // nome para caso queira mostrar ao menu de opções
		public Mesh skin; // textura para pele
		public Material material; // textura para cabelo
	}

	void Start () {
		customizeMenu.SetActive (customize);
		player.hair.mesh = magos[(int)magoSlider.value].hairs [hairValueBKP].hair;
		player.skin.mesh = magos[(int)magoSlider.value].skins [skinValueBKP].skin;
		player.hairRenderer.material = magos[(int)magoSlider.value].hairs [hairValueBKP].material;
		player.skinRenderer.material = magos[(int)magoSlider.value].skins [skinValueBKP].material;
	}

	void Update () {
		customizeMenu.SetActive (customize);
		if (customize) {
			player.hair.mesh = magos[(int)magoSlider.value].hairs [(int)hairSlider.value].hair;
			player.skin.mesh = magos[(int)magoSlider.value].skins [(int)skinSlider.value].skin;
			player.hairRenderer.material = magos[(int)magoSlider.value].hairs [(int)hairSlider.value].material;
			player.skinRenderer.material = magos[(int)magoSlider.value].skins [(int)skinSlider.value].material;
		}
		if (hairSlider.value != hairValueBKP || skinSlider.value != skinValueBKP) {
			change = true;
		} else if (hairSlider.value == hairValueBKP && skinSlider.value == skinValueBKP) {
			change = false;
		}
	}

	public void Apply () { // aplicar personalização / aplica nova personalização
		hairValueBKP = (int)hairSlider.value;
		skinValueBKP = (int)skinSlider.value;
		player.hair.mesh = magos[(int)magoSlider.value].hairs [(int)hairSlider.value].hair;
		player.skin.mesh = magos[(int)magoSlider.value].skins [(int)skinSlider.value].skin;
		player.hairRenderer.material = magos[(int)magoSlider.value].hairs [(int)hairSlider.value].material;
		player.skinRenderer.material = magos[(int)magoSlider.value].skins [(int)skinSlider.value].material;
		SetOff ();
	}

	public void Cancel () { // cancela personalização / cancela nova personalização
		player.hair.mesh = magos[(int)magoSlider.value].hairs [(int)hairValueBKP].hair;
		player.skin.mesh = magos[(int)magoSlider.value].skins [(int)skinValueBKP].skin;
		player.hairRenderer.material = magos[(int)magoSlider.value].hairs [(int)hairValueBKP].material;
		player.skinRenderer.material = magos[(int)magoSlider.value].skins [(int)skinValueBKP].material;
		change = false;
		SetOff ();
	}

	public void SetOn () {
		hairSlider.value = hairValueBKP;
		skinSlider.value = skinValueBKP;
		customize = true;
	}

	public void SetOff () {
		if (change) {
			Cancel ();
		} else {
			customize = false;
		}
	}
}
