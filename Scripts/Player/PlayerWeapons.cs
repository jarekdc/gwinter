using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerWeapons : MonoBehaviour {

    public Weapon CurrentMeleeWeapon { get; set; }
    public Weapon CurrentRangedWeapon { get; set; }

    public class Weapon
    {
        public string WeaponName { get; set; }
        public int Id { get; set; }
        public bool Melee { get; set; }
        public int Dmg { get; set; }
        public float AttackSpeed { get; set; }
        public int Ammo { get; set; }

        public Weapon(string wName, int id, bool melee, int dmg, float atSpd, int ammo)
        {
            this.WeaponName = wName;
            this.Id = id;
            this.Melee = melee;
            this.Dmg = dmg;
            this.AttackSpeed = atSpd;            
            this.Ammo = ammo;
        }
    }

    void Start()
    {
        Weapon tHHammer = new Weapon("Two-Handed Hammer", 0, true, 10, 10, 0);
        Weapon shotgun = new Weapon("Shotgun", 1, false, 10, 10, 10);
        CurrentMeleeWeapon = tHHammer;
        CurrentRangedWeapon = shotgun;
    }

    void Update()
    {
       
    }
}
