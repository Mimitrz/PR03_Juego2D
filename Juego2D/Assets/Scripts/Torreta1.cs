using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta1 : MonoBehaviour
{
    Animator animator;

    //Referencia para instanciar
    [SerializeField] Transform cannon;
    //Bala
    [SerializeField] GameObject bala;

    // Start is called before the first frame update
    void Start()
    {

     animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Activar()
    {
        animator.SetBool("Disparando", true);
    }

    public void Desactivar()
    {
        animator.SetBool("Disparando", false);
    }

    void Disparar()
    {
        //Instanciamos la bala en el canon
        Instantiate(bala, cannon);

    }
}
