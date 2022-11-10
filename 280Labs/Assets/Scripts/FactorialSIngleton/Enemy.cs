using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 playerLoc;

    private void Awake()
    {
        playerLoc = new Vector3(0, 0, 0);
    }

    void Update()
    {
        playerLoc = ShipSingleton.Instance.transform.position;
        if(ShipSingleton.Instance.health < 5)
        {
            //go into attack mode
        }
    }
}