using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberShelvesScript : MonoBehaviour
{
    public static NumberShelvesScript numberShelves;

    public int number;
    public Estanteria[] estanteria;
    // Start is called before the first frame update
    void Awake()
    {
        if (numberShelves == null)
        {
            numberShelves = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (numberShelves != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        estanteria = new Estanteria[21];
        for (int i = 0; i < estanteria.Length; i++)
            estanteria[i] = new Estanteria(5,5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

[Serializable]
public class Estanteria
{

    public Position[,] estanteria;
    public int rows;
    public int cols;
    public bool free;

    public Estanteria(int i,int j)
    {
        rows = i;
        cols = j;
        estanteria = new Position[i, j];
        for (int k = 0; k < i; k++)
            for (int n = 0; n < j; n++)
                estanteria[k, n] = new Position();
        free=true;
    }

    [Serializable]
    public class Position
    {
        public Vector3 position;
        public bool free;
        public String seleccionado;

        public Position()
        {
            position = new Vector3();
            free = true;
        }

    }
}
