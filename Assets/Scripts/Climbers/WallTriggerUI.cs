using UnityEngine;
using UnityEngine.EventSystems;

public class WallTriggerUI : MonoBehaviour, IPointerEnterHandler
{
    [Tooltip("Arrastra aqu� tu GameObject que tiene ClimbersGame")]
    public ClimbersGame climbersGame;

    public void OnPointerEnter(PointerEventData eventData)
    {
        climbersGame.ResetToStart();
    }
}
