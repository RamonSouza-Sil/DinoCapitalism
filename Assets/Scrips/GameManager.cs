using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public Instancias instancias;
    public Meteoro MeteoroScript; // script meteoro

    public Button meteoro;
    public Button iniciar;
    public Button unpause;
    public UnityEngine.UI.Text text_cair;
    public TMP_Text moedaText;
    public TMP_Text carneText;
    public TMP_Text frutaText;
    public TMP_Text moedaMultiText;
    public TMP_Text frutaMultiText;
    public TMP_Text carneMultiText;

    

    public float Clicks;
    public float qtdMoeda; // quantidade atual de moeda que o jgador tem
    public float Carnes;
    public float Frutas;
    
    //public float ganhoPorClick = 1; // quantidade de moedas que o jogador recebe por clique


    public float tempoDecorrido; // tempo se passado no jogo em segundos
    public float tempoUltimaAtt;

    private bool jogoIniciado = false;
    void Start()
    {
        tempoUltimaAtt = Time.time; // Se inicia a contagem do tempo
        unpause.gameObject.SetActive(true); 
        meteoro.interactable = false;

    }
    void Update()
    {
        if (!jogoIniciado) return; // se o jogo não iniciar nao faz nada

        float tempoAtual = Time.time; // tempo atualizado
        tempoDecorrido = tempoAtual - tempoUltimaAtt; // tempo que se passou

        // verifica se passou 1 segundo
        if (tempoDecorrido >= 1f)
        {
            MeteoroScript.AumentarMeteoro();
            Carnes = instancias.qtdCarnes;
            Frutas = instancias.qtdFrutas;
            TranscreverValores();
            ContarMoedas();
        }



    }

    public void IniciarJogo()
    {
        jogoIniciado = true;
        unpause.gameObject.SetActive(false);
        meteoro.interactable = true;
        tempoUltimaAtt = Time.time;
        text_cair.gameObject.SetActive(true);
        Destroy(text_cair.gameObject, 2f);
    }
    public void ContarMoedas()
    {
        Clicks = MeteoroScript.qtdClicks;
        qtdMoeda = Clicks * instancias.multMoeda;
    }
    public string FormatarNumero(double valor)
    {
        if (valor >= 1e12)
            return (valor / 1e12).ToString("F2") + "T";
        if (valor >= 1e9)
            return (valor / 1e9).ToString("F2") + "B";
        if (valor >= 1e6)
            return (valor / 1e6).ToString("F2") + "M";
        return valor.ToString("F0");
    }
    public void TranscreverValores()
    {

        if (instancias == null)
        {
            Debug.LogError("Instancias está nulo no GameManager!");
            return;
        }


        //valores contabilizados
        //moedaText.text = qtdMoeda.ToString("F0");
        moedaText.text = FormatarNumero(qtdMoeda);
        carneText.text = FormatarNumero(Carnes);
        frutaText.text = FormatarNumero(Frutas);

        // multiplicadores contabilizados
        //moedaMultiText.text = instancias.multMoeda.ToString("F0");
        moedaMultiText.text = FormatarNumero(instancias.multMoeda);
        frutaMultiText.text = FormatarNumero(instancias.multFruta);
        carneMultiText.text = FormatarNumero(instancias.multCarne);


    }

   
    
}