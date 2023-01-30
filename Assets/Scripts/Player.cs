using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    public Sprite[] sprites;
    public int spriteIndex;
    public float y;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.25f, 0.25f);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            direction = Vector3.up * strength;
        }
        
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void AnimateSprite()
    { 
        Vector3 position = transform.position;
        y = position.y;
        if (y < -6 || y > 6)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "tree")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "gold")
        {
            FindObjectOfType<GameManager>().IncreaseScore(3);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "red")
        {
            FindObjectOfType<GameManager>().IncreaseScore(1);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "rotten")
        {
            FindObjectOfType<GameManager>().IncreaseScore(-1);
            other.gameObject.SetActive(false);
        }
    }
}
