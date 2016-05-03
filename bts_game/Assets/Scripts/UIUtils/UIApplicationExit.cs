using UnityEngine;
using System.Collections;
[AddComponentMenu("UI Utils/App Exit Button Event")]
[RequireComponent(typeof(UnityEngine.UI.Button))]
public class UIApplicationExit : MonoBehaviour {
    [SerializeField]
    [Tooltip("Force Application Quit")]
    private bool force = false;
    UnityEngine.UI.Button button;
    void Awake()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(() =>
        {
            if (force)
            {
                // Force Killing App destroying the main thread
#if !UNITY_EDITOR
                if(Application.isPlaying)
                System.Threading.Thread.CurrentThread.Abort();
#endif
            }
            else {
                Application.Quit();
            }
        });
    }
}
