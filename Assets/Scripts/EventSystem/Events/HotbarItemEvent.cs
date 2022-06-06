using DapperDino.Items;
using UnityEngine;

namespace SuburbanStories.Events
{
    [CreateAssetMenu(fileName = "New Hotbar Item Event", menuName = "Game Events/Hotbar Item Event")]

    public class HotbarItemEvent : BaseGameEvent<HotbarItem> { }
}