using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Windows.Speech;
public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bullet;
    private KeywordRecognizer keywordRecog;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public bool voiceFlag = false;

    bool right = false;
    bool up = true;
    bool left = true;
    bool down = true;
    void Start()
    {
        actions.Add("one", Right);
        actions.Add("two", Down);
        actions.Add("three", Left);
        actions.Add("zero", Up);
        keywordRecog = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecog.OnPhraseRecognized += WordRecognized;
        keywordRecog.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs speech) {
         //Debug.Log(speech.text);
         actions[speech.text].Invoke();
         voiceFlag = true;
     }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }

     }
     void Right(){
        Debug.Log("shooting");
        right = true;
        left = false;
        up = false;
        down = false;
     }

      void Left(){
         Debug.Log("shooting");
         right = false;
         left = true;
         up = false;
         down = false;
      }

       void Down(){
          Debug.Log("shooting");
          right = false;
          left = false;
          up = false;
          down = true;
       }

        void Up(){
           Debug.Log("shooting");
           right = false;
           left = false;
           up = true;
           down = false;
        }

     void Shooting(){
        if(right){
            Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        } else if (up){
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        } else if (down) {
            Instantiate(bullet, firePoint2.position, firePoint2.rotation);
        } else if (left) {
            Instantiate(bullet, firePoint3.position, firePoint3.rotation);
        }
     }
}
