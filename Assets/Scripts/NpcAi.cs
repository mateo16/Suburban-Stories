using UnityEngine;
using UnityEngine.AI;

public class NpcAi : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool GameIsPaused = false;
    private void Update()
    {
        
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.tag == "Player")
        {
            //Collider.GetComponent<DialogueManager>().StartDialogue(Dialogue dialogue);
            TriggerDialogue();
            Debug.Log("colisssiooooon");
        }
    }*/
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TriggerDialogue();
            Debug.Log("triggeeeeeeer");
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}