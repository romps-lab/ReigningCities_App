using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Player
{
    /* This is a singleton class */
    private static readonly Lazy<Player> lazyInstance = new Lazy<Player>(() => new Player());
    public static Player Instance { get { return lazyInstance.Value; } }
    private Player()
    {
    }


    private string email;
    private List<PlayerResource> constructedEntities;

    public void setupPlayerResources(string playerResourceConfig)
    {
        constructedEntities = JsonConvert.DeserializeObject<List<PlayerResource>>(playerResourceConfig);
        string json = JsonConvert.SerializeObject(constructedEntities , new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                    }
                                                  );
        Debug.Log("Serelized player entities : " + json);
    }

    public string getSerelizedEntities()
    {
        return JsonConvert.SerializeObject(constructedEntities, new JsonSerializerSettings
                                            {
                                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                            }
                                          );
    }

    public void setEamil(string email)
    {
        this.email = email;
    }

    public string getEmail()
    {
        return this.email;
    }

    public PlayerResource getResource(Vector2 gps)
    {
        PlayerResource resource = null;

        foreach(PlayerResource entity in constructedEntities)
        {
            if(entity.gps.x == gps.x && entity.gps.y == gps.y)
            {
                resource = entity;
                break;
            }
        }

        return resource;
    }

}


public class PlayerResource
{
    public Vector2 gps;
    public Entity mainEntity;
    public List<Entity> supportingEntity;

    public PlayerResource()
    {
        supportingEntity = new List<Entity>();
    }

    public class Entity
    {
        public string category;
        public string name;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }
}
