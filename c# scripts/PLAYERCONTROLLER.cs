using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    public Animator anim;

    public bool weapon=false;
    public float forward=0;
    public float backward=0;
    public float left;
    public float right;
    public bool crouch;
    public float turn;
    public bool turnbool;

    public float buttonsensitivity=1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && weapon==false)                // to enter weapon mode
        {
            weapon = true;
            crouch = false;
            anim.SetBool("idle aiming", weapon);
            anim.SetBool("CROUCH", crouch);
        }
        else if(Input.GetKeyDown(KeyCode.R) && weapon == true)      //to exit weapon mode
        {
            weapon = false;
            anim.SetBool("idle aiming", weapon);
          //  anim.SetBool("CROUCH", crouch);
        }

        if (Input.GetKeyDown(KeyCode.C) && crouch == false)                // to enter crouch mode
        {
            weapon =false;
            crouch = true;
            anim.SetBool("idle aiming", weapon);
            anim.SetBool("CROUCH", crouch);
        }
        else if (Input.GetKeyDown(KeyCode.C) && weapon == true)      //to exit crouch mode
        {
            crouch = false;
         //   anim.SetBool("idle aiming", weapon);
            anim.SetBool("CROUCH", crouch);
        }



        if (Input.GetKey(KeyCode.UpArrow) && forward < 2)           //to walk forward
        {
           if(forward<1)
            {
                forward += Time.deltaTime * buttonsensitivity;
            }
            if(Input.GetKey(KeyCode.RightShift) && forward<2)           //to run forward using shift
            {
                forward += Time.deltaTime * buttonsensitivity;
            }
            else if(forward>1)
            {
                forward -= Time.deltaTime * buttonsensitivity;
            }
            anim.SetFloat("forward", forward);
        }
        else if(forward>0)
        {
            forward -= Time.deltaTime * buttonsensitivity;
            anim.SetFloat("forward", forward);
        }

        if(Input.GetKey(KeyCode.DownArrow) && forward>-2)           //to walk backward
        {
            if (forward > -1)
            {
                forward -= Time.deltaTime * buttonsensitivity;
            }
            if (Input.GetKey(KeyCode.RightShift) && forward >- 2)           //to run backward using shift
            {
                forward -= Time.deltaTime * buttonsensitivity;
            }
            else if (forward <- 1)
            {
                forward += Time.deltaTime * buttonsensitivity;
            }
            anim.SetFloat("forward", forward);
        }
        else if(forward<0)
        {
            forward += Time.deltaTime * buttonsensitivity;
            anim.SetFloat("forward", forward);
        }

        if (Input.GetKey(KeyCode.RightArrow) && backward < 2)           //to walk right
        {
            if(backward<1)
            {
                backward += Time.deltaTime * buttonsensitivity;
            }
          
            if (Input.GetKey(KeyCode.RightShift) && backward < 2)           //to run right using shift
            {
                backward += Time.deltaTime * buttonsensitivity;
            }
            else if ( backward > 1)
            {
                backward -= Time.deltaTime * buttonsensitivity;
            }
            anim.SetFloat("backward", backward);
        }
        else if(backward>0)
        {
            backward -= Time.deltaTime * buttonsensitivity;
            anim.SetFloat("backward", backward);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && backward>-2)         //to walk left
        {
            if (backward > -1)
            {
                backward -= Time.deltaTime * buttonsensitivity;
            }
            if (Input.GetKey(KeyCode.RightShift) && backward >- 2)           //to run left using shift
            {
                backward -= Time.deltaTime * buttonsensitivity;
            }
            else if ( backward < -1)
            {
                backward += Time.deltaTime * buttonsensitivity;
            }
            anim.SetFloat("backward", backward);
        }
        else if (backward < 0)
        {
            backward += Time.deltaTime * buttonsensitivity;
            anim.SetFloat("backward", backward);
        }


    } //end update
}
