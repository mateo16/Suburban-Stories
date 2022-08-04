using System;
using UnityEngine.Events;
using DapperDino.Items;

namespace SuburbanStories.Events
{
    [Serializable] public class UnityHotbarItemEvent : UnityEvent<Item> { }
}

