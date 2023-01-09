using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChat : MonoBehaviour
{
    [SerializeField] private string [] listChat;
    [SerializeField] private Text textChat;
    [SerializeField] private GameObject panelChat;

    private int i = 0;

    private PlayerController _playerController;

    private bool read;

    private void Awake()
    {
        _playerController = new PlayerController();
    }

    private void Start()
    {
        panelChat.SetActive(false);
        _playerController.Land.Read.performed += _ => Read();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(read);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            read = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            read = false;
        }    
    }

    public void Read()
    {
        if (i == listChat.Length)
        {
            panelChat.SetActive(false);
            i = 0;
            return;
        }
        
        if (read)
        {
            panelChat.SetActive(true);
        }   
        
        if (panelChat.activeSelf)
        {
            textChat.text = listChat[i];
            i++;
        }
    }
    
    
}
