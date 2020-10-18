using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    public Animator anim;
    public GameObject camera;

    public bool weapon=false;
    public float forward=0;
    public float backward=0;
    public float left;
    public float right;
    public bool crouch;
    public float turn;
    public bool turnbool;

    public float buttonsensitivity=1f;
    public float mousesensitivity = 100f;
    public float moveSpeed = 5f;
    public float axisX;
    public float axisY;



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
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime*2, Space.Self);
        }
        else if(forward>0)
        {
            forward -= Time.deltaTime * buttonsensitivity;
            anim.SetFloat("forward", forward);
          //  transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime *2, Space.Self);
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
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime , Space.Self);
        }
        else if(forward<0)
        {
            forward += Time.deltaTime * buttonsensitivity;
            anim.SetFloat("forward", forward);
         //   transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime , Space.Self);
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
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        }
        else if(backward>0)
        {
            backward -= Time.deltaTime * buttonsensitivity;
            anim.SetFloat("backward", backward);
        //   transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
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
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime , Space.Self);
        }
        else if (backward < 0)
        {
            backward += Time.deltaTime * buttonsensitivity;
            anim.SetFloat("backward", backward);
         //   transform.Translate(Vector3.right * moveSpeed * Time.deltaTime , Space.Self);
        }

        // turn around using mouse x axis
        axisX = Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, Vector3.up, axisX* mousesensitivity * Time.deltaTime);
        if (Input.GetAxis("Mouse X")>0f )
        {
            turn =100*Time.deltaTime;
            anim.SetFloat("TURN", turn);          
        }
        else if(Input.GetAxis("Mouse X") < 0f )
        {
            turn=-100*Time.deltaTime;
            anim.SetFloat("TURN", turn);
          //  transform.RotateAround(transform.position, Vector3.up, -axis * mousesensitivity * Time.deltaTime);
        }
        if(axisX==0)
        {
            turn = 0;
            anim.SetFloat("TURN", turn);
        }

        //camera vertical movement
        axisY = Input.GetAxis("Mouse Y");
       //  camera.transform.RotateAroundLocal( Vector3.right, axisY * mousesensitivity * Time.deltaTime);

        
      
    } //end update
}
