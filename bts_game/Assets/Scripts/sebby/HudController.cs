using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {


    public GameObject ConfigOpen;


    public void AtivarConfig()
    {
        ConfigOpen.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesativarConfig()
    {
        ConfigOpen.SetActive(false);
        Time.timeScale = 1;
    }
}
