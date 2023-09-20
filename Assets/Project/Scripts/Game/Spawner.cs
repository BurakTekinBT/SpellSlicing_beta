using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Target")]
    public GameObject prefab;

    [Header("Gameplay")]
    //public float interval;
    public float minimumX;
    public float maximumX;
    //public float y;

    private float time;
    public float startTime;

    [Header("Visuals")]
    public Sprite[] sprites;



    // Start is called before the first frame update
    void Start()
    {
        
        //InvokeRepeating("Spawn",interval,interval);
    }

    private void Spawn()
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(Random.Range(minimumX,maximumX), transform.position.y);

        //Generate random letter 
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            Spawn();
            time = startTime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
