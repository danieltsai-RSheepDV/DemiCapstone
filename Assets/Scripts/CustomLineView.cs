using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CustomLineView : LineView
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] characterSprites;

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        characterImage.enabled = true;
        switch (dialogueLine.CharacterName)
        {
            case "Sprout":
                characterImage.sprite = characterSprites[0];
                break;
            case "Sunni":
                characterImage.sprite = characterSprites[1];
                break;
            default:
                characterImage.enabled = false;
                break;
        }
        
        
        base.RunLine(dialogueLine, onDialogueLineFinished);
        
        if(characterNameText.text != null)
            characterNameText.text = Regex.Match(characterNameText.text, @"^(.*?)(?=[\@]|$)").Value;
    }

    public override void InterruptLine(LocalizedLine dialogueLine, Action onInterruptLineFinished)
    {
        base.InterruptLine(dialogueLine, onInterruptLineFinished);
        
        characterImage.enabled = false;
        if(characterNameText.text != null)
            characterNameText.text = Regex.Match(characterNameText.text, @"^(.*?)(?=[\@]|$)").Value;
    }
}
