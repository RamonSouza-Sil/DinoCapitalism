using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameConst : MonoBehaviour
{
    //GAME OBJECTS
    public Button meteoro;
    public Button iniciar;
    public Button unpause;
    public UnityEngine.UI.Text text_cair;
    public GameObject[] frutas;
    public GameObject[] carnes;
    public Transform spawnFrutasCarnes; 
}
