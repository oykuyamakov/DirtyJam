using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RootManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_RootPrefab;

    [SerializeField]
    private Vector3[] m_SpawnPoints = new Vector3[8];
    
    [Button]
    public void SpawnRoot()
    {
        
    }
}
