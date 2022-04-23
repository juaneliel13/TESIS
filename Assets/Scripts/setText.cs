using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int numero = (NumberShelvesScript.numberShelves.number + 1)/2;
        this.gameObject.GetComponent<Text>().text = numero.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
