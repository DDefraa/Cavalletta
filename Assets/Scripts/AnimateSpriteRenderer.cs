using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSpriteRenderer : MonoBehaviour
{

    public Sprite idleSprite;
    public Sprite[] animationSprites; 

    private SpriteRenderer spriteRenderer;

    public float animationTime = 0.25f;
    private int animationFrame;

    public bool loop = true;
    public bool idle = true;

    private void Awake()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }


    private void NextFrame()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        animationFrame++;

        if (loop && animationFrame >= animationSprites.Length)
        {

            animationFrame = 0;

        }

        if(idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if(animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationFrame];
         }

    }
}
