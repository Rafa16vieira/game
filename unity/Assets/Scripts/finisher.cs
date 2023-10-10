using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finisher : MonoBehaviour
{
    public LoadScene loadScene;

    private void Awake(){
        loadScene = FindObjectOfType<LoadScene>();

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            loadScene.LoadNextLevel();
            UIManager.UpdateLifeUI(3);
        }
    }
}
