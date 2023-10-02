using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int attempts;
    [SerializeField] TextMeshProUGUI displayText;
    private string currWord;

    public string selectedWord;
    // Start is called before the first frame update
    void Start()
    {
        SelectRandomWord();
        currWord  = new string('_', selectedWord.Length);
        attempts = 6;
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text= currWord;
    }

    public void CheckGameEnd(string currentWord, string selectedWord)
    {
        if (attempts <= 0)
        {
            //gameEnded = true;
            Debug.Log("Kaybettiniz!");
        }
        else if (currentWord == selectedWord)
        {
            //gameEnded = true;
            Debug.Log("Tebrikler! Kazandýnýz!");
        }
    }

    public void UpdateWordDisplay(string currentWord)
    {
        displayText.text = currentWord;
        currWord = currentWord;
    }

    public string SelectRandomWord()
    {
       selectedWord = "aaba";

       return selectedWord;
    }
}
