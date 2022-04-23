using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectProduct : MonoBehaviour
{
    public FillShelves fillShelves;
    public bool inShelves;
    public int estanteria,i,j;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        int cant;
        if (!inShelves)
        {
            fillShelves.seleccionado = this.gameObject;
            Debug.LogFormat("seleccionaste {0}", this.gameObject);
           
        }
        else
        {
            NumberShelvesScript.numberShelves.estanteria[estanteria].estanteria[i, j].free = true;
            Debug.Log(NumberShelvesScript.numberShelves.estanteria[estanteria].estanteria[i, j].free);
            Debug.Log("el nombre es: "+fillShelves.seleccionado.name.Substring(0, 12));
            ListItems.listItems.selected.TryGetValue(fillShelves.seleccionado.name.Substring(0,12), out cant);
            ListItems.listItems.selected.Remove(fillShelves.seleccionado.name.Substring(0,12));
            Debug.LogWarning("hay "+ (cant-1));
            if(cant-1!=0)
                ListItems.listItems.selected.Add(fillShelves.seleccionado.name.Substring(0,12), cant-1);
            Destroy(this.gameObject);
        }

        
        
    }
}
