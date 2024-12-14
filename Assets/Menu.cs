using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;
    private bool isGamePaused = false;
    private bool fastForwardOn = false;

    public GameObject pauseMenuUI;

    public void ToggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }

    public void PauseGame() {
        if (!isGamePaused){
            pauseMenuUI.SetActive(true);
            isGamePaused = true;
            Time.timeScale = 0;
        } 
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void FastForward() {
        if (!fastForwardOn){
            fastForwardOn = true;
            Time.timeScale = 2;
        } else {
            fastForwardOn = false;
            Time.timeScale = 1;
        }
    }

    public void JumpToMenu() {
        SceneManager.LoadScene(0);
        ResumeGame();
    }

    public void QuitGame()
    {
        Debug.Log("Game quit.");
        Application.Quit();
    }

    private void OnGUI() {
        currencyUI.text = LevelManager.main.currency.ToString();
    }

    public void SetSelected() {

    }
}
