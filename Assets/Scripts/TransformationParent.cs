using UnityEngine;

public class TransformationParent : MonoBehaviour
{

  public Animator animator;
  public Animator animatorChild;
  public GetTransformed child;
  public float timer = -1 ;
  public bool timerIsRunning = false;

  public void Update(){
    if (timerIsRunning)
        {
          if (timer > 0 && gameObject.tag == "Bloom")
          {
              timer -= Time.deltaTime;
          }
          else
          {
            animator.SetTrigger("Wilt");
            animatorChild.SetTrigger("Wilt");
            gameObject.tag = "Wilt";
            timer = -1;
            timerIsRunning = false;
          }
        }

  }



  private void OnCollisionEnter2D(Collision2D collision)
  {
      if(collision.transform.CompareTag("Player") && gameObject.tag == "Wilt")
      {
        animator.SetTrigger("Bloom");
        animatorChild.SetTrigger("Bloom");
        gameObject.tag = "Bloom";
        timer = 5;
        timerIsRunning = true;
      }
  }
}
