using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioListener[] AudioListners;
    public Texture Quality, Volume, TextureCredits, TextureMenuBackgrounds, TextureOptions;
    private bool InMainMenu, InOptions, InCredits;
    public GUIStyle StyleButtonsMain, StyleGraphicalButtons;
    private float VOLUME;
    private int graphicQuality;
    public Font Fonte;
    public int myFontSize = 4;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        InMainMenu = true;
        Cursor.visible = true;
        Time.timeScale = 1;

        //SALVA AS PREFERÊNCIAS
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            VOLUME = PlayerPrefs.GetFloat("VOLUME");
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUME", VOLUME);
        }
        
        if (PlayerPrefs.HasKey("graphicQuality"))
        {
            graphicQuality = PlayerPrefs.GetInt("graphicQuality");
            QualitySettings.SetQualityLevel(graphicQuality);
        }
        else
        {
            PlayerPrefs.SetInt("graphicQuality", graphicQuality);
        }
    }

    void Update()
    {
        //Preencher Arrays
        if (Application.loadedLevelName != "SceneMainMenu")
        {
            AudioListners = GameObject.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
            AudioListener.volume = VOLUME;
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        GUI.skin.font = Fonte;
        StyleButtonsMain.fontSize = Screen.height / 100 * myFontSize;
        StyleGraphicalButtons.fontSize = Screen.height / 100 * myFontSize;
        
        //Se estiver no menu principal
        if (InMainMenu == true)
        {
            GUI.skin.button = StyleButtonsMain;
            GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TextureMenuBackgrounds);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 5.5f, Screen.width / 8, Screen.height / 14), "Iniciar"))
            {
                SceneManager.LoadScene("Test");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 16, Screen.height / 2 - Screen.height / 16, Screen.width / 8, Screen.height / 14), "Opções"))
            {
                InMainMenu = false;
                InOptions = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 16, Screen.height / 2 + Screen.height / 16, Screen.width / 8, Screen.height / 14), "Sobre"))
            {
                InMainMenu = false;
                InCredits = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 16, Screen.height / 2 + Screen.height / 5.5f, Screen.width / 8, Screen.height / 14), "Sair"))
            {
                Application.Quit();
            }
        }
        
        //Se estiver nas opções
        if (InOptions == true)
        {
            GUI.skin.button = StyleGraphicalButtons;
            GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TextureOptions);
            GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 2.5f, Screen.width / 8, Screen.height / 14), Quality);
            GUI.DrawTexture(new Rect(Screen.width / 2 + Screen.width / 5, Screen.height / 2 - Screen.height / 10, Screen.width / 8, Screen.height / 14), Volume);
            
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 2.2f, Screen.height / 2 + Screen.height / 2.5f, Screen.width / 8, Screen.height / 14), "Voltar"))
            {
                InMainMenu = true;
                InOptions = false;
            }

            //QUALIDADES
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 4, Screen.width / 8, Screen.height / 14), "Péssimo"))
            {
                QualitySettings.SetQualityLevel(0);
                graphicQuality = 0;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 6, Screen.width / 8, Screen.height / 14), "Ruim"))
            {
                QualitySettings.SetQualityLevel(1);
                graphicQuality = 1;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 12, Screen.width / 8, Screen.height / 14), "Simples"))
            {
                QualitySettings.SetQualityLevel(2);
                graphicQuality = 2;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2, Screen.width / 8, Screen.height / 14), "Bom"))
            {
                QualitySettings.SetQualityLevel(3);
                graphicQuality = 3;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 12, Screen.width / 8, Screen.height / 14), "Ótimo"))
            {
                QualitySettings.SetQualityLevel(4);
                graphicQuality = 4;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 + Screen.height / 6, Screen.width / 8, Screen.height / 14), "Excelente"))
            {
                QualitySettings.SetQualityLevel(5);
                graphicQuality = 5;
            }
           
            //VOLUME
            VOLUME = GUI.HorizontalSlider(new Rect(Screen.width / 2 + Screen.width / 5, Screen.height / 2, Screen.width / 8, Screen.height / 14), VOLUME, 0, 1);
            //SALVAR PREFERENCIAS
            if (GUI.Button(new Rect(Screen.width / 2 + Screen.width / 5, Screen.height / 2 + Screen.height / 3, Screen.width / 8, Screen.height / 14), "Salvar"))
            {
                PlayerPrefs.SetFloat("VOLUME", VOLUME);
                PlayerPrefs.SetInt("graphicQuality", graphicQuality);
            }
        }
        //Se estiver nos créditos
        if (InCredits == true)
        {
            GUI.skin.button = StyleGraphicalButtons;
            GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2, Screen.width, Screen.height), TextureCredits);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 2.2f, Screen.height / 2 + Screen.height / 2.5f, Screen.width / 8, Screen.height / 14), "Voltar"))
            {
                InMainMenu = true;
                InCredits = false;
            }
        }
    }
}