using UnityEngine;
using UnityEngine.SceneManagement;

public class SCManager : MonoBehaviour {
    public static SCManager instance;

    private void Awake() {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        DontDestroyOnLoad(gameObject);

    }

    // Método para cargar una nueva escena por nombre
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

}