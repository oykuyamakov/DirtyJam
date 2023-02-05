using System;
using System.Collections.Generic;
using BeatStuff;
using BeatStuff.EventImplementations;
using DirectionImplementation;
using Events;
using Pooling;
using RootStuff;
using Sirenix.OdinInspector;
using UnityCommon.Runtime.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

public class RootManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_RootPrefab;
    
    [SerializeField]
    private Transform[] m_SpawnPoints = new Transform[8];

    public static ObjectPool<Root> RootPool = new ObjectPool<Root>(50);

    public static Dictionary<int, DirectionName> BeatDirectionDictionary;
    
    private Dictionary<DirectionName, Vector3> m_SpawnPositionDictionary;

    private Dictionary<DirectionName, Vector3> m_SpawnDirectionDictionary;
    
    private TimedAction m_RandomSpawnAction;

    private void Start()
    {
        m_SpawnPositionDictionary = new Dictionary<DirectionName, Vector3>()
        {
            [DirectionName.S] = m_SpawnPoints[5].position,
            [DirectionName.D] = m_SpawnPoints[7].position,
            [DirectionName.W] = m_SpawnPoints[1].position,
            [DirectionName.A] = m_SpawnPoints[3].position,
            [DirectionName.W | DirectionName.A] = m_SpawnPoints[2].position,
            [DirectionName.W | DirectionName.D] = m_SpawnPoints[0].position,
            [DirectionName.S | DirectionName.A] = m_SpawnPoints[4].position,
            [DirectionName.S | DirectionName.D] = m_SpawnPoints[6].position,
        };
        
        m_SpawnDirectionDictionary = new Dictionary<DirectionName, Vector3>()
        {
            [DirectionName.S] = Vector3.up,
            [DirectionName.D] = Vector3.left,
            [DirectionName.W] = Vector3.down,
            [DirectionName.A] = Vector3.right,
            [DirectionName.W | DirectionName.A] = new Vector3(1, -1, 0),
            [DirectionName.W | DirectionName.D] = new Vector3(-1, -1, 0),
            [DirectionName.S | DirectionName.A] = new Vector3(1, 1, 0),
            [DirectionName.S | DirectionName.D] = new Vector3(-1, 1, 0),
        };

        BeatDirectionDictionary = new Dictionary<int, DirectionName>();

        LevelCreator.GetBeatData(LevelCreator.W, DirectionName.W);
        LevelCreator.GetBeatData(LevelCreator.A, DirectionName.A);

        // m_RandomSpawnAction = new TimedAction(RandomlySpawnRoots, 0f, 1f);
        GEM.AddListener<OnBeatEvent>(OnBeat);
    }

    private void Update()
    {
        // m_RandomSpawnAction.Update(Time.deltaTime);
    }

    [Button]
    public void SpawnRoot(DirectionName directionName)
    {
        var root = RootPool.GetPoolable(m_RootPrefab, null).Get();
        root.transform.position = m_SpawnPositionDictionary[directionName];
        
        var moveToTheBeat = root.GetComponent<MoveToTheBeat>();
        moveToTheBeat.Steps = 1f;
        moveToTheBeat.DirectionName = directionName;
        moveToTheBeat.MoveDir = m_SpawnDirectionDictionary[directionName];

        switch (directionName)
        {
            case DirectionName.A:
                root.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case DirectionName.D:
                root.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case DirectionName.S:
                root.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case DirectionName.W:
                root.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case DirectionName.W | DirectionName.A:
                root.transform.rotation = Quaternion.Euler(0, 0, -45);
                break;
            case DirectionName.S | DirectionName.A:
                root.transform.rotation = Quaternion.Euler(0, 0, 45);
                break;
            case DirectionName.W | DirectionName.D:
                root.transform.rotation = Quaternion.Euler(0, 0, 225);
                break;
            case DirectionName.S | DirectionName.D:
                root.transform.rotation = Quaternion.Euler(0, 0, 135);
                break;
        }
        
        root.Init();
    }

    private void RandomlySpawnRoots()
    {
        var values = (DirectionName[])Enum.GetValues(typeof(DirectionName));
        DirectionName randomValue = (DirectionName) values[Random.Range(0, values.Length)];
        SpawnRoot(randomValue);
    }

    private int m_Beat = 0;
    
    private void OnBeat(OnBeatEvent evt)
    {
        if(evt.Steps != 1f)
            return;

        // RandomlySpawnRoots();
        m_Beat++;

        if (BeatDirectionDictionary.ContainsKey(m_Beat))
        {
            Debug.Log(m_Beat);
            SpawnRoot(BeatDirectionDictionary[m_Beat]);
        }
    }
}
