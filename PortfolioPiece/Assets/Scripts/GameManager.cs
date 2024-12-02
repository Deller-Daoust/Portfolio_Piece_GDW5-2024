using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
