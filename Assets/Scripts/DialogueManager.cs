using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour{

    private Queue<string> sentences;
    public TextMeshProUGUI nameTMProUGUI;
    public TextMeshProUGUI dialogueTMProUGUI;

    // Start is called before the first frame update
    void Start(){
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        //nameTMProUGUI.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueTMProUGUI.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueTMProUGUI.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
