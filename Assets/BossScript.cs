using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static System.TimeZoneInfo;

public class BossScript : MonoBehaviour
{
    private enum BossState
    {
        Idle,
        Circles,
        Spikes,
        GunsPhase,
        Transition
    }
    private Array bossStates = Enum.GetValues(typeof(BossState));
    private BossState currentState = BossState.Idle;
    [SerializeField]
    private GameObject circle, spikes, gunsHolderObject,colectible;
    private Component[] guns;
    private Vector2 spawnArea = new Vector2(80f, 60f);
    private float phaseTimer = 0f; // Stoper licz¹cy ile mine³o czasu danej fazy
    private float phaseEndTime = 0f; // Czas trwania fazy

    void Start()
    {
        guns = gunsHolderObject.GetComponentsInChildren<gunControllerVariant2>();
    }

    void Update()
    {
        switch (currentState)
        {
            case BossState.Idle:
                HandleTransition(5f);
                break;
            case BossState.Circles:
                HandleCircles();
                break;
            case BossState.Spikes:
                HandleSpikes();
                break;
            case BossState.GunsPhase:
                HandleGunsPhase();
                break;
            case BossState.Transition:
                HandleTransition(phaseEndTime);
                break;
        }
    }
    private void HandleTransition(float transitonTime)
    {
        phaseTimer += Time.deltaTime;
        if (phaseTimer >= transitonTime + 1)
        {
            phaseTimer = 0f;
            while (currentState == BossState.Idle || currentState == BossState.Transition)
            {
                System.Random random = new System.Random();
                currentState = (BossState)bossStates.GetValue(random.Next(bossStates.Length));
            }
            for (int i = 0; i < 3; i++)
            {
                Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 1f, UnityEngine.Random.Range(-spawnArea.y / 3, spawnArea.y / 3));
                GameObject colectibleClone = Instantiate(colectible, randomPosition, Quaternion.identity);
            }
        }
    }
    private void HandleCircles() {
        phaseEndTime = 8f;
        for (int i = 0; i < 9; i++)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 0f, UnityEngine.Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
            GameObject circleClone = Instantiate(circle, randomPosition, Quaternion.identity);
            circleClone.GetComponent<circleScript>().Initialize(10f, 2f, phaseEndTime);
        }
        currentState = BossState.Transition;
    }
    private void HandleSpikes()
    {
        phaseEndTime = 5f;
        spikes.GetComponent<Animation>().Play();
        currentState = BossState.Transition;
    }
    private void HandleGunsPhase()
    {
        Invoke("gunsOff", phaseEndTime);
        phaseEndTime = 7f;
        foreach (gunControllerVariant2 gun in guns)
        {
            gun.enabled = true; 
        }
        currentState = BossState.Transition;
        
    }
    private void gunsOff()
    {
        foreach (gunControllerVariant2 gun in guns)
        {
            Debug.Log("wy³acz strza³");
            gun.enabled = false;
        }
    }
}
