using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PubNubAPI;
using UnityEngine.UI;

/// Gets the global high score to display on screen.
public class GetHighScore : MonoBehaviour {

    public static int highScore = 0;

    // Start is called before the first frame update
    void Start () {
        // Use this for initialization
        PNConfiguration pnConfiguration = new PNConfiguration ();
        pnConfiguration.PublishKey = "pub-c-36e8fff3-a450-4b43-98be-5a14f10c69b4";
        pnConfiguration.SubscribeKey = "sub-c-68d3c0d8-9b58-11e9-9ac8-0ed882abeb26";
        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = Random.Range (0f, 999999f).ToString ();
        PubNubConnection.pubnub = new PubNub (pnConfiguration);
        Debug.Log (pnConfiguration.UUID);

        MyClass myFireObject = new MyClass ();
        myFireObject.test = "new user";
        string fireobject = JsonUtility.ToJson (myFireObject);
        PubNubConnection.pubnub.Fire ()
            .Channel ("my_channel")
            .Message (fireobject)
            .Async ((result, status) => {
                if (status.Error) {
                    Debug.Log (status.Error);
                    Debug.Log (status.ErrorData.Info);
                } else {
                    Debug.Log (string.Format ("Fire Timetoken: {0}", result.Timetoken));
                }
            });

        PubNubConnection.pubnub.SusbcribeCallback += (sender, e) => {
            SusbcribeEventEventArgs mea = e as SusbcribeEventEventArgs;
            if (mea.Status != null) { }
            if (mea.MessageResult != null) {
                Dictionary<string, object> msg = mea.MessageResult.Payload as Dictionary<string, object>;

                string[] scores = msg["score"] as string[];
                print(scores[0]);
                GetHighScore.highScore = int.Parse(scores[0]);

            }
            if (mea.PresenceEventResult != null) {
                Debug.Log ("In Example, SusbcribeCallback in presence" + mea.PresenceEventResult.Channel + mea.PresenceEventResult.Occupancy + mea.PresenceEventResult.Event);
            }
        };
        PubNubConnection.pubnub.Subscribe ()
            .Channels (new List<string> () {
                "my_channel2"
            })
            .WithPresence ()
            .Execute ();
    }
}