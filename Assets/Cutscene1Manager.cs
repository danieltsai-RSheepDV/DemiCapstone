using UnityEngine;
using Yarn.Unity;

public class Cutscene1Manager : MonoBehaviour
{
    [SerializeField] private Animator voidAnim;
    [SerializeField] private Animator sproutAnim;
    [SerializeField] private Animator textAnim;
    
    [YarnCommand("C1ShowVoid")]
    public void ShowVoidCutscene()
    {
        voidAnim.SetTrigger("Appear");
        textAnim.SetTrigger("Shake");
    }
    
    [YarnCommand("C1EndVoid")]
    public void EndVoidCutscene()
    {
        voidAnim.SetTrigger("Fade");
        sproutAnim.SetTrigger("Fade");
    }
}
