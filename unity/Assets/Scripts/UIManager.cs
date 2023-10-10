using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    static UIManager current;

    public TextMeshProUGUI UILife;

    // Start is called before the first frame update
    void Awake()
    {
        if (current != null && current != this){
            Destroy(gameObject);
            return;
        }

        current = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public static void UpdateLifeUI(int life)
    {
        if (current == null)
            return;

        current.UILife.text = life.ToString();
        
    }
}
