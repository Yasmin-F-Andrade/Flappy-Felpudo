using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public MonoBehaviour Felpudo;
    public GameObject GeradordeInimigos;
    public GameObject playButton;
    public GameObject gameOver;
    private TextMeshProUGUI textoPontuação;
    public GameObject Win;

    public int Score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        // Garante que o jogo começa pausado e mostrando apenas o botão de Play
        if (playButton != null) playButton.SetActive(true);
        if (gameOver != null) gameOver.SetActive(false);
        if (Win != null) Win.SetActive(false);

        Pause();
    }

    private void Update()
    {
        // Se estiver em Game Over, aperta Espaço para reiniciar
        if (gameOver != null && gameOver.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Reiniciar();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        if (Felpudo != null) Felpudo.enabled = false;

        // Se houver um gerador de inimigos comum, você pode pausá-lo aqui também se desejar
        if (GeradordeInimigos != null) GeradordeInimigos.SetActive(false);
    }

    // Este método deve ser ligado ao botão de Play na UI (OnClick)
    public void Play()
    {
        Score = 0;

        if (textoPontuação != null)
        {
            textoPontuação.text = Score.ToString();
            textoPontuação.gameObject.SetActive(true);
        }

        if (playButton != null) playButton.SetActive(false);
        if (gameOver != null) gameOver.SetActive(false);
        if (Win != null) Win.SetActive(false);

        Time.timeScale = 1f;
        if (Felpudo != null) Felpudo.enabled = true;
        if (GeradordeInimigos != null) GeradordeInimigos.SetActive(true);
    }

    public void GameOver()
    {
        if (playButton != null) playButton.SetActive(false);
        if (gameOver != null) gameOver.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        Score++;

        if (textoPontuação != null)
        {
            textoPontuação.text = Score.ToString();
            textoPontuação.gameObject.SetActive(true);
        }

    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VencerJogo()
    {

        if (Win != null)
        {
            Win.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}