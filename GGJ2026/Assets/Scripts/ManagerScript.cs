using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string i = Input.inputString; 
        Debug.Log(i);
    }

}
