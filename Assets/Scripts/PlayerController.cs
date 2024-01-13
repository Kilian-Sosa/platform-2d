using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] ParticleSystem jumpParticles;
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    private bool isJumping = false;

    [SerializeField] float lineLength = 1f;
    [SerializeField] float offset = 1f;

    void Update() {
        float direction = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed * direction, GetComponent<Rigidbody2D>().velocity.y);

        if (direction == 1) GetComponent<SpriteRenderer>().flipX = true;
        if (direction == -1) GetComponent<SpriteRenderer>().flipX = false; 
        
        if (Input.GetButtonDown("Fire1") && !isJumping) {
            jumpParticles.Play();
            AudioManager.instance.PlaySFX("Jump");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector2 origin = new Vector2(transform.position.x, transform.position.y - offset);
        Vector2 target = new Vector2(transform.position.x, transform.position.y - offset - lineLength);
        Debug.DrawLine(origin, target, Color.black);

        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down, lineLength);

        if (raycast.collider == null) isJumping = true;
        else isJumping = false;

        if (raycast.collider == null) SetAnimation("jump");
        else SetAnimation(GetComponent<Rigidbody2D>().velocity.x != 0 ? "run" : "idle");
    }

    void SetAnimation(string name) {
        AnimatorControllerParameter[] parameters = GetComponent<Animator>().parameters;
        foreach (var item in parameters) GetComponent<Animator>().SetBool(item.name, false);
        GetComponent<Animator>().SetBool(name, true);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision != null) {
            if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Obstacle")) {
                AudioManager.instance.PlaySFX("Hit");
                AudioManager.instance.PlaySFX("Lose");
                SCManager.instance.LoadScene("GameOver");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null) {
            if (collision.CompareTag("Key")) {
                AudioManager.instance.PlaySFX("CollectCoin");
                Destroy(collision.gameObject);
            }
            if (collision.CompareTag("Goal")) {
                if (GameObject.Find("Key") != null) return;
                GameManager.instance.ChangeLevel();
            }
        }
    }
}