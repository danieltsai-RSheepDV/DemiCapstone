using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int act1count = 0;

    public UnityEvent Act1Complete;

    public void IncrementAct1()
    {
        act1count++;
        if (act1count >= 4)
        {
            Act1Complete.Invoke();
        }
    }
}
