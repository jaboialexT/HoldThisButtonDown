using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;


public class LeaderBoardController : MonoBehaviour
{
    public static LeaderBoardController instance;
    public InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 5;
    public Text[] Entries;
    private string truncName;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LootLockerSDKManager.StartGuestSession("Player",(response)=>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response)=>{
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i].member_id.Length >= 9) truncName = scores[i].member_id.Substring(0, 9);
                    else truncName = scores[i].member_id;
                    Entries[i].text = (scores[i].rank + ".   " +truncName+"   "+ scores[i].score);
                }
                if (scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = " ";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
    public void SubmitScore(int timePlaying)
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, timePlaying, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
