using UnityEngine;

public class PlayGame : MonoBehaviour {

    private void Start()
    {
        AudioManager.instance.PlayMusic("MainTheme");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SCManager.instance.LoadScene("Lvl1");
    }
}
