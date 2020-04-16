using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Player playerRef;

    [SerializeField]
    private Image[] lifeImages;

    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private Button restartBtn;

    [SerializeField]
    private float tickRate = 0.2F;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        ToggleRestartButton(false);

        playerRef = FindObjectOfType<Player>();

        if (playerRef != null && lifeImages.Length == Player.PLAYER_LIVES)
        {
            InvokeRepeating("UpdateUI", 0F, tickRate);
        }
    }
    private void ToggleRestartButton(bool val)
    {
        if (restartBtn != null)
        {
            restartBtn.gameObject.SetActive(val);
        }
    }
    public void UpdateVida()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (lifeImages[i] != null && lifeImages[i].enabled)
            {
                lifeImages[i].gameObject.SetActive(playerRef.Lives >= i + 1);
            }
        }
    }
    public void UpdateScore()
    {
        if (scoreLabel != null)
        {
            scoreLabel.text = playerRef.Score.ToString();
        }
    }
    public void Reload()
    {
        if (playerRef.Lives <= 0)
        {
            CancelInvoke();

            if (scoreLabel != null)
            {
                scoreLabel.text = "Game Over";
            }

            ToggleRestartButton(true);
        }
    }
}