using UnityEngine;

public class UnityResourcesMeselesi : MonoBehaviour {
    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/MyPrefab");
        if (prefab != null)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.Log("Prefab not found");
        }
    }
}