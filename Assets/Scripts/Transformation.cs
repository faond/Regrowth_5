using UnityEngine;
using UnityEngine.UI;

public class Transformation : MonoBehaviour
{

  public Animator animator;
  public float timer = -1 ;
  public bool timerIsRunning = false;
  private bool isAParent ;
  public Animator animatorChild;

  void Start(){
      if(transform.childCount > 0){
         animatorChild = transform.GetChild(0).gameObject.GetComponent<Animator> ();
         isAParent = true;
     }
     else{
       isAParent=false;
     }
  }



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
            if(isAParent) animatorChild.SetTrigger("Wilt");
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
        if(isAParent) animatorChild.SetTrigger("Bloom");
        gameObject.tag = "Bloom";
        timer = 5;
        timerIsRunning = true;

      }
  }
}
