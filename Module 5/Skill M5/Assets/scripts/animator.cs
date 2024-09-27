using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class animator : MonoBehaviour
{
    private Animator animate;
    public float speed;
    private float inputs = 1;
    private float secondsPast = 1;
    static public bool started = false;
    static public bool finished = false;
    public static bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 80)
        {
            finished = true;
            animate.SetTrigger("won");
            animate.ResetTrigger("runStart");
            animate.ResetTrigger("runStop");
            won = true;

        }
        secondsPast += 1 * Time.deltaTime;
       // Debug.Log( speed);
        if (speed > 1)
        {
            animate.SetTrigger("runStart");
            animate.ResetTrigger("runStop");
        }else if (speed <= 1)
        {
            animate.SetTrigger("runStop");
            animate.ResetTrigger("runStart");
        }
         transform.position = transform.position += new Vector3(speed * Time.deltaTime, speed,0 );
        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            inputs += 1;
            
            
            
        }
       if (started == true && finished == false)
        {

            speed = 2*(inputs / secondsPast);

            if (speed >= 20)
            {
                inputs = secondsPast * 10;
            }

            if (speed < 1)
            {
                inputs = 0;
            }

        } else if (started == false && finished == false)
        {
            speed = 0;
        } else if (started == true && finished == true)
        {
            speed = 0;
        }
       if (timer.time < 0)
        {
            speed = 0;
        }
        
            
        
        

    }
    public void heartAttack()
    {
        animate.SetTrigger("lost");
        animate.ResetTrigger("runStart");
        animate.ResetTrigger("runStop");
    }
}
