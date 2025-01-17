using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Patients.Generation
{

    // [CreateAssetMenu(menuName = "Gameplay/Settings/PatientVisualRepository", fileName = "PatientVisualRepository")]
    public class PatientVisualRepositorySo : ScriptableObject
    {

        [SerializeField]
        private List<CustomKeyValue<DiseaseType, Sprite>> _diseaseSprites;

        [SerializeField]
        private List<Sprite> _skinSprites;

        [SerializeField]
        private List<CustomKeyValue<BeardType, Sprite>> _beardOutlines;

        [SerializeField]
        private List<CustomKeyValue<BeardType, List<Sprite>>> _beardSprites;

        [SerializeField]
        private List<CustomKeyValue<HairType, Sprite>> _hairOutlines;

        [SerializeField]
        private List<CustomKeyValue<HairType, List<Sprite>>> _hairSprites;

        public PatientVisualInfo GetRandomVisualForPatient(Patient patient)
        {
            var visual = new PatientVisualInfo();
            if (patient.Disease.HeavinessType == DiseaseHeavinessType.Heavy)
                visual.DiseaseSprite = _diseaseSprites
                    .FirstOrDefault(el => el.Key == patient.Disease.Type)?.Value;

            //2
            visual.SkinSprite = _skinSprites.ElementAt(Random.Range(0, _skinSprites.Count));

            var randomBeardLine = _beardOutlines.ElementAt(Random.Range(0, _beardOutlines.Count));
            visual.BeardLine = randomBeardLine.Value;
            var beardSprites = _beardSprites
                .FirstOrDefault(el => el.Key == randomBeardLine.Key)
                ?.Value;
            visual.BeardSprite = beardSprites?.ElementAt(Random.Range(0, beardSprites.Count));

            var randomHairLine = _hairOutlines.ElementAt(Random.Range(0, _beardOutlines.Count));
            visual.HairLine = randomHairLine.Value;
            var hairSprites = _hairSprites
                .FirstOrDefault(el => el.Key == randomHairLine.Key)
                ?.Value;
            visual.HairSprite = hairSprites?.ElementAt(Random.Range(0, hairSprites.Count));

            return visual;
        }
    }

}