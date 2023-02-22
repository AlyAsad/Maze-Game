using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedX, resetTime, lifetime;
    public bool Over = false;

    

    private void Update()
    {
        if (!Over)
        {
            float MSX = speedX * Time.deltaTime;
            transform.Translate(MSX, 0f, 0f);

            lifetime += Time.deltaTime;
            if (lifetime > resetTime)
                gameObject.SetActive(false);

        }
    }

    public void Activate()
    {

        lifetime = 0;
        gameObject.SetActive(true);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Over = true;
        
        else if (collision.gameObject.CompareTag("Grid"))
            gameObject.SetActive(false);
    }

}
