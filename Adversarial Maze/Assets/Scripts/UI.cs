﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

    Canvas canvas;

    public Text text;

    Timer timer;
    float timeLimit = 0;

    // Use this for initialization
    void Start () {
        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;

        canvas = FindObjectOfType<Canvas>();

        timer = this.transform.GetComponentInParent<Timer>();

        toast("toasty", 3);

    }
	
	// Update is called once per frame
	void Update () {

        // Fade out text when we've passed timeLimit

        float curTime = timer.getTime();
        if(timer.isEnabled() && curTime > timeLimit){
            timer.resetTimer();

            //Fade out text over 2 sec
            text.CrossFadeAlpha(0, 2.0f, true);
        }
	}

    void toast(string message, float time){
        timer.resetTimer();
        timer.startTimer();
        timeLimit = time;
        text.text = message;

        //Instantly fade in text
        text.CrossFadeAlpha(1, 0.0f, true);
    }
}
