using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReachDoor : MonoBehaviour
{
    public GameObject panel, joystick, jumpButton;
    public TMP_InputField inputField;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Reach Goal");
            panel.SetActive(true);
            joystick.SetActive(false);
            jumpButton.SetActive(false);
        }
    }

    public void SubmitButton() {
        if (inputField.text == "8")
        {
            Debug.Log("Jawaban benar");
            // SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            panel.SetActive(false);
            joystick.SetActive(true);
            jumpButton.SetActive(true);
        }
        else {
            Debug.Log("Jawaban salah");
            panel.SetActive(false);
            joystick.SetActive(true);
            jumpButton.SetActive(true);
        }
    }

}
