using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager main;

    [Header("References")]
    //[SerializeField] private GameObject[] towerPrefabs; OLD
    [SerializeField] private Tower[] towers;

    private int selectedTower = 0;

    private void Awake () {
        main = this;
    }

    public Tower GetSelectedTower() {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) {
        selectedTower = _selectedTower;
    }
}