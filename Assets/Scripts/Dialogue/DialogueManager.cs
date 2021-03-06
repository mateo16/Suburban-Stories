using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public GameObject dialogueBox;
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }
    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
        {
            if (sentences.Count==0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        IEnumerator TypeSentence (string sentence)
        {
            dialogueText.text = "";
            foreach(char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
        public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
            dialogueBox.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
}
