using UnityEngine;

public class Transformation : MonoBehaviour
{

  public Animator animator;
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
        gameObject.tag = "Bloom";
        // UTILISATION DE LA VARIABLE difficulty
        // SettingsMenu.instance.difficultySlider.value
        timer = 5;
        timerIsRunning = true;

      }

  }
}
