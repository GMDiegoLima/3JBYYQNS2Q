using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    private bool estaNoChao;
    public Transform chaoVerificador;
    public LayerMask piso;
    public bool puloDuplo;
    private Transform posicaoAtual;

    // resoinsavel pra saber o valor da horizontal
    static public float h = 0;

   
    static public bool hud = false;


    //Tudo que ocorre quando o personagem e criado
    void Start()
    {
        puloDuplo = false;

    }

    void Update()
    {
      
       // h = Input.GetAxis("Horizontal");
    
        ManageMovement(h);


    }

    // Responsável por movimentar o personagem, ela recebe os valores do H e do V 

   public void ManageMovement(float horizontal)
    {


        // verifica se ele tá no chão criando uma esfera usando o ponto de referencia que é o chãoVerificador e ver se tá tocando em alguma layer chamada Piso
        // E retorna o valor verdadeiro ou falso, se verdadeiro ele tá no chão e passa o Bool pro animator que ele tá no chão pra mostrar a animação Idle

        estaNoChao = Physics.CheckSphere(chaoVerificador.position, 0.2f, piso);
        if (estaNoChao)
        {
            puloDuplo = true;
        }
        if (!estaNoChao)
        {
            hud = true;
        }

        if (horizontal == 0)
        {
            hud = false;
        }
        


        // Se o valor for diferente de 0 na horizontal ele tá se movendo, então passo pro animator o valor da Horizontal, só que positivo
        if (horizontal != 0f)
        {

            hud = true;

            Vector3 movement = new Vector3(horizontal, 0, 0);

            // Se horizontal for menor que zero então ele se moveu pra Esquerda 
            if (horizontal < 0)
            {


              
                      transform.Translate(-movement * velocidade * Time.deltaTime);
                      transform.eulerAngles = new Vector2(0, 180);
             
         
                Debug.Log("Horizontal < 0");
            }
            // Se for maior que Zero ele tá pra direita
            if (horizontal > 0)
            {

                 transform.Translate(movement * velocidade * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);

                Debug.Log("Horizontal > 0");


            }

        }

     
     

    }


    public void Pular()
    {
        if (estaNoChao)
        {
            puloDuplo = true;
            GetComponent<Rigidbody>().AddForce(transform.up * forcaPulo, ForceMode.Impulse);
          //  posicaoAtual.position = transform.position;
            hud = true;
          

        }
     


    }

    public void PuloDuplo()
    {
        if (puloDuplo && !estaNoChao)
        {
              GetComponent<Rigidbody>().AddForce(transform.up * forcaPulo*1.5f, ForceMode.Impulse);
           
            puloDuplo = false;
        }
    }

}

