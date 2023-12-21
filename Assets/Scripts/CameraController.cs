using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] float xMin, xMax;

    void Update() {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), 
            transform.position.y, transform.position.z);
    }
}