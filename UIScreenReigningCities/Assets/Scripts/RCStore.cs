using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCStore
{

    /* This is a singleton class */
    private static readonly Lazy<RCStore> lazyInstance = new Lazy<RCStore>(() => new RCStore());
    public static RCStore Instance { get { return lazyInstance.Value; } }
    private RCStore()
    {
    }

    private Store rcStore;

    public void setupStore(string storeConfig)
    {
        rcStore = JsonConvert.DeserializeObject<Store>(storeConfig);
        string str = JsonConvert.SerializeObject(rcStore);
        Debug.Log(str);
    }

    public List<string> getMainCategories()
    {
        List<string> keys = new List<string>();
        foreach (KeyValuePair<string, List<Store.Item>> entries in rcStore.mainEntities)
        {
            keys.Add(entries.Key);
        }
        return keys;
    }

    public List<string> getMainItemsName(string category)
    {
        List<Store.Item> items = new List<Store.Item>();
        rcStore.mainEntities.TryGetValue(category, out items);

        List<string> itemNames = new List<string>();
        foreach (Store.Item item in items)
        {
            itemNames.Add(item.name);
        }

        return itemNames;
    }

    public List<string> getMainItemsDisplayName(string category)
    {
        List<Store.Item> items = new List<Store.Item>();
        rcStore.mainEntities.TryGetValue(category, out items);

        List<string> itemNames = new List<string>();
        foreach (Store.Item item in items)
        {
            itemNames.Add(item.displayName);
        }

        return itemNames;
    }


    private class Store
    {

        public Dictionary<string, List<Item>> mainEntities;
        public Dictionary<string, List<Item>> supportingEntities;

        public Store()
        {
            mainEntities = new Dictionary<string, List<Item>>();
            supportingEntities = new Dictionary<string, List<Item>>();
        }

        public class Item
        {
            public string displayName;
            public string name;
            public string prefabRef;
        }
    }

}
