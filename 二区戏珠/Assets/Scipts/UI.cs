using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _Player1HP;
    [SerializeField] private TMP_Text _Player2HP;
    void Start()
    {
        
    }

   
    void Update()
    {
       _Player1HP.text = "HP =" + GameController.Instance.player1.HP.ToString();
        if (GameController.Instance.player1.HP <= 0)
        {
            _Player1HP.text = "Defeated!";
        }
        _Player2HP.text = "HP =" + GameController.Instance.player2.HP.ToString();
        if (GameController.Instance.player2.HP <= 0)
        {
            _Player2HP.text = "Defeated!";
        }
    }
}
