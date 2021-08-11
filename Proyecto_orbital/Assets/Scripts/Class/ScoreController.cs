using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController 
{
    public static int pointsToAddCloseWall;
    private static int poinsToAddNotTouching;
    public static int playerScore;
    private int pointsCloseWall;
    private static int playerScore_print;

    /// <summary>
    /// Cuando el orbital pasa muy cerca de un muro
    /// </summary>
    public static void PointsWhenOrbitClosetoWall(int scoretoAdd)
    {
        pointsToAddCloseWall = +scoretoAdd;
    }

    /// <summary>
    /// Por distancia recorrida
    /// </summary>
    public static void PointsTraveledDistance (float distanceScore)
    {

        playerScore = (int) Mathf.Round(distanceScore);
    }

    /// <summary>
    /// Tras pasar 5 segundos sin tocar la pantalla
    /// </summary>
    public static void PointsNotTouchingScreen (int scoretoAdd)
    {
        poinsToAddNotTouching = +scoretoAdd;
    }

    /// <summary>
    /// Tras pasar 1 minuto sin recibir ningún golpe
    /// </summary>
    void PointsSpendTimeNotHit ()
    {

    }

    /// <summary>
    /// Recoge todo el valor de puntos para sumar y manda el valor a imprimir en pantalla score
    /// </summary>
    /// <returns></returns>
    public static int ScoreToPrint()
    {
        playerScore_print = playerScore + pointsToAddCloseWall + poinsToAddNotTouching;
        return playerScore_print;
    }
}
