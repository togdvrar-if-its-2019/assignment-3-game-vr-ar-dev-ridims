using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionManager : MonoBehaviour
{
    private string cityName;
    public GameObject questionPanel;
    public TextMeshProUGUI title;
    public GameObject specifiqQuestion_One, specifiqQuestion_Two, specifiqQuestion_Three;
    public TMP_InputField inputField_1, inputField_2, inputField_3, inputField_4, inputField_5, inputField_6;
    public GameObject ci_1, ci_2, ci_3;
    public TextMeshProUGUI status;

    private void Start()
    {
        cityName = transform.gameObject.name;

        //Debug.Log("Castle name : " + cityName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            Debug.Log("Reach Goal");

            if (cityName == "castle_blue")
            {
                title.SetText("Castleblue");
                specifiqQuestion_One.SetActive(true);
                specifiqQuestion_Two.SetActive(false);
                specifiqQuestion_Three.SetActive(false);
                //inputField_1.text = "0";
                //inputField_2.text = "0";
            }
            else if (cityName == "castle_grey")
            {
                title.SetText("Castlegrey");
                specifiqQuestion_One.SetActive(false);
                specifiqQuestion_Two.SetActive(true);
                specifiqQuestion_Three.SetActive(false);
                //inputField_1.text = "0";
                //inputField_2.text = "0";
            }
            else if (cityName == "castle_red")
            {
                title.SetText("Castlered");
                specifiqQuestion_One.SetActive(false);
                specifiqQuestion_Two.SetActive(false);
                specifiqQuestion_Three.SetActive(true);
                //inputField_1.text = "0";
                //inputField_2.text = "0";
            }
            
            questionPanel.SetActive(true);

            Debug.Log("Show title " + title.text);
        }
    }

    public void SubmitButton()
    {
        Debug.Log("im clicked");
        if (title.text == "Castleblue" && inputField_1.text == "1" && inputField_2.text == "2")
        {
            Debug.Log(title.text + "x" + inputField_1.text + " x " + inputField_2.text);
            Debug.Log(title.text + "x" + "Jawaban benar");
            ci_1.gameObject.SetActive(true);

            questionPanel.SetActive(false);
        }
        else if (title.text == "Castlegrey" && inputField_3.text == "3" && inputField_4.text == "1")
        {
            Debug.Log(title.text + "x" + inputField_3.text + " x " + inputField_4.text);
            Debug.Log(title.text + "x" + "Jawaban benar");
            ci_2.gameObject.SetActive(true);
            questionPanel.SetActive(false);
        }
        else if (title.text == "Castlered" && inputField_5.text == "2" && inputField_6.text == "2")
        {
            Debug.Log(title.text + "x" + inputField_5.text + " x " + inputField_6.text);
            Debug.Log(title.text + "x" + "Jawaban benar");
            ci_3.gameObject.SetActive(true);
            questionPanel.SetActive(false);
        }
        else
        {
            Debug.Log(title.text + "x" + inputField_1.text + " x " + inputField_2.text);
            Debug.Log(title.text + "x" + "Jawaban salah");
            questionPanel.SetActive(false);
        }
    }

    public void BackButton()
    {
        questionPanel.SetActive(false);
    }
}
