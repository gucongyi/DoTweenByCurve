using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameTools;

public class TestMoveByCurve : MonoBehaviour
{
    public AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

    void Start()
    {
        TweenData tweenData = new TweenData()
        {
            autoPlay = false,
            autoKill = true,
            Duration = 1f,
            Delay = 0f,
            id = 0 + "",
            endValueVector3 = new Vector3(0f, -5f, 0f)
        };
        Tween tweenMove=GameTools.SetAnimMoveByCurve(gameObject, easeCurve, tweenData, ActionMoveCompelete);
        tweenMove.PlayForward();
    }

    void ActionMoveCompelete()
    {
        Debug.Log($"<color=green>Tween Move By Curve compelete</color>");
    }
}
