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
    
    public Button meteoro;
    public Button iniciar;
    public Button unpause;
    public UnityEngine.UI.Text text_cair;
    public GameObject[] frutas;
    public GameObject[] carnes;
    public Transform spawnFrutasCarnes;
    public TMP_Text moedaText;
    public TMP_Text carneText;
    public TMP_Text frutaText;



    public float qtdMoeda = 0; // quantidade atual de moeda que o jgador tem
    public float qtdCarnes = 0; // quantidade atual de carnes que o jogador tem
    public float qtdFrutas = 0; // quantidade atual de frutas que o jogador tem
    public float qtdClicks = 0;

    public float ganhoPorSegundo = 1; // quantidade de moedas que o jogador recebe por segundo
    public float multCarne = 1; // multiplicador de ganhos de carnes
    public float multFruta = 1; // multiplicador de ganhos de frutas

    public float tempoDecorrido; // tempo se passado no jogo em segundos
    public float tempoUltimaAtt;

    private float tamMeteoroMin = 0.9f;
    private Vector3 escalaMaxMeteoro = new Vector3(6.5f, 6.5f, 6.5f);

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
            AumentarMeteoro();
        }
    }

    
    
    // função principal para o click do meteoro
    public void ClickMeteoro() 
    {

        if (meteoro.onClick != null) // se clicou 
        {
            qtdMoeda += ganhoPorSegundo;
            qtdClicks++;
            if(meteoro.transform.localScale.x > tamMeteoroMin)
            {
                meteoro.transform.localScale *= 0.9f;
            }
            
        }

        // cria as frutas
        InstanciarFrutas();
        // Contabiliza os valores
        ContarValores();

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

    public void InstanciarFrutas()
    {
        float forcaPulo = 5; // forca que a fruta dá quando instanciada
        float destruir = 2f; // tempo que a fruta fica em tela antes de sumir

        // verificação
        if (frutas.Length == 0 && carnes.Length == 0) // verifica se os arrays de frutas e carnes estão vazios
        {
            Debug.LogError("Arrays de carnes e frutas vazios");
            return;
        }

        // gera um número entre 0 e 100
        int sorte = UnityEngine.Random.Range(0, 100); 
        Debug.Log("Sorte: " + sorte);

        // gerador de carnes
        if (sorte >= 94) // Instancia carnes se o numero gerado estiver entre 15 e 30
        {
            if (carnes.Length > 0)
            {
                int indexCarne = UnityEngine.Random.Range(0, carnes.Length); // Garante que o índice da carne seja válido
                GameObject CarneEscolhida = carnes[indexCarne];
                GameObject instancia = Instantiate(CarneEscolhida, spawnFrutasCarnes.position, Quaternion.identity); // instancia a carne na cena
                qtdCarnes += multCarne; //adiciona à variavel + a soma do multiplicador
                Rigidbody2D rb = instancia.GetComponent<Rigidbody2D>(); 
                if (rb != null)
                {
                    Vector2 direcao = new Vector2(UnityEngine.Random.Range(-1f, 1f), 1).normalized; // Direção aleatória
                    rb.AddForce(direcao * forcaPulo, ForceMode2D.Impulse); // adiciona impulso quando criado
                    Destroy(instancia, destruir); // Destroi a instância
                }
            }
        }

        //gerador de frutas
        else if (sorte ==  5 || sorte == 98 || sorte == 0 || sorte == 1 || sorte == 100) // Instancia frutas
        {
            if (frutas.Length > 0)
            {
                int indexFruta = UnityEngine.Random.Range(0, frutas.Length); 
                GameObject FrutaEscolhida = frutas[indexFruta];
                GameObject instancia = Instantiate(FrutaEscolhida, spawnFrutasCarnes.position, Quaternion.identity);
                qtdFrutas += multFruta;
                Rigidbody2D rb = instancia.GetComponent<Rigidbody2D>(); 
                if (rb != null)
                {
                    Vector2 direcao = new Vector2(UnityEngine.Random.Range(-1f, 1f), 1).normalized; 
                    rb.AddForce(direcao * forcaPulo, ForceMode2D.Impulse);
                    Destroy(instancia, destruir); 
                }
            }
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

    public void ContarValores()
    {
        moedaText.text = qtdMoeda.ToString("F0");
        carneText.text = qtdCarnes.ToString("F0");
        frutaText.text = qtdFrutas.ToString("F0");
    }
    
}