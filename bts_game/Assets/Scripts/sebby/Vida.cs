using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class Vida : MonoBehaviour {

    
    [Range(0, 200)]
    public float vidaCheia = 100;
    public Image barraDeVida;
    public float vidaAtual;


   
   

    // Use this for initialization
    void Start () {
        // ao iniciar defini ele com vida maxima logo
        vidaAtual = vidaCheia;

    }

    // Update is called once per frame
    void Update () {

        
       
        // faz comparação para ele não ter mais do que  vida cheia e não ficar com menos que 0 de vida
        if (vidaAtual >= vidaCheia)
        {
            vidaAtual = vidaCheia;

        }
        else if (vidaAtual <= 0)
        {
            vidaAtual = 0;
          


        }
    }
    // função pra diminuir a barra de vida
    public void Damage(float value)
    {
        vidaAtual -= value;
        barraDeVida.fillAmount = ((1 / vidaCheia) * vidaAtual);
       
 
    }

    // função pra aumentar a barra de vida
    public void Recupera(float value)
    {
        vidaAtual += value;
        barraDeVida.fillAmount = ((1 / vidaCheia) * vidaAtual);
      

    }
}
