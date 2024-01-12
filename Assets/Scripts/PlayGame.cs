using UnityEngine;

public class PlayGame : MonoBehaviour {
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SCManager.instance.LoadScene("Lvl1");
    }
}
