using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class VoiceControll : MonoBehaviour
{
    private KeywordRecognizer keywordRecog;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public Vector2 moveVect;
    public bool voiceFlag = false;
    public GameControll gamectrl;
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("left", Left);
        actions.Add("right", Right);
        keywordRecog = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecog.OnPhraseRecognized += WordRecognized;
        keywordRecog.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs speech) {
        //Debug.Log(speech.text);
        actions[speech.text].Invoke();
        voiceFlag = true;
    }

    private void Up()
    {
        moveVect = new Vector2(0f, 5f);
    }

    private void Down()
    {
        moveVect = new Vector2(0f, -5f);
    }

    private void Left()
    {
        moveVect = new Vector2(-5f, 0f);
    }

    private void Right()
    {
        moveVect = new Vector2(5f, 0f);
    }
   
}
