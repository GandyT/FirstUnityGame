using UnityEngine;
using System;

public class DiscordController : MonoBehaviour
{
    public long CLIENT_ID;
    Discord.Discord discord;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LOADING RPC");
        discord = new Discord.Discord(CLIENT_ID, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "Feels so clean like a money machine!",
            State = "SinglePlayer",
            Assets = {
                LargeImage = "red"
            }
        };

        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("RPC WORKS");
            }
            else
            {
                Debug.Log("RPC FAILED");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
