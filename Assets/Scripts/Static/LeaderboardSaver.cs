using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.IO;
using System;
using static Leaderboard_Item;

struct ListStruct
{
    public List<Leaderboard_Item> current_list;
    public ListStruct(List<Leaderboard_Item> list) {
        this.current_list = list;
    }
}

public class LeaderboardSaving
{
    public static LeaderboardSaving singleton;

    public readonly string location;
    public readonly int max_file_retries = 3;
    private List<Leaderboard_Item> current_list;

    public LeaderboardSaving(string _location) {
        this.location = _location;
        this.current_list = new List<Leaderboard_Item>();
        this._read();
    }

    private void _save() {
        string jsonString = JsonUtility.ToJson(new ListStruct(this.current_list));
        Debug.Log(jsonString);
        bool flag = false;
        for (int num_attempts = 0; num_attempts < max_file_retries && !flag; num_attempts++) {
            try {
                File.WriteAllText(this.location, jsonString);
                flag = true;
                return;
            } catch (Exception e) {
                Debug.Log($"LeaderboardSaving._save() failed on file {this.location} with exception {e}. Trying again for the {num_attempts+1} time.");
            }
        }

        Debug.Log($"LeaderboardSaving._save() failed on file {this.location}. Max retries exceeded.");
    }

    private void _read() {
        bool flag = false;
        string jsonString = "";
        for (int num_attempts = 0; num_attempts < max_file_retries && !flag; num_attempts++) {
            try {
                jsonString = File.ReadAllText(this.location);
                flag = true;
            } catch (Exception e) {
                Debug.Log($"LeaderboardSaving._read() failed on file {this.location} with exception {e}. Trying again for the {num_attempts+1} time.");
            }
        }
        
        if (flag) {
            this.current_list = JsonUtility.FromJson<ListStruct>(jsonString).current_list;
            Debug.Log(this.current_list);
        } else {
            Debug.Log($"LeaderboardSaving._read() failed on file {this.location}. Max retries exceeded.");
        }
    }

    private void _remove_user(string username) {
        for (int i = 0; i < current_list.Count; i++) { 
            if (current_list[i].username == username) {
                current_list.RemoveAt(i);
                return;
            }
        }
    }

    public List<Leaderboard_Item> get_top_ten() {
        Debug.Log("LeaderboardSaving.get_top_ten() has NOT been implemented yet, and you're calling it... *pouts agressively*");
        return this.current_list;
    }

    public int get_user_score(string username) {
        this._read();

        foreach (Leaderboard_Item i in current_list) {
            if (i.username == username) 
                return i.score;   
        }

        return -1;
    }

    public void _add_user(string username, int score) {
        Debug.Log($"User being added with username: {username} and score: {score}");
        Leaderboard_Item new_item = new Leaderboard_Item(username, score);
        this.current_list.Add(new_item);
        Debug.Log(this.current_list.Count);
        this._save();
    }
}

public class LeaderboardSaver : MonoBehaviour
{
    public string location_enter;
    public void Start() {
        LeaderboardSaving.singleton = new LeaderboardSaving(location_enter);
    }

    public static void add_user(string username, int score) {
        LeaderboardSaving.singleton._add_user(username, score);
    }
}