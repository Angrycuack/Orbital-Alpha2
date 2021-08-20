using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinText;
    
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject showCoin;

    [SerializeField] private Button pauseButton;

    [SerializeField] ScoreController scoreController;
    public int totalCoins;
    private float score;
    public int orbitNumber;
    private int playerScoreToPrint;
    public bool continueButton;

    private void Awake()
    {
        totalCoins = 0;
        score = 0f;
        continueButton = true;
        scoreController = new ScoreController();
        instance = this;

    }
    private void Update()
    {
        score += Time.deltaTime;

        //scoreText.text = "Score: " + score.ToString("F0");
        playerScoreToPrint = ScoreController.ScoreToPrint();
        scoreText.text = playerScoreToPrint.ToString();
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
            pauseButton.interactable = false;
            CentralSphereMovement fadeOut = GameObject.FindGameObjectWithTag("Player").GetComponent<CentralSphereMovement>();
            fadeOut.FadeOutEffect(false);
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }       
    }
    /// <summary>
    /// Este m�todo se encarga, en caso de que no se haya continuado previamente, dar la posibilidad de hacerlo. Restaura el orbital central, la velocidad,
    /// y espamea un nuevo orbital.
    /// </summary>
    public void ContinueGame()
    {
        if (continueButton)
        {
            gameOverPanel.SetActive(false);
            pauseButton.interactable = true;
            CentralSphereMovement fadeOut = GameObject.FindGameObjectWithTag("Player").GetComponent<CentralSphereMovement>();
            fadeOut.FadeOutEffect(true);
            Time.timeScale = 1;
            CentralSphereMovement newBall = GameObject.FindGameObjectWithTag("Player").GetComponent<CentralSphereMovement>();
            newBall.PowerUp("SimpleBall");
            continueButton = false;

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
