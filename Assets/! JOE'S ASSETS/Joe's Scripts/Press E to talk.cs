using PLAYERTWO.PlatformerProject;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    private NPC_Controller npc;

    /*[SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }*/

    private void Update()
    {
        player.CanMove = !InDialogue();
        if (InputHandler.Instance.InteractPressed && npc != null)
            npc.ActivateDialogue();

        /*if (body != null && !InDialogue())
        {
            float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                body.linearVelocity = new Vector2(0, verticalInput);
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                body.linearVelocity = new Vector2(horizontalInput, 0);
            else
                body.linearVelocity = new Vector2(0, 0);
        }
        */
    }

    private bool InDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("NPC") && collision.TryGetComponent(out NPC_Controller npc)) this.npc = npc;
    }

    private void OnTriggerExit(Collider other)
    {
        npc = null;
    }
}