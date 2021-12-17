using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa1 : MonoBehaviour
{
    //Array que contendrá todas las Torreta1
    GameObject[] torretas;

    // Start is called before the first frame update
    void Start()
    {
        //En el array metemos las torretas que tengan el tag
        torretas = GameObject.FindGameObjectsWithTag("Torreta1");
        print(torretas.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Robot toca la trampa
    private void OnTriggerEnter2D(Collider2D other)
    {

        print("Colision");
        if (other.gameObject.name == "Robot")
        {
            //Activar torretas
            foreach (GameObject torreta in torretas)
            {
                torreta.SendMessage("Activar");
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Robot")
        {
            foreach (GameObject torreta in torretas)
            {
                torreta.SendMessage("Desactivar");
            }
        }

    }
}
