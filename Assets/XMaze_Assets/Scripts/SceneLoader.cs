﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private AsyncOperation async;
    private bool counting = false;
    public float countDown = 4f;
    public float countDownStart;

    private FileWriter writer;
    private EyeDots eyeDots;

    public int mode;

    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        writer = GameObject.Find("FileWriter").GetComponent<FileWriter>();
        eyeDots = GameObject.Find("LogReader").GetComponent<EyeDots>();
    }

    // Update is called once per frame
    void Update()
    {
        if(counting)
        {
            if(Time.time - countDownStart >= countDown)
            {
                async.allowSceneActivation = true;
            }
        }

        if(Input.GetKey("5") && !counting)
        {
            counting = true;
            if(mode == 3)
            {
                writer.SetStartTime();
                eyeDots.enabled = true;
            }
            else
            {
                writer.StartWriting();
            }
            countDownStart = Time.time;
        }
    }

}
