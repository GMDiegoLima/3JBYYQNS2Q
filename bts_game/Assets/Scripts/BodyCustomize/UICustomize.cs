using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UICustomize : MonoBehaviour {
    [SerializeField]
    private BodyCustomize body;
    [SerializeField]
    private Button customizeBtn, finishBtn, cancelBtn;
    [SerializeField]
    private GameObject panelCustomization;
    [SerializeField]
    private Slider hairSlide, skinSlider;
    [SerializeField]
    private CameraController cameraController;
    [SerializeField]
    private Transform cameraStateFull ,cameraStateBody, cameraStateHair;
    void Awake()
    {
        try
        {
            CheckFields();
        }catch(System.ArgumentNullException e)
        {
            Debug.LogError(e);
            Destroy(gameObject);
            return;
        }
        panelCustomization.SetActive(false);
        InitEvents();
    }
    void CheckFields()
    {
        if (body == null)
            throw new System.ArgumentNullException("Please, assign object in 'body' field");
        if(customizeBtn == null)
            throw new System.ArgumentNullException("Please, assign a button in 'customizeBtn' field");
        if(finishBtn == null)
            throw new System.ArgumentNullException("Please, assign a button in 'finishBtn' field");
        if (cancelBtn == null)
            throw new System.ArgumentNullException("Please, assign a button in 'cancelBtn' field");
        if (panelCustomization == null)
            throw new System.ArgumentNullException("Please, assign a object in 'panelCustomization' field");
        if (hairSlide == null)
            throw new System.ArgumentNullException("Please, assign a slide in 'hairSlide' field");
        if (skinSlider == null)
            throw new System.ArgumentNullException("Please, assign a slide in 'skinSlide' field");

    }
    void InitEvents()
    {
        cameraController.Follow(cameraStateFull.position);
        cameraController.LookAt(cameraStateFull.rotation);

        customizeBtn.onClick.AddListener(() =>
        {
            panelCustomization.SetActive(!panelCustomization.activeInHierarchy);

            cameraController.Follow(cameraStateBody.position);
            cameraController.LookAt(cameraStateBody.rotation);
        });
        hairSlide.onValueChanged.AddListener((float val) =>
        {
            body.TryHair((int)val);

            cameraController.Follow(cameraStateHair.position);
            cameraController.LookAt(cameraStateHair.rotation);
        });
        skinSlider.onValueChanged.AddListener((float val) =>{
            body.TrySkin((int)val);

            cameraController.Follow(cameraStateBody.position);
            cameraController.LookAt(cameraStateBody.rotation);
        });
    }
}
