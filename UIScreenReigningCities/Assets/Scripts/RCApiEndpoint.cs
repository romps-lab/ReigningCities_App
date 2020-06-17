using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCApiEndpoint
{
    /* This is a singleton class */
    private static readonly Lazy<RCApiEndpoint> lazyInstance = new Lazy<RCApiEndpoint>(() => new RCApiEndpoint());
    public static RCApiEndpoint Instance { get { return lazyInstance.Value; } }
    private RCApiEndpoint()
    {
    }

    private string API_ENDPOINT = "http://192.168.1.207:3000/";
    private string STORE_ENDPOINT = "gameConfig";
    private string PING_ENDPOINT = "ping";
    private string UPDATE_PLAYER_ENTITIES = "updateEntities";

    public string fetchGameStoreConfig()
    {
        var client = new RestClient(API_ENDPOINT);
        var request = new RestRequest(STORE_ENDPOINT, Method.POST);
        var response = client.Post(request);
        return response.Content;
    }

    public string fetchPlayerResourceConfig(string email)
    {
        var client = new RestClient(API_ENDPOINT);
        var request = new RestRequest(PING_ENDPOINT, Method.POST);
        request.AddHeader("email", email);
        var response = client.Post(request);
        Debug.Log("Entities Returned from server : " + response.Content);
        return response.Content;
    }

    public void updatePlayerEntities()
    {
        string resources = Player.Instance.getSerelizedEntities();
        Dictionary<string, string> entities = new Dictionary<string, string>();
        entities.Add("entities", resources);

        var client = new RestClient(API_ENDPOINT);
        var request = new RestRequest(UPDATE_PLAYER_ENTITIES, Method.POST);
        request.AddHeader("email", Player.Instance.getEmail());
        request.RequestFormat = DataFormat.Json;
        request.AddBody(entities);
        var response = client.Post(request);
        Debug.Log("Doc Returned from server : " + response.Content);
    }

    public PlayerResource fetchResourceWithGPS(Vector2 gps)
    {
        string res = "{    \"gps\": {      \"x\": 1.2,      \"y\": 2.5,      \"normalized\": {        \"x\": 0.4327311,        \"y\": 0.901523054,        \"magnitude\": 1,        \"sqrMagnitude\": 1      },      \"magnitude\": 2.77308488,      \"sqrMagnitude\": 7.69    },    \"mainEntity\": {      \"category\": \"defence\",      \"name\": \"armyCamep\",      \"position\": {        \"x\": 1.2,        \"y\": 1.3,        \"z\": 1.4,        \"normalized\": {          \"x\": 0.5318907,          \"y\": 0.57621485,          \"z\": 0.620539069,          \"magnitude\": 1,          \"sqrMagnitude\": 1        },        \"magnitude\": 2.2561028,        \"sqrMagnitude\": 5.09      },      \"rotation\": {        \"x\": 1.2,        \"y\": 1.3,        \"z\": 1.4,        \"normalized\": {          \"x\": 0.5318907,          \"y\": 0.57621485,          \"z\": 0.620539069,          \"magnitude\": 1,          \"sqrMagnitude\": 1        },        \"magnitude\": 2.2561028,        \"sqrMagnitude\": 5.09      },      \"scale\": {        \"x\": 1.2,        \"y\": 1.3,        \"z\": 1.4,        \"normalized\": {          \"x\": 0.5318907,          \"y\": 0.57621485,          \"z\": 0.620539069,          \"magnitude\": 1,          \"sqrMagnitude\": 1        },        \"magnitude\": 2.2561028,        \"sqrMagnitude\": 5.09      }    },    \"supportingEntity\": [      {        \"category\": \"Wall\",        \"name\": \"wood\",        \"position\": {          \"x\": 1.2,          \"y\": 1.3,          \"z\": 1.4,          \"normalized\": {            \"x\": 0.5318907,            \"y\": 0.57621485,            \"z\": 0.620539069,            \"magnitude\": 1,            \"sqrMagnitude\": 1          },          \"magnitude\": 2.2561028,          \"sqrMagnitude\": 5.09        },        \"rotation\": {          \"x\": 1.2,          \"y\": 1.3,          \"z\": 1.4,          \"normalized\": {            \"x\": 0.5318907,            \"y\": 0.57621485,            \"z\": 0.620539069,            \"magnitude\": 1,            \"sqrMagnitude\": 1          },          \"magnitude\": 2.2561028,          \"sqrMagnitude\": 5.09        },        \"scale\": {          \"x\": 1.2,          \"y\": 1.3,          \"z\": 1.4,          \"normalized\": {            \"x\": 0.5318907,            \"y\": 0.57621485,            \"z\": 0.620539069,            \"magnitude\": 1,            \"sqrMagnitude\": 1          },          \"magnitude\": 2.2561028,          \"sqrMagnitude\": 5.09        }      }    ]  }";

        return JsonConvert.DeserializeObject<PlayerResource>(res);
    }

}
