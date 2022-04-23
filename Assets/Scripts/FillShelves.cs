using System;
using UnityEngine;
using UnityEngine.UI;
using static Estanteria;

public class FillShelves : MonoBehaviour
    {

        public GameObject seleccionado;
        public GameObject estanteria1;
        public GameObject estanteria2;
        public Estanteria pEstanteria1;
        public Estanteria pEstanteria2;
        public InputField cantidad;
        
        int number;
        // Start is called before the first frame update
        void Start()
        {
            ListItems.listItems.list();
            number = NumberShelvesScript.numberShelves.number;
            if (NumberShelvesScript.numberShelves.estanteria[number-1].free)
            {
                pEstanteria1 = new Estanteria(5, 5);
                pEstanteria2 = new Estanteria(5, 5);
                Vector3 sum = new Vector3(0.3f, 0.0f, 0.0f);
           

                Vector3 cambioPos = new Vector3(-0.656f, 2.050f, -0.519f);

                for (int i = 0; i < pEstanteria1.rows; i++)
                    for (int j = 0; j < pEstanteria1.cols; j++)
                    {
                        pEstanteria1.estanteria[i, j].position = estanteria1.transform.position + sum * j + cambioPos;
                        pEstanteria1.estanteria[i, j].position.y -= i * 0.451f;
                    }

                for (int i = 0; i < pEstanteria2.rows; i++)
                    for (int j = 0; j < pEstanteria2.cols; j++)
                    {
                        pEstanteria2.estanteria[i, j].position = estanteria2.transform.position + sum * j + cambioPos;
                        pEstanteria2.estanteria[i, j].position.y -= i * 0.451f;

                    }
            }
            else
            {
                pEstanteria1 = NumberShelvesScript.numberShelves.estanteria[number-1];
                pEstanteria2 = NumberShelvesScript.numberShelves.estanteria[number];
                for(int i=0;i<pEstanteria1.rows;i++)
                    for(int j = 0; j < pEstanteria1.cols; j++)
                    {

                        if (!pEstanteria1.estanteria[i, j].free)
                        {
                            GameObject nuevo = Instantiate(Resources.Load( pEstanteria1.estanteria[i, j].seleccionado.Substring(0,12)), pEstanteria1.estanteria[i, j].position, Quaternion.identity) as GameObject;
                            nuevo.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                            nuevo.transform.rotation = Quaternion.Euler(0, 90, 0);
                            nuevo.AddComponent<SelectProduct>();
                            nuevo.GetComponent<SelectProduct>().estanteria = number - 1;
                            nuevo.GetComponent<SelectProduct>().i = i;
                            nuevo.GetComponent<SelectProduct>().j = j;
                            nuevo.GetComponent<SelectProduct>().inShelves = true;
                            nuevo.GetComponent<SelectProduct>().fillShelves = this;
                            nuevo.AddComponent<MeshCollider>();

                        }
                    }
                for (int i = 0; i < pEstanteria2.rows; i++)
                    for (int j = 0; j < pEstanteria2.cols; j++)
                    {

                        if (!pEstanteria2.estanteria[i, j].free)
                        {
                            GameObject nuevo = Instantiate(Resources.Load(pEstanteria2.estanteria[i, j].seleccionado), pEstanteria2.estanteria[i, j].position, Quaternion.identity) as GameObject;
                            nuevo.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                            nuevo.transform.rotation = Quaternion.Euler(0, 90, 0);
                            nuevo.AddComponent<SelectProduct>();
                            nuevo.GetComponent<SelectProduct>().estanteria = number;
                            nuevo.GetComponent<SelectProduct>().i = i;
                            nuevo.GetComponent<SelectProduct>().j = j;
                            nuevo.GetComponent<SelectProduct>().inShelves = true;
                            nuevo.GetComponent<SelectProduct>().fillShelves = this;
                            nuevo.AddComponent<MeshCollider>();

                        }
                    }


                // GameObject nuevo = Instantiate(seleccionado, nuevaPos.position, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {
       
    }

        public void agregar()
        {
            Position nuevaPos;
            int estanteria;
            int pos_i, pos_j,cant;
            
            if (cantidad.text != "" && seleccionado!=null)
            {
                for (int i = 0; i < Int32.Parse(cantidad.text); i++)
                {
                    (nuevaPos,estanteria,pos_i,pos_j) = siguientePosicionLibre();
                    if (!nuevaPos.free)
                    {
                        GameObject nuevo = Instantiate(seleccionado, nuevaPos.position, Quaternion.identity);
                        nuevo.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        nuevo.transform.rotation = Quaternion.Euler(0, 90, 0);
                        nuevaPos.seleccionado = seleccionado.name;
                        nuevo.GetComponent<SelectProduct>().inShelves=true;
                        nuevo.GetComponent<SelectProduct>().estanteria = estanteria;
                        nuevo.GetComponent<SelectProduct>().i = pos_i;
                        nuevo.GetComponent<SelectProduct>().j = pos_j;

                }
                    else
                    {
                    
                        break;
                    }
                }
            }
        Debug.Log("seleccionado.name: " + seleccionado.name.Substring(0, 12));
        if (!ListItems.listItems.selected.ContainsKey(seleccionado.name.Substring(0,12)))
            ListItems.listItems.selected.Add(seleccionado.name.Substring(0, 12), Int32.Parse(cantidad.text));
        else
        {
            ListItems.listItems.selected.TryGetValue(seleccionado.name.Substring(0, 12), out cant);
          
            ListItems.listItems.selected.Remove(seleccionado.name.Substring(0, 12));
            ListItems.listItems.selected.Add(seleccionado.name.Substring(0, 12), cant + Int32.Parse(cantidad.text));
        }
        ListItems.listItems.selected.TryGetValue(seleccionado.name.Substring(0, 12), out cant);
        Debug.Log("Cantidad: " + cant);
        Guardar();
        }

        (Position,int,int) posicionLibreEstanteria(Estanteria estanteria)
        {

            for (int i = 0; i < estanteria.rows; i++)
                for (int j = 0; j < estanteria.cols; j++)
                {
                    if (estanteria.estanteria[i, j].free)
                    {
                        estanteria.estanteria[i, j].free = false;
                        
                        return (estanteria.estanteria[i, j],i,j);
                    }
                }

            return (new Position(),0,0);
        }

        (Position,int,int,int) siguientePosicionLibre()
        {
            int pos_i;
            int pos_j;
            Position libre;
            (libre,pos_i,pos_j) = posicionLibreEstanteria(pEstanteria1);
            int estanteria = number-1;
            if (libre.free)
            {
                (libre, pos_i, pos_j) = posicionLibreEstanteria(pEstanteria2);
                estanteria = number;
        }

            return (libre, estanteria, pos_i,pos_j);


        }

        public void Guardar()
        {
        NumberShelvesScript.numberShelves.estanteria[number-1] = pEstanteria1;
        NumberShelvesScript.numberShelves.estanteria[number-1].free = false;
        NumberShelvesScript.numberShelves.estanteria[number] = pEstanteria2;
        NumberShelvesScript.numberShelves.estanteria[number].free = false;

       
    }
    }

