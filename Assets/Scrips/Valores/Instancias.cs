using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancias : MonoBehaviour
{
    GameManager gameManager;

    public GameObject[] frutas;
    public GameObject[] carnes;
    public Transform spawnFrutasCarnes;

    public float qtdCarnes;
    public float qtdFrutas;
    public float multCarne = 1; // multiplicador de ganhos de carnes
    public float multFruta = 1; // multiplicador de ganhos de frutas
    public float multMoeda = 1; // multiplicador de ganhos de moedas


    public void Instanciador()
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
        else if (sorte == 5 || sorte == 98 || sorte == 0 || sorte == 1 || sorte == 100) // Instancia frutas
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
}
