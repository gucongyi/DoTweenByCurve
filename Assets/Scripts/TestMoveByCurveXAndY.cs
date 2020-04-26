using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameTools;

public class TestMoveByCurveXAndY : MonoBehaviour
{
    public bool isBegin;
    public float xRadio;
    public float yRadio;
    //public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    public AnimationCurve xCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    public AnimationCurve yCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
    float xOld;
    float yOld;
    float xNow;
    float yNow;
    float timeCount = 0f;
    
    void Start()
    {
        Reset();
        xOld = transform.position.x;
        yOld = transform.position.y;

    }

    private void Reset()
    {
        isBegin = false;
        xNow = xOld;
        yNow = yOld;
        timeCount = 0f;
        transform.position = new Vector3(xNow, yNow, 0f);
    }

    private void Update()
    {
        if(isBegin)
        {
            timeCount += Time.deltaTime;
            xNow = xOld + xCurve.Evaluate(timeCount)* xRadio;
            yNow = yOld + yCurve.Evaluate(timeCount) * yRadio;
            transform.position = new Vector3(xNow, yNow, 0f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        
    }

    void ActionMoveCompelete()
    {
        Debug.Log($"<color=green>Tween Move By Curve compelete</color>");
    }
}
