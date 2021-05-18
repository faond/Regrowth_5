using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public static RandomManager instance { get; private set; }

    public bool lifeMustPop = false;

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un PlayerMovement");
          return ;
        }
        instance = this;
    }

    public bool RandomTrueOrFalse(){
        int rand = Random.Range(0,2);
        return rand == 1;
    }

    public int Uniform(int min, int max){
        return Random.Range(min, max + 1);
    }

    public float Uniform(float min, float max){
        return Random.Range(min, max);
    }

    public int Bernoulli(float p){
        float u = Random.Range(0,1);
        if (u <= p) return 1; // P( X = 1 ) = p
        return 0; // P( X = 0 ) = 1 - p
    }

    public int Binomial(int n, float p){
        int result = 0;
        for(int i=0; i<n; i++){
            result += Bernoulli(p);
        }
        return result;
    }

    // public int Poisson(float lambda){
    //     //Wikipédia : simulation avec la méthode de la transformée inverse
    //     int k = 0;
    //     float p = 1;
    //     float u;
    //     while (p > exp(-lambda)) {
    //         u = Uniform(0.f, 1.f)
    //         p = p * u;
    //         k ++;
    //     }
    //     return k - 1;
    // }

    public int Geometric(float p){
        int count = 0;
        while(Bernoulli(p) != 1) count ++;
        return count;
    }
}
