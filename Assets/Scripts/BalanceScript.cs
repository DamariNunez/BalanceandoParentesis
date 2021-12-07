using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class BalanceScript : MonoBehaviour
{
    public InputField inputField;
    public Text text;
    public GameObject checkImage;
    public GameObject wrongImage;
    public GameObject checkSound;
    public GameObject wrongSound;

    // Start is called before the first frame update
    void Start()
    {
        checkImage.SetActive(false);
        wrongImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Regla1()
    {
        if (inputField.text == "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public int Parentesis()
    {
        int count = 0;
        char[] str = inputField.text.ToCharArray();
        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == '(')
            {
                count++;
            }
            else if (str[i] == ')')
            {
                count--;
            }
        }
        return count;
    }

    public int Emoticon()
    {
        int count = Parentesis();
        char[] str = inputField.text.ToCharArray();
        for(int i = 0; i < str.Length; i++)
        {
            if(str[i] == ':' && (i+1) < str.Length && str[i+1] == ')')
            {
                count++;
            }
            if (str[i] == ':' && (i+1) < str.Length && str[i+1] == '(')
            {
                count--;
            }
        }
        return count;
    }  

    public bool Regla3()
    {
        if (Emoticon() == 0 && Regex.IsMatch(inputField.text, @"^[a-zA-Z :()]+$"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Ex()
    {
        int count = Parentesis();
        char[] str = inputField.text.ToCharArray();
        int lon = (int) str.Length/2;
        if(count == 0 && str[lon] == ':' && Regex.IsMatch(inputField.text, @"^[a-zA-Z :()]+$"))
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public void VerificarBalance()
    { 
        if(Regla1() || Regla3() || Ex())
        {   
            text.text = "Balanceado";
            checkImage.SetActive(true);
            Instantiate(checkSound);
        }
        else 
        {
            text.text = "Desbalanceado";
            wrongImage.SetActive(true);
            Instantiate(wrongSound);
        }
    }

    public void focus()
    {
        text.text = "";
        checkImage.SetActive(false);
        wrongImage.SetActive(false);
    }
}