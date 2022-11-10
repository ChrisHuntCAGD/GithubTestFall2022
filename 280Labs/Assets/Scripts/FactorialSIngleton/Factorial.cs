using UnityEngine;

public class Factorial : MonoBehaviour
{
    private void Awake()
    {
        print(fac(-1));
        print(fac(0));
        print(fac(5));
    }

    private int fac(int n)
    {
        if(n < 0)
        {
            return 0;
        }

        if(n == 0)
        {
            return 1;
        }

        int result = n * fac(n-1);
        return result;
    }
}