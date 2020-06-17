using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARScreenHelper
{
    /* This is a singleton class */
    private static readonly Lazy<ARScreenHelper> lazyInstance = new Lazy<ARScreenHelper>(() => new ARScreenHelper());
    public static ARScreenHelper Instance { get { return lazyInstance.Value; } }
    private ARScreenHelper()
    {
    }


    public PlayerResource duplicateResource;
    public bool canModify;

    public void reset()
    {
        duplicateResource = null;
        canModify = false;
    }

    public void generateDuplicateResource(string category , string mainEntityName)
    {
        PlayerResource.Entity entity = new PlayerResource.Entity();
        entity.category = category;
        entity.name = mainEntityName;

        duplicateResource = new PlayerResource();
        duplicateResource.mainEntity = entity;
        canModify = true;
    }

    public void generateDuplicateResource(Vector2 gps , bool isModifiable)
    {
        canModify = isModifiable;

        if (isModifiable)
        {
            duplicateResource = Player.Instance.getResource(gps);
        }
        else
        {
            duplicateResource = RCApiEndpoint.Instance.fetchResourceWithGPS(gps);
        }
    }

}
