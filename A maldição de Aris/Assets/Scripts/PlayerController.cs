using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool triggered;
    string obj;
    float Speed = 4;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0;

    private int count = 0;

    public Font font;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }


    void Update()
    {
        Movement();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        TimeCounter.timer = 180f;
        SceneManager.LoadScene("Level2");
        yield return 0;
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Level3");
        yield return 0;
    }

    void Movement()
    {
        
        Vector3 directionVector = new Vector3(0, Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            Speed = 10;
        if (Input.GetKey(KeyCode.S))
            Speed = 4;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 1 * Speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.X))
        {
            transform.Rotate(0, -1, 0);
        }



        if (directionVector != Vector3.zero)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;

            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);

            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;

            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }

   



        // Apply the direction to the CharacterMotor
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndLevel1") || other.gameObject.CompareTag("EndLevel2") || other.gameObject.CompareTag("Question1") || other.gameObject.CompareTag("Question2") || other.gameObject.CompareTag("Question3")
            || other.gameObject.CompareTag("Question4") || other.gameObject.CompareTag("Question5") || other.gameObject.CompareTag("Question6")
            || other.gameObject.CompareTag("Question7") || other.gameObject.CompareTag("Question8") || other.gameObject.CompareTag("Question9")
            || other.gameObject.CompareTag("Question10") || other.gameObject.CompareTag("Question11") || other.gameObject.CompareTag("Question12")
            || other.gameObject.CompareTag("Question13") || other.gameObject.CompareTag("Question14") || other.gameObject.CompareTag("Question15")
            || other.gameObject.CompareTag("Question16"))
        {
            triggered = true;
            obj = other.gameObject.tag;

            if (obj == "EndLevel1")
                Destroy(other.gameObject);
            if (obj == "EndLevel2")
                Destroy(other.gameObject);
        }
    }

    private void OnGUI()
    {
        

        GUIStyle myStyle = new GUIStyle();
        // Texture2D tex = new Texture2D(Screen.width, 200, TextureFormat.ARGB32, false);

        //tex.SetColor(new Color(0, 0, 0, 0.5f));//r,g,b,a 
        //tex.Apply();

        //myStyle.normal.background = tex;
        myStyle.normal.textColor = Color.white;
        

        string msg = "";

        if (triggered) //The dialogue starts.
        {
            if (obj.CompareTo("Question1") == 0)
            { 
                msg = "Pergunta:\n";
                msg += "De quem é a famosa frase 'Penso, logo existo'?\n";
                msg += "A) Descartes\nB) Sócrates";
            }

            if (obj.CompareTo("Question2") == 0)
            {
                msg = "Pergunta:\n";
                msg += "De onde é a invenção do chuveiro elétrico?\n";
                msg += "A) França\nB) Inglaterra\nC) Brasil";
            }

            if (obj.CompareTo("Question3") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Quais o menor e o maior país do mundo?\n";
                msg += "A) Vaticano e Rússia\nB) Nauru e China\nC) Mônaco e Canadá";
            }

            if (obj.CompareTo("Question4") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual o nome do presidente do Brasil que ficou conhecido como Jango?\n";
                msg += "A) Jânio Quadros\nB) João Goulart";
            }

            if (obj.CompareTo("Question5") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Quanto tempo a luz do Sol demora para chegar à Terra?\n";
                msg += "A) 12 Minutos\nB) 8 Minutos\nC) Segundos";
            }

            if (obj.CompareTo("Question6") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Em que período da pré-história o fogo foi descoberto?\n";
                msg += "A) Neolítico\nB) Paleolítico\nC) Idade dos Metais";
            }

            if (obj.CompareTo("Question7") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Júpiter e Plutão são os correlatos romanos de quais deuses gregos?\n";
                msg += "A) Zeus e Hades\nB) Ares e Hermes"; //A) Zeus e Hades
            }

            if (obj.CompareTo("Question8") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Que líder mundial ficou conhecida como “Dama de Ferro?\n";
                msg += "A) Angela Merkel\nB) Margaret Thatcher"; //B)Margaret Thatcher
            }

            if (obj.CompareTo("Question9") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual a nacionalidade de Che Guevara?\n";
                msg += "A) Cubano\nB) Peruano\nC) Argentino"; //C) Argentino
            }

            if (obj.CompareTo("Question10") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual a velocidade da luz?\n";
                msg += "A) 300 000 000 m/s\nB) 299 792 458 m/s\nC) 199 792 458 m/s"; //B) 299 792 458 m/s
            }

            if (obj.CompareTo("Question11") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Em qual local da Ásia o português é língua oficial?\n";
                msg += "A) Moçambique\nB) Macau\n"; // B) Macau
            }

            if (obj.CompareTo("Question12") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual destes países é transcontinental?\n"; // A) Rússia
                msg += "A) Rússia\nB) Tanzânia\nC) Istambul";
            }

            if (obj.CompareTo("Question13") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual foi o recurso utilizado inicialmente pelo homem para explicar a origem das coisas?\n";
                msg += "A) A Filosofia\nB) A Mitologia"; //C) A Mitologia
            }

            if (obj.CompareTo("Question14") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual era o nome de Aleijadinho?\n";
                msg += "A) Alexandrino Francisco Lisboa\nB) Francisco Antônio Lisboa\nC) Antônio Francisco Lisboa"; // C) Antônio Francisco Lisboa
            }

            if (obj.CompareTo("Question15") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual o nome do cientista que descobriu o processo de pasteurização e a vacina contra a raiva?\n";
                msg += "A) Blaise Pascal\nB) Louis Pasteurs\nC) Antoine Lavoisier"; //B) Louis Pasteurs
            }

            if (obj.CompareTo("Question16") == 0)
            {
                msg = "Pergunta:\n";
                msg += "Qual desses filmes foi baseado na obra de Shakespeare?\n";
                msg += "A) Muito Barulho por Nada (2012)\nB) Capitães de Areia (2011)\nC)Capitães de Areia (2011)"; //A) Muito Barulho por Nada (2012)
            }

            if (obj.CompareTo("EndLevel1") == 0)
            {
                msg = "Você está mais perto de salvar seu filho.\nPrimeiro nível completado com sucesso!";
               StartCoroutine(Wait());
            }

            if (obj.CompareTo("EndLevel2") == 0)
            {
                msg = "Você está mais perto de salvar seu filho.\nSegundo nível completado com sucesso!";
                StartCoroutine(Wait2());
            }


            var w = 0.3f; // proportional width (0..1)
            var h = 0.2f; // proportional height (0..1)

            {
                Rect rect = new Rect();
                rect.x = (Screen.width * (1 - w)) / 2;
                rect.y = 1;
                rect.width = Screen.width * w;
                rect.height = Screen.height * h;

                myStyle.alignment = TextAnchor.UpperCenter;
                myStyle.font = font;
                myStyle.fontSize = 30;
                GUI.Label(rect, msg, myStyle);
            }

            
            msg = "";
        }
    }

    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("EndLevel1") || other.gameObject.CompareTag("EndLevel2") || other.gameObject.CompareTag("Question1") || other.gameObject.CompareTag("Question2") || other.gameObject.CompareTag("Question3")
            || other.gameObject.CompareTag("Question4") || other.gameObject.CompareTag("Question5") || other.gameObject.CompareTag("Question6")
            || other.gameObject.CompareTag("Question7") || other.gameObject.CompareTag("Question8") || other.gameObject.CompareTag("Question9")
            || other.gameObject.CompareTag("Question10") || other.gameObject.CompareTag("Question11") || other.gameObject.CompareTag("Question12") 
            || other.gameObject.CompareTag("Question13") || other.gameObject.CompareTag("Question14") || other.gameObject.CompareTag("Question15")
            || other.gameObject.CompareTag("Question16"))
        {
            triggered = false;
        }

    }


}
   