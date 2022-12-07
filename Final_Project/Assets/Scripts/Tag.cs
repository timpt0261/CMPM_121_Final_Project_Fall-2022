using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tag : MonoBehaviour
{
    public GameObject enemy;
    private float time_remaining;
    private bool tagged = false;

    public GameObject dialoguebox;
    public TextMeshProUGUI textCompnent;
    public string[] lines;
    public float textSpeed = 0.3f;


    private void Start()
    {
        textCompnent.text = string.Empty;
        dialoguebox.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            time_remaining = .10f;
            print("Time at start: " + time_remaining);
        }  
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            time_remaining -= Time.deltaTime;
            print("Time Remaining: " + time_remaining);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemy.tag)) 
        {
            if (time_remaining <= 0)
            {
                textCompnent.enabled = true;
                dialoguebox.SetActive(true);
                tagged = !tagged;
                StartCoroutine(TypeLine(tagged ? lines[0] : lines[1]));
                Stop();
            }
        }

    }


    IEnumerator TypeLine(string input)
    {
        textCompnent.text = string.Empty;
        foreach (char c in input.ToCharArray())
        {
            textCompnent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
        textCompnent.enabled = false;
        dialoguebox.SetActive(false);
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(2);
        StopAllCoroutines();
    }


}
