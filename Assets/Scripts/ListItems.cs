using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ListItems : MonoBehaviour
{

    const int CANTIDAD_ITEMS = 4;
    public string[] listNames;
    public Dictionary<string, int> selected;


    public static ListItems listItems;

    void Awake()
    {
        if (listItems == null)
        {
            listItems = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (listItems != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        listNames = new string[CANTIDAD_ITEMS];
        listNames[0] = "PREF_food_01";
        listNames[1] = "PREF_food_02";
        listNames[2] = "PREF_food_03";
        listNames[3] = "PREF_food_05";

       
        

        selected = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void list()
    {
        Vector3 inicial = new Vector3(-5.81f, 2.38f, -0.5299931f);
        int k = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
            {
                if (k < listNames.Length)
                {
                    GameObject nuevo = Instantiate(Resources.Load(listNames[k]), new Vector3(inicial.x + j * 0.647f, inicial.y - i * 0.93f, inicial.z), Quaternion.identity) as GameObject;
                    nuevo.transform.localScale = new Vector3(2, 2, 2);
                    nuevo.transform.rotation = Quaternion.Euler(0, 90, 0);
                    nuevo.AddComponent<SelectProduct>();
                    nuevo.GetComponent<SelectProduct>().fillShelves = GameObject.Find("FillShelves").GetComponent<FillShelves>();
                    nuevo.AddComponent<MeshCollider>();
                    k++;
                }
                else
                    goto end;
            }
        end:;
    }
}
