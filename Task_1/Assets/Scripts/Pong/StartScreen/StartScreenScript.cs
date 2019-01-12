using UnityEngine;
using UnityEngine.SceneManagement;
using PongV2;

public class StartScreenScript : MonoBehaviour
{
    public void TwoPlayer()
    {
        Side.PlayersCount = 1;
        Application.LoadLevel(1);
    }

    public void FourPlayer()
    {
        Side.PlayersCount = 2;
        Application.LoadLevel(1);
    }

    public void Setting()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
