using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataforma : MonoBehaviour
{
  
    //Array que tendrá los mismos valores que el que hay en InitGame
    float[] speedArray;
    //La variable que determina la velocidad de movimiento
    float speed;
    //Clave del array, dependiendo de la plataforma en la que estoy
    //[0] -> Background / [1] -> Juego / [2] -> Foreground
    int clave;

    // Start is called before the first frame update
    void Start()
    {
        //Método que nos dará la clave del array que nos correponde
        ObtenerClave();
    }

    // Update is called once per frame
    void Update()
    {
        //Le asingamos la velocidad determinada en el array del script inicial
        speed = speedArray[clave];
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    void ObtenerClave()
    {
        //Obtenemos nuestro tag y en base a él la clave del array que le corresponde
        string myTag = gameObject.tag;
        //Según el tag de nuestro prefab
        if (myTag == "bg")
        {
            clave = 0;
        }
        else if (myTag == "game")
        {
            clave = 1;
        }
        else if (myTag == "fg")
        {
            clave = 2;
        }
        else //Siempre es bueno poner un valor por defecto
        {
            clave = 1;
        }
    }
}
