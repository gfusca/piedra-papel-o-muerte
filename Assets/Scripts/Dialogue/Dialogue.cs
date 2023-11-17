using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textComponent;
    public Image nextImageBtn;
    public GameObject panel;

    public string[] lines;
    public float textSpeed;
    public DialogueOption[] dialogueOptions;

    private int index;

    // Start is called before the first frame update
    void Start() {
        textComponent.text = string.Empty;
        panel.GetComponent<Image>().enabled = false;

        // use this in scene example
        // StartDialogue(lines);
        // Debug.Log(dialogueOptions);
    }

    // Update is called once per frame
    void Update() {
        bool endOfLine = textComponent.text == lines[index];

        nextImageBtn.enabled = endOfLine;

        if ((Input.GetMouseButtonDown(0)) && endOfLine) {
            // move to next line
            NextLine();
        } else if (Input.GetMouseButtonDown(0)  && !endOfLine) {
            // speed up text animation and just show final text
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    public void StartDialogue(string[] dialogueLines) {
        panel.SetActive(true);
        panel.GetComponent<Image>().enabled = true;
        index = 0;
        lines = dialogueLines;
        StopAllCoroutines();
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    
    public void StopDialogue() {
        panel.SetActive(false);
        panel.GetComponent<Image>().enabled = false;
        index = 0;
        StopAllCoroutines();
        textComponent.text = string.Empty;
    }
    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            gameObject.SetActive(false);
        }
    }
}
