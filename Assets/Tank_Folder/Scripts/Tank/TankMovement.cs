using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    //public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;
    public AudioClip m_EngineDriving;
    public float m_PitchRange = 0.2f;
    //Vector3 m_roatation = gameObject.transform.localEulerAngles;


    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;

    bool foward = false;
    bool back = false;
    bool right = false;
    bool left = false;
    float rightTurn = 0.5f;
    float leftTurn = -0.5f;
    float fowardMove = 1.0f;
    float backMove = -1.0f;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }



    private void Start()
    {

    }


    private void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");

        if (right)
        {
            mobileTurn(rightTurn);
            //          右に動かすためのメソッドを呼び出す
        }
        if (left)
        {
            mobileTurn(leftTurn);
            //          左に動かすためのメソッドを呼び出す
        }
        if (foward)
        {
            mobileMove(fowardMove);
            //          
        }
        if (back)
        {
            mobileMove(backMove);
            //         
        }

    }


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
    }


    private void FixedUpdate()
    {
        // Move and turn the tank.
        Move();
        Turn();
    }


    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    public void mobileTurn(float turnValue)
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = turnValue * m_TurnSpeed * Time.deltaTime;
        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    public void mobileMove(float moveValue)
    {
        Vector3 movement = transform.forward * moveValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    public void fowardPushDown()
    {
        //      右ボタンを押している間
        foward = true;



    }

    public void fowardPushUp()
    {
        //      右ボタンを押すのをやめた時
        foward = false;
    }

    public void backPushDown()
    {
        //      左ボタンを押している間
        back = true;

    }

    public void backPushUp()
    {
        //      左ボタンを押すのをやめた時
        back = false;
    }

    public void rightPushDown()
    {
        //      右ボタンを押している間
        right = true;

    }

    public void rightPushUp()
    {
        //      右ボタンを押すのをやめた時
        right = false;
    }

    public void leftPushDown()
    {
        //      左ボタンを押している間
        left = true;
    }

    public void leftPushUp()
    {
        //      左ボタンを押すのをやめた時
        left = false;
    }

}
