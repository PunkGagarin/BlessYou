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
    }
}