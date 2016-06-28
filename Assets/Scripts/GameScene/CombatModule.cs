using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CombatModule : MonoBehaviour
{
    // A list that will hold data for all the weapons in the game
    List<WeaponStats> weaponList = new List<WeaponStats>();
    
    // Use this for initialization
    void Start()
    {
        FileReader fr = new FileReader();
        weaponList = fr.ReadWeaponStatsFromFile(Application.dataPath + "/WeaponData/Weapons.txt");
        SpawnWeaponOnPlayer(weaponList[0].getName());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(int a_damage, GameObject a_target)
    {
        if (a_target.GetComponent<CombatModuleAttributes>())
        {
            a_target.GetComponent<CombatModuleAttributes>().ModifyHealth(-a_damage);
            Vector2 ss = Camera.main.WorldToScreenPoint(a_target.transform.position);

            GameObject a = Instantiate(Resources.Load("DamageText"), ss, Quaternion.identity) as GameObject;
            a.GetComponent<DamageText>().SetText("" + a_damage);
        }
    }

    private void SpawnWeaponOnPlayer(string weaponName)
    {
        GameObject t = Instantiate(Resources.Load(weaponName + "_Group"), GameObject.Find("WeaponSpawnPosition").transform.position, Quaternion.identity) as GameObject;
        t.name = weaponName + "_Group";
        t.transform.parent = GameObject.Find("UpperTorso").transform;

        Debug.Log(gameObject.name);

        gameObject.GetComponent<AnimationModule>().SetWeaponAnimator(t.name);
        gameObject.GetComponent<AnimationModule>().SetWeaponObjectName(t.name);
    }


}
