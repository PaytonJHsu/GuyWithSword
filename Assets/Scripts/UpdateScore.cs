using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI myTextElement;
    public GameObject jerry;
    int monah = 0; 
    
    public void ButtonPress()
    {
        // myTextElement.text = "BEans";


    }
    // Start is called before the first frame update
    void Start()
    {
        monah = 0;
        myTextElement.text = "Score:" + monah;
        
    }

    // Update is called once per frame
    void Update()
    {
        monah = jerry.GetComponent<CharacterMovement>().getMoney();

        myTextElement.text = "Score:" + monah.ToString();

    }
}
