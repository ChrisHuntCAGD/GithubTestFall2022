using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strategy : MonoBehaviour
{
    //1st we define the delegate
    //a delegate is just a variable that can hold 1 to many functions

    public delegate void ActionDelegate();

    //Create an instance of our delegate - named act
    public ActionDelegate act;

    //next some placeholder functions for Attack, Wait, Flee
    //These are just empty examples
    //In reality, these would determine how our enemy acts in each case

    public void Attack()
    {
        print("attacking");
    }

    public void Wait()
    {
        print("waiting");
    }

    public void Flee()
    {
        print("fleeing");
    }

    //we need an initial strategy
    private void Awake()
    {
        act = Wait;
    }

    //if a ship singleton comes within 100 meters of this agent
    //it will switch its strategy to Attack
    //by replacing the target function of the act delegate
    private void Update()
    {
        Vector3 sPos = ShipSingleton.Instance.transform.position;
        if((sPos - this.transform.position).magnitude < 100)
        {
            act = Attack;
        }

        //regardless of which strategy is selected act is called to execute whatever function is the delegate
        if(act != null)
        {
            act();
        }
    }
}