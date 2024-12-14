using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter() {
        if (Time.timeScale != 0){
        sr.color = hoverColor;
        }
    }

    private void OnMouseExit() {
        if (Time.timeScale != 0){
        sr.color = startColor;
        }
    }

    private void OnMouseDown() {
        if (tower != null) return;
            if (Time.timeScale != 0){
                Tower towerToBuild = BuildManager.main.GetSelectedTower();

                if (towerToBuild.cost > LevelManager.main.currency) {
                    Debug.Log("you cant afford this");
                    return;
                }

                LevelManager.main.SpendCurrency(towerToBuild.cost);

                tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        }
    }
}
