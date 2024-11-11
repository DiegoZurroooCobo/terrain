using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLifes : MonoBehaviour
{
    private int lifes = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene() 
    {
        GameManager.instance.LoadScene("Defeat");
    }

    public void LoseLifes_() 
    { 
        lifes -= 1;
        if (lifes == 0)
        {
            LoadScene();
            //SceneManager.LoadScene(6);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
