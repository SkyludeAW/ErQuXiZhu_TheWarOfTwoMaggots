using UnityEngine;

public class 回血效果 : MonoBehaviour
{
   
    void Start()
    {
        GameController.Instance.player1.HP += 1;
    }

   
  
}
