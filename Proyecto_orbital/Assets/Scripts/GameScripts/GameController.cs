using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject showCoin;

    [SerializeField] ScoreController scoreController;
    public int totalCoins;
    private float score;
    public int orbitNumber;
    private int playerScoreToPrint;

    // Estado del juego
    public bool isGameActive;

    private void Awake()
    {
        totalCoins = 0;
        score = 0f;
        instance = this;
        scoreController = new ScoreController();
        isGameActive = true;
        
    }
    private void Update()
    {
        score += Time.deltaTime;

    }
    /// <summary>
    /// M�todo que devuelve al jugador a la pantalla de Men�.
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
    /// <summary>
    /// M�todo que abre o cierra el panel de Pausa y adecua el tiempo a pausado o activo.
    /// </summary>
    /// <param name="state">Activar o desactivar pausa.</param>
    public void PauseGame(bool state)
    {
        pausePanel.SetActive(state);
        if (state) { Time.timeScale = 0; }
        else { Time.timeScale = 1; }
    }
    /// <summary>
    /// M�todo que se encarga de activar el panel de Game Over.
    /// </summary>
    public void GameOver()
    {
        if (orbitNumber <= 0)
        {
            CentralSphereMovement fadeOut = GameObject.FindGameObjectWithTag("Player").GetComponent<CentralSphereMovement>();
            fadeOut.FadeOutEffect();
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            isGameActive = false;
            Debug.Log("Game Over");
        }       
    }
    /// <summary>
    /// M�todo que se encarga de ajustar los orbitales en funci�n del valor dado.
    /// </summary>
    /// <param name="add">Si se pasa el valor true se a�aden orbitales. False, se restan y se comprueba que no se haya acabado
    /// total de orbitales disponibles.</param>
    public void AddOrbit(bool add)
    {
        if (add) { orbitNumber++; }
        else { orbitNumber--; GameOver(); }
    }
    /// <summary>
    /// M�todo que se encarga de a�adir un n�mero de monedas determinado a la variable en cuesti�n.
    /// </summary>
    /// <param name="value">El valor dado por el que llama al m�todo que actualiza la variable de las
    /// monedas y el texto de las mismas.</param>
    public void AddCoins(int value)
    {
        totalCoins += value;
        coinText.text = "Coins: " + totalCoins;
        StartCoroutine(ShowTotalCoins());
    }
    /// <summary>
    /// Corrutina que activa 1 segundo el texto de las monedas y luego lo vuelve a ocultar.
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowTotalCoins()
    {
        showCoin.SetActive(true);
        yield return new WaitForSeconds(1f);
        showCoin.SetActive(false);
    }

}
