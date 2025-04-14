using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompyUP : Base
{
    

    protected override void AplicarUp()
    {

        gm.qtdMoeda -= dados.custoMoeda; // Consome as moedas
        gm.Carnes -= dados.custoCarne; // Consome as carnes
        gm.Frutas -= dados.custoFruta; // Consome as frutas

        instancias.multCarne++;
        Debug.Log(" Adicionado +1 ao mult de carne, total: " + instancias.multCarne);
    }
}
