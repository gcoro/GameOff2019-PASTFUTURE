using System;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    //Public references to character component

    public Rigidbody movementDirection;
    public float movementsForce = 0;
    public float jumpForce = 0;

    public Transform characterProperty;
    public float characterHeight = 2;
    public float characterWidth = 1;

    public Animator girlAnimator;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start(){
        this.initialization();
    }

    // Update is called once per frame
    void FixedUpdate(){
        this.defaultCharacterSize();
        //if(this.onEnterForwardKeys())
        //    this.moveForward();
        //if(this.onEnterBackwardKeys())
        //    this.moveBackward();
        if(this.onEnterJumpKeys())
            this.jump();
        if(this.onEnterCrouchKeys())
            this.crouch();

        if(isGrounded == false)
            this.movementDirection.AddForce(0,-movementsForce * Time.deltaTime,0);
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == ("Ground") && this.isGrounded == false)
            this.isGrounded = true; 
        	girlAnimator.SetBool("jumped",false);
    }
    ////////////////////////////////////////////////////
    //////////////////// UTILITY FUNCTION //////////////
    ////////////////////////////////////////////////////

    private void initialization(){
        this.defaultCharacterSize();
    }
    //Move Forward
    private bool onEnterForwardKeys(){
        return Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
    }
    private void moveForward(){
        this.movementDirection.AddForce(movementsForce * Time.deltaTime,0,0);
    }

    //Move Backward
    private bool onEnterBackwardKeys(){
        return Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
    }
    private void moveBackward(){
        this.movementDirection.AddForce(-movementsForce * Time.deltaTime,0,0);
    }

    //Jump
    private bool onEnterJumpKeys(){
        return (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) && this.isGrounded==true);
    }
    private void jump(){
        if (isGrounded)
        {
            this.movementDirection.AddForce(new Vector3(0, jumpForce * Time.deltaTime, 0), ForceMode.Impulse);
            this.isGrounded = false;
            girlAnimator.SetBool("jumped", true);
        }
    }

    //Crouch
    private bool onEnterCrouchKeys(){
        return (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) && this.isGrounded);
    }
    private void crouch(){
        float crouchRatio = (float)Math.Round(this.characterHeight * 2) / 4;
        this.characterProperty.localScale = new Vector3(this.characterWidth,this.characterHeight - crouchRatio ,1);
        girlAnimator.SetBool("crouch",true);
       // this.characterProperty.position = new Vector3(this.characterProperty.position.x, crouchRatio, this.characterProperty.position.z);
    }

    // Default settings
    private void defaultCharacterSize(){
        this.characterProperty.localScale = new Vector3(this.characterWidth,this.characterHeight,1);
    }
}
