using UnityEngine;
using System.Collections;

public class ChangeQuality : MonoBehaviour {

    public void ChangeToQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
