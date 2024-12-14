using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;
    private bool isGamePaused = false;
    private bool fastForwardOn = false;

    public void ToggleMenu() {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }

    public void PauseGame() {
        if (!isGamePaused){
            isGamePaused = true;
            Time.timeScale = 0;
        } else {
            isGamePaused = false;
            Time.timeScale = 1;
        }
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

    private void OnGUI() {
        currencyUI.text = LevelManager.main.currency.ToString();
    }

    public void SetSelected() {

    }
}
