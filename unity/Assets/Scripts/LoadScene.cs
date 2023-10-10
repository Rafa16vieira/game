using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private Animator animator;
    public float timeTransition;
    public Player player;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int level){
        player.animator.SetFloat("xVelocity", 0);
        player.enabled = false;
        animator.SetTrigger("load");
        yield return new WaitForSeconds(timeTransition);
        SceneManager.LoadScene(level);
    }
}
