using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudController : MonoBehaviour {



    public Image setaEsquerda;
    public Image setaDireita;
    public Image pocao;
    public Image pular;
    public Image livro;
    public Image configuracao;
    public Image invetario;
    public Image ataque;
    public Image life;

    public Sprite setaEsquerdaOn;
    public Sprite setaDireitaOn;
    public Sprite pocaoOn;
    public Sprite pularOn;
    public Sprite livroOn;
    public Sprite configuracaoOn;
    public Sprite invetarioOn;
    public Sprite ataqueOn;

    public Sprite setaEsquerdaOff;
    public Sprite setaDireitaOff;
    public Sprite pocaoOff;
    public Sprite pularOff;
    public Sprite livroOff;
    public Sprite configuracaoOff;
    public Sprite inventarioOff;
    public Sprite ataqueOff;


    // Use this for initialization
    void Start () {

     
      

    }
	
	// Update is called once per frame
	void Update () {
	
        if (Player.hud == false)
        {
      //      setaDireita.sprite = setaDireitaOff;
     //      setaEsquerda.sprite = setaEsquerdaOff;
      //      pocao.sprite = pocaoOff;
     //       pular.sprite = pularOff;
      //      livro.sprite = livroOff;
      //      configuracao.sprite = configuracaoOff;
     //       invetario.sprite = inventarioOff;
     //       ataque.sprite = ataqueOff;
            life.color = Color.white;



        }

        else
        {
    //        setaDireita.sprite = setaDireitaOn;
     //       setaEsquerda.sprite = setaEsquerdaOn;
      //      pocao.sprite = pocaoOn;
     //       pular.sprite = pularOn;
       //     livro.sprite = livroOn;
    //        configuracao.sprite = configuracaoOn;
      //      invetario.sprite = invetarioOn;
      //      ataque.sprite = ataqueOn;
            life.color = Color.clear;


        }

    }
}
