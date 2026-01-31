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
    private string dialogueWords;

    [SerializeField]
    private char buttonToPress;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
