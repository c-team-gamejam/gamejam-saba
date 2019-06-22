using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChoiceWindowPopper : MonoBehaviour
{
    [SerializeField] Button goodButton;
    [SerializeField] Button badButton;
    [SerializeField] PopupSystem popupSystem;

    TextManager textManager;
    /// <summary>popup materials</summary>
    List<PopupSystemMaterial> popupMaterials;

    private void Awake()
    {
        textManager = TextManager.Instance;
        popupMaterials = new List<PopupSystemMaterial>
        {
            new PopupSystemMaterial(OnPushGB,goodButton.gameObject.name,true),
            new PopupSystemMaterial(OnPushBB,badButton.gameObject.name,true),
        };
    }

    public void DispChoiceWindow()
    {
        popupSystem.Popup();
        foreach (var item in popupMaterials)
        {
            popupSystem.SubscribeButton(item);
        }
    }

    void OnPushGB()
    {
        textManager.PlayStory(TextManager.Subject.Good);
    }
    void OnPushBB()
    {
        textManager.PlayStory(TextManager.Subject.Bad);
    }
}
