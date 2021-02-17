using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject jumpToPanel;
    Button button;

    private static event Action<ButtonController> disableOtherPanelsExcept;

    private void Awake()
    {
        disableOtherPanelsExcept += DisablePanels;
        button = GetComponent<Button>();
        button.onClick.AddListener(SetPanel);
    }

    private void SetPanel()
    {
        jumpToPanel.SetActive(true);
        //send a message to all buttonControllers that they need to be disabled, only if it is not this button controller
        disableOtherPanelsExcept(this);

    }

    private void DisablePanels(ButtonController buttonController)
    {
        if(buttonController != this)
        {
            jumpToPanel.SetActive(false);
        }
    }
}
