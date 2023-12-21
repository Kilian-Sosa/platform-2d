using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayGame : MonoBehaviour {
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SCManager.instance.LoadScene("Game");
    }
}
