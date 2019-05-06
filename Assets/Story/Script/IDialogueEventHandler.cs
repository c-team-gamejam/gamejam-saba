using UnityEngine.EventSystems;
public interface IDialogueEventHandler : IEventSystemHandler
{
    void OnContinue();
    void OnSkip();
}