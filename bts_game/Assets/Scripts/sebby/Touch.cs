using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

    private TouchControll.SWIPE_DIRECTION m_enCurrentDirection;
    public Player player;

    // Use this for initialization
    void Start () {

        GameObject.Find("SwipeControl").GetComponent<TouchControll>().SetMethodToCall(MyCallbackMethod);
        player = player.GetComponent<Player>() as Player;


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void MyCallbackMethod(TouchControll.SWIPE_DIRECTION iDirection)
    {

        m_enCurrentDirection = iDirection;

    
     

        switch (iDirection)
        {
            case TouchControll.SWIPE_DIRECTION.SD_UP:
                player.forcaPulo = 900;
                player.Pular();
               
                break;
            case TouchControll.SWIPE_DIRECTION.SD_DOWN:
                player.forcaPulo = 700;
                player.Pular();

                break;
            case TouchControll.SWIPE_DIRECTION.SD_LEFT:
                player.forcaPulo = 600;
                player.Pular();

                break;
            case TouchControll.SWIPE_DIRECTION.SD_RIGHT:
                player.forcaPulo = 500;
                player.Pular();

                break;
           
            case TouchControll.SWIPE_DIRECTION.SD_TOUCH:
                Debug.Log("Tocou na tela");
                break;
        }
    }
}
