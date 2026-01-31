
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro dialogueBubble;

    [SerializeField]
    private Text dialogueText;

    [SerializeField]
    private string dialogueString;

    [SerializeField]
    private char buttonToPress;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //dialogueBubble.text = dialogueString; 
        
        char[] phrase = dialogueString.ToCharArray();
        int n = (int)(UnityEngine.Random.Range(0, phrase.Length - 1));
        int len = phrase.Length;
        while (!System.Char.IsLetter(phrase[n]))
        {
           n = (int)(UnityEngine.Random.Range(0, phrase.Length - 1));
        }
        buttonToPress = phrase[n];
        phrase[n] = Char.ToUpper(phrase[n]);
        dialogueBubble.text = new string(phrase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pop()
    {
        Destroy(gameObject);
    }

    public char getButtonToPress()
    {
        return buttonToPress;
    }
}
