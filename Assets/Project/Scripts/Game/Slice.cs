using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slice : MonoBehaviour
{
    private string selectedWord;
    private string currentWord;
    private bool gameEnded = false;

    public GameManager gameManager;

    private string slicedLetter;
    
    public GameObject bladeTrailerPrefab;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    GameObject currentBladeTrailer;
    // Start is called before the first frame update
    void Start()
    {
        selectedWord = gameManager.SelectRandomWord();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        currentWord = new string('_', selectedWord.Length);
    }

    // Update is called once per frame
    void Update()
    {
        isCuttingOrNotCutting();
        Debug.Log(currentWord);
    }

    void isCuttingOrNotCutting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCutting();
            isCutting = true;
            currentBladeTrailer = Instantiate(bladeTrailerPrefab, transform);
            circleCollider.enabled = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            //StopCutting();
            isCutting = false;
            currentBladeTrailer.transform.SetParent(null);
            Destroy(currentBladeTrailer, 2f);
            circleCollider.enabled = false;
        }

        if (isCutting)
        {
           //UpdateCut();
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Cuttable")
        {
            //Sliced letter
            slicedLetter = collision.transform.GetComponent<SpriteRenderer>().sprite.name.ToString();        
            CheckLetter(slicedLetter);
        }
    }
    public void CheckLetter(string input)
    {
        if (gameEnded)
            return;

        char guessedLetter = input.ToString().ToLower()[0];
        bool letterFound = false;

        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == guessedLetter)
            {             
                currentWord = currentWord.Substring(0, i) + guessedLetter + currentWord.Substring(i + 1);
                letterFound = true;
                Debug.Log("You found! : " + guessedLetter + " \n " + " Final status : " + currentWord );
            }
        }

        if (!letterFound)
        {           
            gameManager.attempts--;
            Debug.Log("You SLICED wrong letter");
        }

        
        gameManager.UpdateWordDisplay(currentWord);
        gameManager.CheckGameEnd(currentWord,selectedWord);
    }
}
