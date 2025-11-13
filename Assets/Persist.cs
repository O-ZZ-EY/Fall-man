using UnityEngine;

public class Persist : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.name + " will persist across scenes!");

    }
}
