using UnityEngine;

public class ShipSingleton : MonoBehaviour
{
    public int health = 10;
    
    private static ShipSingleton _instance; //pretty standard to call a singleton _instance
    public static ShipSingleton Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
        }
    }
}