using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Button trigger_button, continue_button;

    private void Start()
    {
        trigger_button.gameObject.SetActive(true);
        continue_button.gameObject.SetActive(false);
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        trigger_button.gameObject.SetActive(false);
        continue_button.gameObject.SetActive(true);
    }
}
