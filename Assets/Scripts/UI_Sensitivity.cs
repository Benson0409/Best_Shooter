using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;

public class UI_Sensitivity : MonoBehaviour
{
    VisualElement root;
    RigidbodyFirstPersonController player;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        player = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();

        root.Q<Button>("low").clicked += () => 
        {
            Debug.Log("low");
            player.mouseLook.XSensitivity -= 0.1f;
            player.mouseLook.YSensitivity -= 0.1f;
            root.Q<Label>("sen").text = string.Format("{0:N2}", player.mouseLook.XSensitivity);
        };

        root.Q<Button>("up").clicked += () =>
        {
            Debug.Log("up");
            player.mouseLook.XSensitivity += 0.1f;
            player.mouseLook.YSensitivity += 0.1f;
            root.Q<Label>("sen").text = string.Format("{0:N2}", player.mouseLook.XSensitivity);
        };
    }
}
