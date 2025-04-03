using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator anim;
    public GameManager manager;
    public Button meteoro;
    public Button Starter;
    public Vector3 escalaMaxMeteoro = new Vector3(6.5f, 6.5f, 6.5f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "JOGO")
        {
            if (meteoro.transform.localScale.x >= escalaMaxMeteoro.x && meteoro.transform.localScale.y >= escalaMaxMeteoro.y
                        && meteoro.transform.localScale.z >= escalaMaxMeteoro.z)
            {
                StartCoroutine(LoadSceneFIM());
            }
        }
        else
        {
            Debug.Log("Não tem meteoro");

        }
        
    }

    public void StartGame()
    {
        if (SceneManager.GetActiveScene().name == "MENU")
        {
            if (Starter.onClick != null)
            {
                StartCoroutine(LoadSceneJOGO());
            }
        }
    }

    private IEnumerator LoadSceneFIM()
    {
        

        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("FIM DE JOGO");
    }
    private IEnumerator LoadSceneJOGO()
    {
        yield return null;

        anim.SetTrigger("Fade");

        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("JOGO");
    }


    
}
