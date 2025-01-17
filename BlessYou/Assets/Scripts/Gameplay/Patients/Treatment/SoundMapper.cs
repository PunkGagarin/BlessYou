using Audio;
using Gameplay.Inventory;

namespace Gameplay.Treatment
{
    public class SoundMapper
    {

        public static GameAudioType GetSoundForInstrument(InstrumentType instrumentType) => instrumentType switch
        {

            InstrumentType.Ticks => GameAudioType.Ticks,
            InstrumentType.Expander => GameAudioType.Expander,
            InstrumentType.Hammer => GameAudioType.Hammer,
            InstrumentType.HookNeedle => GameAudioType.HookNeedle,
            InstrumentType.Scalpel => GameAudioType.Scalpel,
            InstrumentType.Saw => GameAudioType.Saw,
            _ => GameAudioType.None
        };

        public static GameAudioType GetSoundForMedicament(MedicamentType medicamentType) => medicamentType switch
        {

            MedicamentType.BasilDrink => GameAudioType.Liquid,
            MedicamentType.LicoriceRootTincture => GameAudioType.Liquid,
            MedicamentType.HolyWater => GameAudioType.Liquid,
            MedicamentType.SageDrink => GameAudioType.Liquid,
            MedicamentType.AloeVeraOil => GameAudioType.Oil,
            MedicamentType.PlantainOintment => GameAudioType.Oil,
            MedicamentType.ToadPowder => GameAudioType.Powder,
            MedicamentType.CalendulaPowder => GameAudioType.Powder,
            MedicamentType.Bandage => GameAudioType.Bandage,
            _ => GameAudioType.None
        };
    }
}