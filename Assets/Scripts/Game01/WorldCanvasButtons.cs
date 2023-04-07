using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasButtons : MonoBehaviour
{
    public void StartNewGame()
    {
        GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();
    }
}
