using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControll : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    float moveHorizontal, moveVertical;
    public GameControll controller;
    public Vector2 moveVect;
    public VoiceControll voicectrl;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        moveVertical = Input.GetAxis("Vertical");
        Debug.Log(voicectrl.voiceFlag);
        if (voicectrl.voiceFlag)
        {
            moveVect = voicectrl.moveVect;
            voicectrl.voiceFlag = false;
        }
        else
        {
            moveVect = new Vector2(moveHorizontal, moveVertical);
        }
       
        this.rb2d.velocity = moveVect * speed ;
        /*
        Vector3 moveVect = new Vector3(moveHorizontal, moveVertical, 0f);
        this.transform.position += moveVect * speed * Time.deltaTime;
        */
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Planet")
        {
            Destroy(this.gameObject);
            controller.Restart();
        }
        else if (col.gameObject.tag == "Earth")
        {
            controller.scoreAmount += 10;
            Destroy(col.gameObject);
        }
    }

}