using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class LevelController 
{
    [Header("Variables que definirán la cantidad de muro en la escena")]
    private int numMovWalls;
    private int numIronWalls;
    private int numRotateWalls;
    private int numStaticWalls;
    private int numTapWall;
    
    [Header("Variables que definiran la cantidad de power ups en la escena")]
    private int numDestructionPUs;
    private int numFrostPUs;
    private int numGhostPUs;
    private int numMultiplePUs;
    private int numNearPUs;
    private int numSpeedPUs;

    [Header("Array valores de la moneda")]
    private int[] coinValues = { 1, 5, 15 };

}
