using System.Collections.Generic;
using System.Linq;
using Gameplay.Patients.Diseases;
using UnityEngine;

namespace Gameplay.Patients.Generation
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/PatientGenerationRepository", fileName = "PatientGenerationRepository")]
    public class PatientGenerationRepository : ScriptableObject
    {
        [SerializeField]
        private List<CustomKeyValue<Sex, List<string>>> _names = new()
        {
            new CustomKeyValue<Sex, List<string>>
            {
                Key = Sex.Female, Value = new List<string> { "Alice", "Molly", "Jane", "Mary" }
            },
            new CustomKeyValue<Sex, List<string>>
            {
                Key = Sex.Male, Value = new List<string> { "Harold", "Alex", "Bob", "John", "Mark", }
            }
        };

        [SerializeField]
        private List<DiseaseSO> _diseases;
        
        [SerializeField]
        public List<CustomKeyValue<PatientRank, int>> _rankChances = new()
        {
            new CustomKeyValue<PatientRank, int>(PatientRank.Assistant, 14),
            new CustomKeyValue<PatientRank, int>(PatientRank.Squire, 28),
            new CustomKeyValue<PatientRank, int>(PatientRank.Corporal, 42),
            new CustomKeyValue<PatientRank, int>(PatientRank.Sergeant, 56),
            new CustomKeyValue<PatientRank, int>(PatientRank.SeniorSergeant, 70),
            new CustomKeyValue<PatientRank, int>(PatientRank.Knight, 74),
            new CustomKeyValue<PatientRank, int>(PatientRank.Lieutenant, 78),
            new CustomKeyValue<PatientRank, int>(PatientRank.Captain, 82),
            new CustomKeyValue<PatientRank, int>(PatientRank.Major, 86),
            new CustomKeyValue<PatientRank, int>(PatientRank.Commander, 90),
            new CustomKeyValue<PatientRank, int>(PatientRank.Prior, 93),
            new CustomKeyValue<PatientRank, int>(PatientRank.Seneschal, 96),
            new CustomKeyValue<PatientRank, int>(PatientRank.Marshal, 99),
            new CustomKeyValue<PatientRank, int>(PatientRank.HighMarshal, 102),
            new CustomKeyValue<PatientRank, int>(PatientRank.GrandMarshal, 104),
        };

        public string GetRandomNameForSex(Sex sex)
        {
            var nameList = _names.FirstOrDefault(el => el.Key == sex)?.Value;
            return nameList.ElementAt(Random.Range(0, nameList.Count));
        }

        public DiseaseSO GetRandomDisease()
        {
            return _diseases.ElementAt(Random.Range(0, _diseases.Count));
        }

        public DiseaseSO GetDiseaseByType(DiseaseType diseaseType)
        {
            return _diseases.FirstOrDefault(el => el.Type == diseaseType);
        }

        public List<DiseaseSO> GetAllDiseases()
        {
            return _diseases;
        }

        public PatientRank GetRandomRank()
        {
            int random = Random.Range(0, _rankChances[^1].Value);
            for (int i = 0; i < _rankChances.Count; i++)
            {
                if (random <= _rankChances[i].Value)
                    return _rankChances[i].Key;
            }
            
            return _rankChances[0].Key;
        }
        
        
    }
}