using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Player player;
    public UIController Ui;
    private void Start()
    {
       
    }
    private void Update()
    {
        OnPlayerHit();
        OnPlayerScoreChanged();
        OnPlayerDied();
        
    }
    public void OnPlayerHit()
    {
        if (player.golpeado == true)
        {
            Ui.UpdateVida();
            player.golpeado = false;
        }
    }
    public void OnPlayerScoreChanged()
    {
       if(player.Destruido == true)
        {
            Ui.UpdateScore();
            player.Destruido = false;
        }

    }
    public void OnPlayerDied()
    {
        if(player.Lives <= 0)
        {
            Ui.Reload();
        }
    }
}
