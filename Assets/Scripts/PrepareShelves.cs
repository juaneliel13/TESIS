using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PrepareShelves : MonoBehaviour
{
    public GameObject estanteria1;
    public GameObject estanteria2;
    public GameObject estanteria3;
    public GameObject estanteria4;
    public GameObject estanteria5;
    public GameObject estanteria6;
    public GameObject estanteria7;
    public GameObject estanteria8;
    public GameObject estanteria9;
    public GameObject estanteria10;
    public GameObject estanteria11;
    public GameObject estanteria12;
    public GameObject estanteria13;
    public GameObject estanteria14;
    public GameObject estanteria15;
    public GameObject estanteria16;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 sum = new Vector3(0.0f,0.0f , 0.3f);

        GameObject[] estanterias = {estanteria1,estanteria2, estanteria3, estanteria4, estanteria5, estanteria6,
        estanteria7,estanteria8,estanteria9,estanteria10,estanteria11,estanteria12,estanteria13,estanteria14,
        estanteria15,estanteria16};
        Vector3 cambioPos = new Vector3(0.535f, 2.054f, -0.650f);
        Vector3 cambioPos2 = new Vector3(-0.535f, 2.054f, 0.650f);
        Vector3 cambioAltura = new Vector3(0.0f, 0.451f, 0.0f);
        for (int k = 0; k < 16; k++)
        {
            Estanteria pEstanteria1 = NumberShelvesScript.numberShelves.estanteria[k];
            
            for (int i = 0; i < pEstanteria1.rows; i++)
                for (int j = 0; j < pEstanteria1.cols; j++)
                {
                    if (!pEstanteria1.estanteria[i, j].free)
                    {
                        GameObject nuevo = Instantiate(Resources.Load(pEstanteria1.estanteria[i, j].seleccionado.Substring(0,12)), new Vector3(0,0,0), Quaternion.identity) as GameObject;
                        nuevo.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        if ((k >= 0 && k <= 3) || (k >= 8 && k <= 11))
                        {
                            nuevo.transform.position = estanterias[k].transform.position + sum * j + cambioPos;  
                        }
                        else
                        {
                            nuevo.transform.position = estanterias[k].transform.position - sum * j + cambioPos2;
                       }
                        nuevo.transform.position = nuevo.transform.position - i * cambioAltura;
                        nuevo.AddComponent<PlayerGrab>();
                        nuevo.GetComponent<PlayerGrab>().carrito = GameObject.Find("carrito_seleccionados");
                        nuevo.GetComponent<PlayerGrab>().myHands = GameObject.Find("Hands");
                        nuevo.GetComponent<PlayerGrab>().enabled = false;
                        nuevo.AddComponent<EventTrigger>();

                        EventTrigger.Entry entry= new EventTrigger.Entry();
                        entry.eventID = EventTriggerType.PointerEnter;
                        entry.callback.AddListener((eventData) => { nuevo.GetComponent<PlayerGrab>().enabled = true; });
                        nuevo.GetComponent<EventTrigger>().triggers.Add(entry);
                        

                        EventTrigger.Entry entry2 = new EventTrigger.Entry();
                        entry2.eventID = EventTriggerType.PointerExit;
                        entry2.callback.AddListener((data) => { nuevo.GetComponent<PlayerGrab>().enabled = false; });
                        nuevo.GetComponent<EventTrigger>().triggers.Add(entry2);

                        nuevo.AddComponent<MeshCollider>();
                        nuevo.GetComponent<MeshCollider>().convex = true;
                        nuevo.GetComponent<MeshCollider>().isTrigger = true;
                    }
                }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
