using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum Elemental
{
    Fire=0,
    Water=1,
    Grass=2,
    Ice=3,
    Electric=4,
    Dark=5
}
public static  class ElementalManager
{
    public static  float ElementalEffectiveRatio( Elemental takerElemental,Elemental dealerElemental )
    {
        float ratio = 1;
        // water
        if (takerElemental == Elemental.Water)
        {
            switch (dealerElemental)
            {
                case Elemental.Fire:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Grass:
                    {
                        ratio = 2;
                        break;
                    }
                default:
                    {
                        ratio = 1;
                        break;
                    }
            }
        }
        //fire
        if (takerElemental == Elemental.Fire)
        {
            switch (dealerElemental)
            {
                case Elemental.Grass:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Ice:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Water:
                    {
                        ratio = 2;
                        break;
                    }
                default:
                    {
                        ratio = 1;
                        break;
                    }
            }
        }
        //grass
        if (takerElemental == Elemental.Grass)
        {
            switch (dealerElemental)
            {
                case Elemental.Water:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Electric:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Ice:
                    {
                        ratio = 2;
                        break;
                    }
                case Elemental.Fire:
                    {
                        ratio = 2;
                        break;
                    }
                default:
                    {
                        ratio = 1;
                        break;
                    }
            }
        }
        //ice
        if (takerElemental == Elemental.Ice)
        {
            switch (dealerElemental)
            {
                case Elemental.Grass:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Fire:
                    {
                        ratio = 2;
                        break;
                    }
                default:
                    {
                        ratio = 1;
                        break;
                    }
            }
        }
        //electric
        if (takerElemental == Elemental.Electric)
        {
            switch (dealerElemental)
            {
                case Elemental.Water:
                    {
                        ratio = 0.5f;
                        break;
                    }
                case Elemental.Grass:
                    {
                        ratio = 2;
                        break;
                    }
                default:
                    {
                        ratio = 1;
                        break;
                    }
            }
        }
        return ratio;
    }

}    
