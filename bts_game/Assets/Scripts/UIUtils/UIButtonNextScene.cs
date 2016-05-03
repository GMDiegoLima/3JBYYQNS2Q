using UnityEngine;
using System.Collections;
[AddComponentMenu("UI Utils/Load Scene at Click")]
[RequireComponent(typeof(UnityEngine.UI.Button))]
public class UIButtonNextScene : MonoBehaviour {
    public int sceneID = 0;
    private UnityEngine.UI.Button button;
	void Awake()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneID);
        });
    }
}
