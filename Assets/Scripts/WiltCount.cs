using UnityEngine;
using UnityEngine.SceneManagement;

public class WiltCount : MonoBehaviour
{

    public GameObject[] objects;
    public static WiltCount instance ;


    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un WiltCount");
          return ;
        }
        instance = this;



    }

    void Update(){
      bool win = true;
      foreach(var element in objects){
          if(element.tag == "Wilt") {
            win = false;
            break;
          }
      }

      if(win) {
        WinManager.instance.OnPlayerWin();
        return;
      }
    }


}
