using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class voiceCommands : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> actions = new Dictionary<string, Action>();
    Animator anim = new Animator();
    void Start()
    {
        anim = GetComponent<Animator>();
        actions.Add("forward", Forward);
        actions.Add("upward", Up);
        actions.Add("back", Back);
        actions.Add("down", Down);
        actions.Add("stop", Stop);
        actions.Add("dance", Dance);



        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }
    private void Up()
    {
        transform.Translate(0, 1, 0);
    }
    private void Down()
    {
        transform.Translate(0, -1, 0);
    }
    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }
    private void Stop()
    {
        anim.SetBool("isDancing", false);
    }
    private void Dance()
    {
        anim.SetBool("isDancing", true);
    }
}
