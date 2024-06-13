using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butten_Controler : MonoBehaviour
{
    public string ColorLabel;

    public Game_Controler Game_Controler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Choise_The_Color()
    {
        Game_Controler.ValidateColor(ColorLabel);
    }
}
