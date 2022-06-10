using System;
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
    public GameObject estanteria17;
    public GameObject estanteria18;
    public GameObject estanteria19;
    public GameObject estanteria20;
    public GameObject estanteria21;
    // Start is called before the first frame update

    public static PrepareShelves prepareShelves;

    void Awake()
    {
        if (prepareShelves == null)
        {
            prepareShelves = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (prepareShelves != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void cargar()
    {
        Vector3 sum = new Vector3(0.0f, 0.0f, 0.3f);

        GameObject[] estanterias = {estanteria1,estanteria2, estanteria3, estanteria4, estanteria5, estanteria6,
        estanteria7,estanteria8,estanteria9,estanteria10,estanteria11,estanteria12,estanteria13,estanteria14,
        estanteria15,estanteria16,estanteria17,estanteria18,estanteria19,estanteria20,estanteria21};
        Vector3 cambioPos = new Vector3(0.535f, 2.054f, -0.650f);
        Vector3 cambioPos2 = new Vector3(-0.535f, 2.054f, 0.650f);
        Vector3 cambioAltura = new Vector3(0.0f, 0.451f, 0.0f);
        for (int k = 0; k < estanterias.Length; k++)
        {
            Estanteria pEstanteria1 = NumberShelvesScript.numberShelves.estanteria[k];

            for (int i = 0; i < pEstanteria1.rows; i++)
                for (int j = 0; j < pEstanteria1.cols; j++)
                {
                    if (!pEstanteria1.estanteria[i, j].free)
                    {
                        string[] seleccionado = pEstanteria1.estanteria[i, j].seleccionado.Split('-');
                        int cantidad = 1;
                        if (seleccionado.Length != 1)
                            cantidad = Int32.Parse(seleccionado[1]);
                        instanciar(seleccionado[0], k, estanterias, j, i,cantidad);

                    }
                }
        }
    }


    private void instanciar(string producto, int estanteria, GameObject[] estanterias, int col, int row,int cant)
    {
        Vector3 sum = new Vector3(0.0f, 0.0f, 0.3f);
        Vector3 sum_2 = new Vector3(1f/cant, 0.0f, 0.0f);
        Vector3 cambioPos = new Vector3(0.800f, 2.054f, -0.750f);
        Vector3 cambioPos2 = new Vector3(-0.800f, 2.054f, 0.750f);
        Vector3 cambioAltura = new Vector3(0.0f, 0.451f, 0.0f);

        Vector2 pivot = (Resources.Load(producto) as GameObject).GetComponent<RectTransform>().pivot;
        float nuevaX;
        float nuevaZ;


        for (int i = 1; i <= cant; i++)
        {
            GameObject nuevo = Instantiate(Resources.Load(producto), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

              nuevo.transform.rotation = (Resources.Load(producto) as GameObject).transform.rotation;
            //nuevo.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            if (estanteria >= 0 && estanteria <= 11)
            {
                nuevo.transform.position = estanterias[estanteria].transform.position - (i-1) * sum_2 + sum * col + cambioPos;
                nuevaX = nuevo.transform.position.x + pivot.y;
                nuevaZ = nuevo.transform.position.z + pivot.x;
            }
            else
            {
                nuevo.transform.position = estanterias[estanteria].transform.position + (i-1) * sum_2 - sum * col + cambioPos2;
                nuevaX = nuevo.transform.position.x - pivot.y;
                nuevaZ = nuevo.transform.position.z - pivot.x;
                Vector3 newRotation = new Vector3(nuevo.transform.eulerAngles.x,180 , 0);
                nuevo.transform.eulerAngles = newRotation;
            }
            nuevo.transform.position = nuevo.transform.position - row * cambioAltura;
            nuevo.transform.position = new Vector3(nuevaX, nuevo.transform.position.y, nuevaZ);

            nuevo.AddComponent<PlayerGrab>();
            nuevo.GetComponent<PlayerGrab>().carrito = GameObject.Find("carrito_seleccionados");
            nuevo.GetComponent<PlayerGrab>().myHands = GameObject.Find("Hands");
            nuevo.GetComponent<PlayerGrab>().enabled = false;
            nuevo.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((eventData) => { nuevo.GetComponent<PlayerGrab>().enabled = true; });
            nuevo.GetComponent<EventTrigger>().triggers.Add(entry);


            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener((data) => { nuevo.GetComponent<PlayerGrab>().enabled = false; });
            nuevo.GetComponent<EventTrigger>().triggers.Add(entry2);


            nuevo.AddComponent<Rigidbody>();
            nuevo.GetComponent<Rigidbody>().useGravity = true;
            nuevo.GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}
