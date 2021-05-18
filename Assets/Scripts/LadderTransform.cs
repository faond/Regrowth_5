using UnityEngine;

public class LadderTransform : MonoBehaviour
{

  public Animator animator;
  private PlayerMovement playerMovement;

  void Awake()
  {
      playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if(collision.transform.CompareTag("Player") && gameObject.tag == "Wilt" && playerMovement.isClimbing)
      {
        animator.SetTrigger("Bloom");
        gameObject.tag = "Bloom";
      }

  }

  private void OnTriggerStay2D(Collider2D collision)
  {
      if(collision.transform.CompareTag("Player") && gameObject.tag == "Wilt" && playerMovement.isClimbing)
      {
        animator.SetTrigger("Bloom");
        gameObject.tag = "Bloom";
      }

  }
}
