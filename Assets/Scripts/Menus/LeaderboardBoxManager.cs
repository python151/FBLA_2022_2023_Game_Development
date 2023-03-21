using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Leaderboard_Item;

public class LeaderboardBoxManager : MonoBehaviour
{
    public GameObject template;
    // Start is called before the first frame update
    void Start()
    {
        int rank = 0;

        List<Leaderboard_Item> list = LeaderboardSaver.get_top_ten();
        foreach (Leaderboard_Item i in list) {
            rank++;

            GameObject item_transform = Instantiate(template, transform);
            item_transform.transform.position -= new Vector3(0, (rank-1)*45,0);
            
            LeaderboardItemDisplay display = item_transform.GetComponent<LeaderboardItemDisplay>();
            display.configure(i.username, i.score, rank);
        }

        template.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
