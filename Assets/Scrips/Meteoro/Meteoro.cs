using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteoro : MonoBehaviour
{
    public Instancias instancias;
    public Button meteoro;


    public float qtdClicks;
    


    private float escalaMinMeteoro = 0.9f;
    private Vector3 escalaMaxMeteoro = new Vector3(6.5f, 6.5f, 6.5f);

    public void ClickMeteoro()
    {

        if (meteoro.onClick != null) // se clicou 
        {
            qtdClicks++;
            if (meteoro.transform.localScale.x > escalaMinMeteoro)
            {
                meteoro.transform.localScale *= 0.9f;
            }
            instancias.Instanciador();

        }
    }

    // função para aumentar a escala do meteoro
    public void AumentarMeteoro()
    {

        // aumenta a escala do meteoro(butão) em 10% por segundo
        Vector3 novaEscala = meteoro.transform.localScale * 1.2f;

        // aplica a nova escala
        meteoro.transform.localScale = Vector3.Lerp(meteoro.transform.localScale, novaEscala, Time.deltaTime * 1.2f);


    }
}
