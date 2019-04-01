using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    public Joystick joystick;
    public Button m_jumpButton;

    [Header("Control")]
    public float sensitivity = .4f;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	bool jump = false;

    private void OnEnable()
    {
        m_jumpButton.onClick.AddListener(() => jumpButton());
    }

    private void jumpButton() {
        Debug.Log("Im Clicked");
        jump = true;
        animator.SetBool("IsJumping", true);
    }

    // Update is called once per frame
    void Update () {

        //pc control
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        //mobile control
        //if (joystick.Horizontal >= sensitivity){
        //    horizontalMove = runSpeed;
        //}
        //else if (joystick.Horizontal <= -sensitivity){
        //    horizontalMove = -runSpeed;
        //} else {
        //    horizontalMove = 0f;
        //}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if(Input.GetButtonDown("Jump")){
			jump = true;
			animator.SetBool("IsJumping", true);
		}
	}

	public void OnLanding(){
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate(){
		//public void Move(float move, bool crouch, bool jump)
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;

	}
}
