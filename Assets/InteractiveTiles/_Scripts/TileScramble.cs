using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileScramble : MonoBehaviour
{
    
    public Material[] material;
    private int randInt;

    bool toggle = false;

    void Start()
    {
        randInt = Random.Range(0, 2);
        GetComponent<Renderer>().material = material[randInt];
    }

    private void Update()
    {
        if (GetComponent<Renderer>().material.name == "TileYellow (Instance)" && toggle)
        {
            TileBehavior.TotalComplete -= 1;
            TileBehavior.text.SetText("Tiles: " + TileBehavior.TotalTiles + " \n Complete: " + TileBehavior.TotalComplete);
            toggle = false;
        }
        if (GetComponent<Renderer>().material.name == "TileRed (Instance)" && !toggle)
        {
            TileBehavior.TotalComplete += 1;
            TileBehavior.text.SetText("Tiles: " + TileBehavior.TotalTiles + " \n Complete: " + TileBehavior.TotalComplete);
            toggle = true;
        }
    }
}
