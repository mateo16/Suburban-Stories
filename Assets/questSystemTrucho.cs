using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questSystemTrucho : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public static int questNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && questNumber==2){
            questNumber = 3;
        }

        if(questNumber == 1){
            texto.text = "Movete usando WASD";
        }else if(questNumber == 2){
            texto.text = "Agarra algo usando la E";
        }else if(questNumber == 3){
            texto.text = "Habla con el vendedor";
        }else if(questNumber == 4){
            texto.text = "";
        }
    }
}
