using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esta clase es la base de todos los personajes, tanto jugador como enemigos.

[System.Serializable]
public abstract class BaseCharacter
{
    [System.Serializable]
    public struct Stats
    {
        public float DMG;
        public float LIFE;
        public float LIFE_CAP;
        public float SPEED;
        public float RANGE;
        public float EXPERIENCE;
        public float EXPERIENCE_CAP;
    }

    [SerializeField]
    protected Stats _myStats;

    public void ReceiveDmg(float p_damageReceived)
    {
        _myStats.LIFE -= p_damageReceived;
    }

    public float GetSpeed() { return _myStats.SPEED; }
    public float GetDamage() { return _myStats.DMG; }
    public float GetLife() { return _myStats.LIFE; }
    public float GetCap() { return _myStats.LIFE_CAP; }
    public float GetRange() { return _myStats.RANGE; }

}
