using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationController : MonoBehaviour
{
    [SerializeField] private GameObject _swarmObjectPrefab;

    private GameObject _currentSwarmObject;

    private void Start()
    {
        SpawnNewSwarmObject();
    }

    private void Update()
    {
        if(_currentSwarmObject.transform.childCount == 0)
            SpawnNewSwarmObject();
    }

    public void SpawnNewSwarmObject()
    {
        _currentSwarmObject = Instantiate(_swarmObjectPrefab, transform.position, Quaternion.identity);
    }
}
