using UnityEngine;
using System;
using System.Collections;
public class TrampolineManager : MonoBehaviour
{
    public int TrampolineTouchCount = 0;
    private GameObject player;
    private GameObject[] trampolines;
    public event Action TrampolineTouchCountEvent;
    private bool isOnTrampoline = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<MovementController>().GroundTouchEvent += CountReset;
        trampolines = GameObject.FindGameObjectsWithTag("Trampoline");
        for (int i = 0; i < trampolines.Length; i++) 
        {
            trampolines[i].GetComponent<TrampollineController>().TrampolineEvent += CountAdder;
        }
    }
    private void CountReset()
    {
        if (!isOnTrampoline)
        {
            TrampolineTouchCount = 0;
            TrampolineTouchCountEvent.Invoke();
        }
    }
    private void CountAdder()
    {
        TrampolineTouchCount++;
        isOnTrampoline = true;
        TrampolineTouchCountEvent.Invoke();
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        isOnTrampoline = false;
    }
}
