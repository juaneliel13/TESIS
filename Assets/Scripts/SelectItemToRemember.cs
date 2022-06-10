using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemToRemember : MonoBehaviour
{
    public bool included;
    public int i, j;

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
        
        if (!included)
        {
            ToRemember.toRemember.selected = this.gameObject;
            Debug.LogFormat("seleccionaste {0}", this.gameObject);
           // ToRemember.toRemember.addItem();
           
        }
        else
        {
            ToRemember.toRemember.selection[i, j].free = true;

            Destroy(this.gameObject);
            
        }
    }
}
