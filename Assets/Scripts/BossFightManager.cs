using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] private Slider sproutHealthUI;
    [SerializeField] private Slider voidHealthUI;
    [SerializeField] InMemoryVariableStorage variableStore;

    private void Update()
    {
        if (variableStore.TryGetValue("$sproutHealth", out float sproutHealth))
        {
            sproutHealthUI.value = sproutHealth / 100f;
        }
        
        if (variableStore.TryGetValue("$voidHealth", out float voidHealth))
        {
            voidHealthUI.value = voidHealth / 50f;
        }
    }
}
