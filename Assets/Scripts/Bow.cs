using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private int i;
    public float timePerAttack, timeSinceLast;
    public Transform startPoint;
    public GameObject[] arrows;
    public GameObject Over;

    public void Start()
    {
        timeSinceLast = timePerAttack;
    }


    public void Update()
    {

        if (!Over.activeInHierarchy)
        {
            timeSinceLast += Time.deltaTime;
            if (timeSinceLast >= timePerAttack) Attack();

        }
    }

    public void Attack()
    {

        timeSinceLast = 0;

        for (i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy) break;

        }

        arrows[i].transform.position = startPoint.position;
        arrows[i].GetComponent<Arrow>().Activate();

    }


}
