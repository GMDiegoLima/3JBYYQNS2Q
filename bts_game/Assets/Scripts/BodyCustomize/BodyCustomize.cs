using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyCustomize : MonoBehaviour {
    [SerializeField]
    private Renderer character_skin;
    [SerializeField]
    private GameObject hair_holder;
    [SerializeField]
    private Material[] skin_materials;

    [SerializeField]
    private int defaultSkin, defaultHair = 0;

    Renderer[] hair_presets;

    public int amountHair
    {
        get
        {
            if (hair_presets == null)
                return 0;
            return hair_presets.Length;
        }
    }
    public int amountSkin
    {
        get
        {
            if (skin_materials == null)
                return 0;
           return skin_materials.Length;
        }
    }

    private 
    void Awake()
    {
        if (character_skin == null)
        {
            Debug.LogError("Please, set Character Skin 'renderer' at field");
            Destroy(gameObject);
            return;
        }
        if (skin_materials[0] != null)
        {
          character_skin.material = skin_materials[0];
        }
        else
        {
            Debug.LogError("Please, assign material to skin_materials[0]");
        }
        hair_presets = hair_holder.GetComponentsInChildren<Renderer>();
    }
    public void TryHair(int number)
    {
        for(int i = 0; i < hair_presets.Length; i++)
        {
            hair_presets[i].enabled = false;
        }
        if(number < hair_presets.Length && number >= 0)
        {
            hair_presets[number].enabled = true;
        }
    }
    public void TrySkin(int number)
    {
       if(number < skin_materials.Length)
        {
            if (skin_materials[0] != null)
            {
                character_skin.material = skin_materials[number];
            }
            else
            {
                Debug.LogError(string.Format("Please, assign material to skin_materials[{0}]",number));
            }
        }
    }
}
