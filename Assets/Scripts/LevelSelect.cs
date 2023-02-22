using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string menu;
    public string lvl1;
    public string lvl2;
    public string lvl3;

    public void back()
    {
        SceneManager.LoadScene(menu);
    }

    public void load1()
    {
        SceneManager.LoadScene(lvl1);
    }

    public void load2()
    {
        SceneManager.LoadScene(lvl2);
    }

    public void load3()
    {
        SceneManager.LoadScene(lvl3);
    }
}
