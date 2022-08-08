using DapperDino.Npcs.Occupations;
using TMPro;
using UnityEngine;

namespace DapperDino.Npcs
{
    public class NpcUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI npcNameText = null;
        [SerializeField] private TextMeshProUGUI npcGreetingText = null;
        [SerializeField] private GameObject occupationButtonPrefab = null;
        [SerializeField] private Transform occupationButtonHolder = null;

        public void SetNpc(Npc npc)
        {
            npcNameText.text = npc.Name;
            npcGreetingText.text = npc.GreetingText;

            foreach (Transform child in occupationButtonHolder) {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < npc.Occupations.Length; i++)
            {
                GameObject buttonInstance = Instantiate(occupationButtonPrefab, occupationButtonHolder);
                buttonInstance.GetComponent<OccupationButton>().Initialise(npc.Occupations[i]);
            }

        }

    }
}


