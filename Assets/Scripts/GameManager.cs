using UnityEngine;

public class GameManager : MonoBehaviour {
    public int level = 1;
    public static GameManager instance;

    void Start() {
        if (instance == null) instance = this;
    }

    void Update() {
        
    }

    public void ChangeLevel() {
        if (level != 3) SCManager.instance.LoadScene($"Lvl{++level}");
        else SCManager.instance.LoadScene("Victory");
    }
}
