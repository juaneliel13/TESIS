using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    //public GameObject ball;
    public GameObject myHands;
    bool inHands = false;
    public Vector3 balPos;
    public GameObject carrito;
    // Start is called before the first frame update
    void Start()
    {
        balPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1")){
            if(!inHands){
               balPos = transform.position;
               // ball.transform.SetParent(myHands.transform);
               // ball.transform.localPosition = new Vector3(0f,-0.500f,0f);
               transform.localPosition = carrito.transform.position;
               inHands=true;
               // ball.SetActive(false);
               transform.SetParent(carrito.transform);
                Debug.Log(transform.name);
            }
            else{
                //this.GetComponent<PlayerGrab>().enabled=false;
                transform.SetParent(null);
                inHands=false;
                
                transform.position = balPos;
            }
        }
    }

   /* public void setBall(GameObject b){
        ball=b;
    }*/
}
