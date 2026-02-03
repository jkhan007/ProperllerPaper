using UnityEngine;
using TMPro;

public class LeaderBoardScoreContainer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI playerPositionTxt;
    [SerializeField]
    private TextMeshProUGUI playerNameLeaderboardTxt;
    [SerializeField]
    private TextMeshProUGUI playerLeaderBoardScoreTxt;

    private int leaderBoardScoreCtnIndex;


    public TextMeshProUGUI PlayerPositionTxt => playerPositionTxt;
    public TextMeshProUGUI PlayerNameLeaderboardTxt => playerNameLeaderboardTxt;
    public TextMeshProUGUI PlayerLeaderBoardScoreTxt => playerLeaderBoardScoreTxt;


    public int LeaderBoardScoreCtnIndex
    {
        get { return leaderBoardScoreCtnIndex; }
        set
        {
            leaderBoardScoreCtnIndex = value;
        }
    }
}
