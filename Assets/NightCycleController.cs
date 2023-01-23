using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCycleController : MonoBehaviour
{
    [SerializeField] float nightCycleTimeInMinutes;
    [SerializeField] SpriteRenderer spriteRenderer;
    float numberOfSeconds;
    float currentSecond;
    int sign;
    float transperencyValueMax;
    float transperencyValueMin;
    float alphaValue;

    void Start()
    {
        sign = 1;
        currentSecond = 0;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        numberOfSeconds = nightCycleTimeInMinutes * 60;
        transperencyValueMax = .55f;
        transperencyValueMin = 0;
        StartCoroutine(RunEverySecond());


    }


    IEnumerator RunEverySecond()
    {   
        
        while (true)
        {
            float t = currentSecond / numberOfSeconds;
            alphaValue = Mathf.Lerp(transperencyValueMin, transperencyValueMax, t);
            spriteRenderer.color = new Color(1f, 1f, 1f, alphaValue);
            if (t > 1) { sign = -1; }
            if (t < 0) { sign = 1; }
            if (sign == 1) { currentSecond += .1f; }
            if (sign == -1) { currentSecond += -.1f; }
            yield return new WaitForSeconds(.1f);
        }
    }
}