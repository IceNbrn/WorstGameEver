using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public enum SoundType
    {
        None,
        Dying,
        TakingDamage,
        WonGame
    }
    public static class Sound
    {
        public static void PlaySound(SoundType type)
        {
            if (type.Equals(SoundType.Dying))
                Console.Beep(245, 525);
            else if (type.Equals(SoundType.TakingDamage))
                Console.Beep(543, 125);
            else if (type.Equals(SoundType.WonGame))
            {
                Console.Beep(543, 125);
                Console.Beep(148, 125);
                Console.Beep(987, 125);
                Console.Beep(543, 125);
                Console.Beep(148, 125);
                Console.Beep(987, 125);
            }
            
        }
    }
    
}
