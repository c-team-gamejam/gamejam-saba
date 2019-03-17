using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHASpawner : MonoBehaviour
{
    public int CurrentDHACount
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("DHA").Length;
        }
    }


    StateManager stateManager;

    [SerializeField] GameObject dhaObject;
    [SerializeField] float spawnLate = 3f;
    [SerializeField] int spawnLimit = 20;
    [SerializeField] float width = 2f;

    float elapsedTime;

    private void Awake()
    {
        stateManager = StateManager.Instance;
    }

    private void Update()
    {
        if (stateManager.m_StateMachine.m_State != StateManager.StateMachine.State.InTheGame || spawnLimit < CurrentDHACount)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        if(spawnLate < elapsedTime)
        {
            var dha = Instantiate(dhaObject, transform);
            dha.transform.localPosition = new Vector3(Random.Range(-width, width), transform.position.y, transform.position.z);
            elapsedTime = 0f;
        }
    }
}
