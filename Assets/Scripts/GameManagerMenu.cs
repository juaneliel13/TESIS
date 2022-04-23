using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaSimulacion(){
        SceneManager.LoadScene("PrimerSuper");
    }

    public void EscenaEditor(){
        SceneManager.LoadScene("Editor");
    }

    public void EscenaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EscenaSelector()
    {
        SceneManager.LoadScene("SelectorToRemember");
    }

    public void EditorGondola(int i)
    {
        NumberShelvesScript.numberShelves.number = i;
        SceneManager.LoadScene("editor_gondola");
    }
}
