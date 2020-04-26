using DG.Tweening;
using DG.Tweening.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameTools
{
    public static void SetAnim(GameObject whoGoAnim,TweenCallback OnShowFinish = null)
    {
        //1.删除老的CanvasGroup
        var canvasGroup = whoGoAnim.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            GameObject.DestroyImmediate(canvasGroup);
        }
        //2.删除老的所有的动画
        var anims = whoGoAnim.GetComponents<DOTweenAnimation>();
        for (int i = 0; i < anims.Length; i++)
        {
            GameObject.Destroy(anims[i]);
        }
        //3.设置不同类型动画的初始值
        var anim = anims[0];
        var canvasGroupNew = whoGoAnim.AddComponent<CanvasGroup>();
        //*************4.设置动画类型animationType,target必须有，否则播不出来
        anim.animationType = DOTweenAnimationType.Fade;
        anim.target = canvasGroupNew;
        canvasGroupNew.alpha = 1;
        anim.endValueFloat = 0;
        ////设置曲线类型
        //anim.easeType = Ease.INTERNAL_Custom;
        //AnimationCurve easeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
        //anim.tween.SetEase(easeCurve);
        //4.创建动画
        anim.CreateTween();
        //5.设置回调
        if (OnShowFinish != null)
        {
            anim.tween.OnComplete(OnShowFinish);
        }
        //播放动画
        anim.tween.PlayForward();
        
    }
    public class TweenData
    {
        public bool autoPlay;
        public bool autoKill;
        public float Duration;
        public float Delay;
        public string id;
        public float endValueFloat;
        public Vector3 endValueVector3;
    }
    public static Tween SetAnimMoveByCurve(GameObject go, AnimationCurve easeCurve,TweenData tweendata, TweenCallback OnShowFinish = null)
    {
        //1.删除老的所有的动画
        var anims = go.GetComponents<DOTweenAnimation>();
        for (int i = 0; i < anims.Length; i++)
        {
            GameObject.Destroy(anims[i]);
        }
        //2.设置不同类型动画的初始值
        var anim = go.AddComponent<DOTweenAnimation>();
        //3.设置类型
        anim.animationType = DOTweenAnimationType.Move;
        //4.设置目标
        anim.target = go.transform;
        //5.设置参数
        anim.autoPlay = tweendata.autoPlay;
        anim.autoKill = tweendata.autoKill;
        anim.duration = tweendata.Duration;
        anim.delay = tweendata.Delay;
        anim.id = tweendata.id;
        anim.endValueV3 = tweendata.endValueVector3;
        
        //6.设置动画曲线
        anim.easeType = Ease.INTERNAL_Custom;
        anim.easeCurve = easeCurve;//CreateTween里边已经设置了if (easeType == Ease.INTERNAL_Custom) tween.SetEase(easeCurve);

        //7.创建动画
        anim.CreateTween();
        //8.设置回调
        if (OnShowFinish != null)
        {
            anim.tween.OnComplete(OnShowFinish);
        }
        return anim.tween;
    }
}
