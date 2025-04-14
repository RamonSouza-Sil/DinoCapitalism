using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public  class Base : MonoBehaviour
{
    public UpData dados;

    public GameManager gm;
    public Instancias instancias;

    public Button upgradeButton;

    public string desc;
    public float valorMoeda;
    public float valorCarne;
    public float valorFruta;

    protected virtual void Start()
    {
        instancias = FindObjectOfType<Instancias>();
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(TentarComprar);
        }
    }


    public void TentarComprar()
    {
        if (PodeComprar() == true)
        {
            AplicarUp();
            Destroy(upgradeButton.gameObject, 1f);
        }
        else
        {
            Debug.Log("Recurso Insuficiente");
        }
    }
    public bool PodeComprar()
    {
        Debug.Log($"Moedas: {gm.qtdMoeda}, Carnes: {gm.Carnes}, Frutas: {gm.Frutas}"); // Debugging
        if (gm.qtdMoeda >= dados.custoMoeda &&
               gm.Carnes >= dados.custoCarne &&
               gm.Frutas >= dados.custoFruta)
        {
            return true;
        }
        else
            return false;
        

        
    }
    protected virtual void AplicarUp()
    {
        
    }

}
