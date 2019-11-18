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

    // Start is called before the first frame update
    void Start()
    {
        this.initialization();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.defaultCharacterSize();
        if(this.onEnterForwordKeys())
            this.moveForward();
        if(this.onEnterBackwordKeys())
            this.moveBackword();
        if(this.onEnterJumpKeys())
            this.jump();
        if(this.onEnterCrouchKeys())
            this.crouch();
    }

    ////////////////////////////////////////////////////
    //////////////////// UTILITY FUNCTION //////////////
    ////////////////////////////////////////////////////

    private void initialization(){
        this.defaultCharacterSize();
    }
    //Move Forward
    private bool onEnterForwordKeys(){
        return Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow);
    }
    private void moveForward(){
        this.movementDirection.AddForce(movementsForce * Time.deltaTime,0,0);
    }

    //Move Backword
    private bool onEnterBackwordKeys(){
        return Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow);
    }
    private void moveBackword(){
        this.movementDirection.AddForce(-movementsForce * Time.deltaTime,0,0);
    }

    //Jump
    private bool onEnterJumpKeys(){
        return Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow);
    }
    private void jump(){
        this.movementDirection.AddForce(0,jumpForce * Time.deltaTime,0);
    }

    //Crouch
    private bool onEnterCrouchKeys(){
        return Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow);
    }
    private void crouch(){
        float crouchRatio = (float)Math.Round(this.characterHeight * 2) / 4;
        this.characterProperty.localScale = new Vector3(this.characterWidth,this.characterHeight - crouchRatio ,1);
    }
    private void defaultCharacterSize(){
        this.characterProperty.localScale = new Vector3(this.characterWidth,this.characterHeight,1);
    }
}
