using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCarrito : MonoBehaviour
{
    public GameObject carrito;
    public GameObject myHands;
    bool inHands = false;
    Vector3 carritoPos;
    Collider carritoCal;
    Rigidbody carritoRb;
    // Start is called before the first frame update
    void Start()
    {
        carritoPos = carrito.transform.position;
        carritoCal = carrito.GetComponent<SphereCollider>();
        carritoRb = carrito.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(!inHands){
                carritoCal.isTrigger=true;
                carritoRb.useGravity=false;
                carrito.transform.SetParent(myHands.transform);
                carrito.transform.localPosition = new Vector3(0.0f,-0.500f,0.0f);
                carrito.transform.rotation = new Quaternion(myHands.transform.rotation.x,myHands.transform.rotation.y+160.0f,myHands.transform.rotation.z,myHands.transform.rotation.w);
                inHands=true;
                
            }
            else{
                this.GetComponent<PlayerGrab>().enabled=false;
                carrito.transform.SetParent(null);
                carrito.transform.position=carritoPos;
                inHands=false;
                carritoCal.isTrigger=false;
                carritoRb.useGravity=true;
            }
        }
    }
}