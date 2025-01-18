using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    
    public animator script;
    static public float time = 8;
    private TMP_Text scoreField;

    // Start is called before the first frame update
    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        script = GameObject.Find("player").GetComponent<animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = "" + Mathf.RoundToInt(time);
        if (animator.started == true && animator.won == false)
        {
                time -= 1 * Time.deltaTime;
        } else if (animator.started == true && animator.won == true)
        {
            time += 0;
        }

        if (time < 0)
        {
            animator.finished = true;
            script.heartAttack();
        }
        
    }
}
