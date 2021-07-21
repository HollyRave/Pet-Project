using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PipesPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
            Debug.Log(_pool.Count + "Размер пулла");
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        foreach (var item in _pool)
        {
            Debug.Log(_pool.Count);
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
