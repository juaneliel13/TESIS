using UnityEngine;
using System.Linq;
using System;
using static Estanteria;


public class ToRemember : MonoBehaviour
{
    public GameObject selected;
    public Position[,] selection;
    // Start is called before the first frame update
    public static ToRemember toRemember;


    void Awake()
    {
        if (toRemember == null)
        {
            toRemember = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (toRemember != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
      //  ListItems.listItems.list();
           selection = new Position[4, 5];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 5; j++) {
                selection[i, j] = new Position();
                selection[i, j].position = new Vector3(-4f + j*0.75f, 2.56f - i*1.5f, -0.528993f);
            }
      /*  string[] keys = ListItems.listItems.selected.Keys.ToArray();
        for (int i = 0; i < keys.Length; i++)
            keys[i] = keys[i].Substring(0, 12);*/
        Vector3 inicial = new Vector3(-5.81f, 2.56f, -0.5299931f);
        /* int k = 0;
         for (int i = 0; i < 3; i++)
             for (int j = 0; j < 4; j++)
             {
                 if (k < keys.Length)
                 {
                     GameObject nuevo = Instantiate(Resources.Load(keys[k]), new Vector3(inicial.x + j * 0.647f, inicial.y - i * 0.93f, inicial.z), Quaternion.identity) as GameObject;
                     nuevo.transform.localScale = new Vector3(2, 2, 2);
                     nuevo.transform.rotation = Quaternion.Euler(0, 90, 0);
                     nuevo.AddComponent<SelectItemToRemember>();
                     nuevo.AddComponent<MeshCollider>();
                     k++;
                 }
                 else
                     goto end;
             }
         end:;*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addItem(String item)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (selection[i, j].free)
                {
                    selection[i, j].seleccionado = selected.name;
                    GameObject nuevo = Instantiate(Resources.Load(item), selection[i, j].position, Quaternion.identity) as GameObject;
                    nuevo.transform.rotation = selected.transform.rotation;
                    nuevo.transform.localScale = new Vector3(3, 3, 3);
                 /*   nuevo.AddComponent<SelectItemToRemember>();
                    nuevo.GetComponent<SelectItemToRemember>().included = true;
                    nuevo.GetComponent<SelectItemToRemember>().i = i;
                    nuevo.GetComponent<SelectItemToRemember>().j = j;
                    nuevo.AddComponent<MeshCollider>();*/
                    nuevo.transform.SetParent(this.gameObject.transform);

                    selection[i, j].free = false;
                   
                    goto end_search;
                }

            }
        }
        end_search:;

    }

    public void ClearChildren()
    {
        /* int i = 0;

         //Array to hold all child obj
         GameObject[] allChildren = new GameObject[transform.childCount];

         //Find all child obj and store to that array
         foreach (Transform child in transform)
         {
             allChildren[i] = child.gameObject;
             i += 1;
         }

         //Now destroy them
         foreach (GameObject child in allChildren)
         {
             DestroyImmediate(child.gameObject);
         }
         for (int k = 0; k < 4; k++)
             for (int w = 0; w < 5; w++)
             {
                 selection[k, w].free = true;
             }
        */
        saveConfig();
    }

    public void saveConfig()
    {

        //string text = JsonHelper.ToJson(NumberShelvesScript.numberShelves.estanteria, true);
        
        string text = JsonUtility.ToJson(NumberShelvesScript.numberShelves.estanteria[0].estanteria[0,0]);
        string text2 = JsonUtility.ToJson(NumberShelvesScript.numberShelves.estanteria[0].estanteria[0, 1]);


      
      //  Debug.Log(text2);
    }

}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}