// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;
// using System;
// using UnityEngine.SceneManagement;
// using System.Linq;
// using System.IO;
// /*todo
//     -
//     -trades
//     -trinkets
//     -waterborne
//     -weapons
// */
// public class ItemsReader : MonoBehaviour
// {
//     public TextAsset[] jsonData;
//     public Armors armors = new Armors();
//     public Foods foods = new Foods();
//     public Gears gears = new Gears();
//     public Mounts mounts = new Mounts();
//     public Lifestyles lifestyles = new Lifestyles();
//     public Packs packs = new Packs();
//     public Services services = new Services();
//     public Tacks tacks= new Tacks();
//     public Tools tools = new Tools();
//     public Trades trades = new Trades();
//     public Trinkets trinkets = new Trinkets();
//     public Waterbornes waterbornes = new Waterbornes();
//     public Weapons weapons = new Weapons();
//     [System.Serializable]
//     public class Armor
//     {
//         public string name;
//         public string cost;
//         public string ac;
//         public string strength;
//         public string stealth;
//         public string weight;
//         public string description;
//     }
//     [System.Serializable]
//     public class Armors
//     {
//         public Armor[] armor;
//     }

//     [System.Serializable]
//     public class Generic
//     {
//         public string name;
//         public string cost;
//     }
//     [System.Serializable]
//     public class Foods
//     {
//         public Generic[] food;
//     }

//     [System.Serializable]
//     public class Gear
//     {
//         public string name;
//         public string cost;
//         public string weight;
//     }
//     [System.Serializable]
//     public class Gears
//     {
//         public Gear[] gear;
//     }

//     [System.Serializable]
//     public class Lifestyle
//     {
//         public string name;
//         public string cost;
//         public string description;
//     }
//     [System.Serializable]
//     public class Lifestyles
//     {
//         public Lifestyle[] lifestyle;
//     }

//     [System.Serializable]
//     public class Mount
//     {
//         public string name;
//         public string cost;
//         public string speed;
//         public string carryingCapacity;
//     }
//     [System.Serializable]
//     public class Mounts
//     {
//         public Mount[] mount;
//     }

//     [System.Serializable]
//     public class Pack
//     {
//         public string name;
//         public string cost;
//         public string description;
//     }
//     [System.Serializable]
//     public class Packs
//     {
//         public Pack[] pack;
//     }
//     [System.Serializable]
//     public class Services
//     {
//         public Generic[] service;
//     }
//     [System.Serializable]
//     public class Tack
//     {
//         public string name;
//         public string cost;
//         public string weight;
//     }
//     [System.Serializable]
//     public class Tacks
//     {
//         public Tack[] tack;
//     }
//     [System.Serializable]
//     public class Tool
//     {
//         public string name;
//         public string cost;
//         public string weight;
//     }
//     [System.Serializable]
//     public class Tools
//     {
//         public Tool[] tool;
//     }
//     [System.Serializable]
//     public class Trades
//     {
//         public Generic[] trade;
//     }
//     [System.Serializable]
//     public class Trinkets
//     {
//         public Generic[] trinket;
//     }
//     [System.Serializable]
//     public class Waterborne
//     {
//         public string name;
//         public string cost;
//         public string speed;
//     }
//     [System.Serializable]
//     public class Waterbornes
//     {
//         public Waterborne[] waterborne;
//     }
//     [System.Serializable]
//     public class Weapon
//     {
//         public string name;
//         public string cost;
//         public string damage;
//         public string weight;
//         public string properties;
//     }
//     [System.Serializable]
//     public class Weapons
//     {
//         public Weapon[] weapon;
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         armors = JsonUtility.FromJson<Armors>(jsonData[0].text);
//         foods =  JsonUtility.FromJson<Foods>(jsonData[1].text);
//         gears = JsonUtility.FromJson<Gears>(jsonData[2].text);
//         lifestyles = JsonUtility.FromJson<Lifestyles>(jsonData[3].text);
//         mounts = JsonUtility.FromJson<Mounts>(jsonData[4].text);
//         packs = JsonUtility.FromJson<Packs>(jsonData[5].text);
//         services = JsonUtility.FromJson<Services>(jsonData[6].text);
//         tacks = JsonUtility.FromJson<Tacks>(jsonData[7].text);
//         tools = JsonUtility.FromJson<Tools>(jsonData[8].text);
//         trades = JsonUtility.FromJson<Trades>(jsonData[9].text);
//         trinkets = JsonUtility.FromJson<Trinkets>(jsonData[10].text);
//         waterbornes = JsonUtility.FromJson<Waterbornes>(jsonData[11].text);
//         weapons = JsonUtility.FromJson<Weapons>(jsonData[12].text);

//         for (int i = 0; i < armors.armor.Length; i++)
//         {
//             ArmorI temparmor = ScriptableObject.CreateInstance<ArmorI>();
//             temparmor.Name = armors.armor[i].name;
//             temparmor.cost = armors.armor[i].cost;
//             temparmor.armorClass = armors.armor[i].ac;
//             temparmor.Strength = armors.armor[i].strength;
//             temparmor.Stealth = armors.armor[i].stealth;
//             temparmor.Weight = armors.armor[i].weight;
//             temparmor.Description = armors.armor[i].description;
//             SaveScriptableObject(temparmor);
//         }    
//         for (int i = 0; i < foods.food.Length; i++)
//         {
//             FoodI tempfood = ScriptableObject.CreateInstance<FoodI>();
//             tempfood.Name= foods.food[i].name;
//             tempfood.cost = foods.food[i].cost;
//             SaveScriptableObject(tempfood);
//         }  
//         for (int i = 0; i < gears.gear.Length; i++)
//         {
//             GearI temp = ScriptableObject.CreateInstance<GearI>();
//             temp.Name= gears.gear[i].name;
//             temp.cost = gears.gear[i].cost;
//             temp.Weight = gears.gear[i].weight;
//             SaveScriptableObject(temp);
//         } 
//         for (int i = 0; i < lifestyles.lifestyle.Length; i++)
//         {
//             LifestyleI temp = ScriptableObject.CreateInstance<LifestyleI>();
//             temp.Name= lifestyles.lifestyle[i].name;
//             temp.cost = lifestyles.lifestyle[i].cost;
//             temp.Description = lifestyles.lifestyle[i].description;
//             SaveScriptableObject(temp);
//         }
//         for (int i = 0; i < mounts.mount.Length; i++)
//         {
//             MountI temp = ScriptableObject.CreateInstance<MountI>();
//             temp.Name= mounts.mount[i].name;
//             temp.cost = mounts.mount[i].cost;
//             temp.CC = mounts.mount[i].carryingCapacity;
//             temp.speed = mounts.mount[i].speed;
//             SaveScriptableObject(temp);
//         }
//         for (int i = 0; i < packs.pack.Length; i++)
//         {
//             PackI temp = ScriptableObject.CreateInstance<PackI>();
//             temp.Name= packs.pack[i].name;
//             temp.cost = packs.pack[i].cost;
//             temp.Description = packs.pack[i].description;
//             SaveScriptableObject(temp);
//         }
//         for (int i = 0; i < services.service.Length; i++)
//         {
//             ServiceI tempservice = ScriptableObject.CreateInstance<ServiceI>();
//             tempservice.Name= services.service[i].name;
//             tempservice.cost = services.service[i].cost;
//             SaveScriptableObject(tempservice);
//         }
//         for (int i = 0; i < tacks.tack.Length; i++)
//         {
//             TackI temp = ScriptableObject.CreateInstance<TackI>();
//             temp.Name= tacks.tack[i].name;
//             temp.cost = tacks.tack[i].cost;
//             temp.weight = tacks.tack[i].weight;
//             SaveScriptableObject(temp);
//         }
//         for (int i = 0; i < tools.tool.Length; i++)
//         {
//             ToolI temp = ScriptableObject.CreateInstance<ToolI>();
//             temp.Name= tools.tool[i].name;
//             temp.cost = tools.tool[i].cost;
//             temp.weight = tools.tool[i].weight;
//             SaveScriptableObject(temp);
//         }  
//         for (int i = 0; i < trades.trade.Length; i++)
//         {
//             TradeI temp = ScriptableObject.CreateInstance<TradeI>();
//             temp.Name= trades.trade[i].name;
//             temp.cost = trades.trade[i].cost;
//             SaveScriptableObject(temp);
//         } 
//         for (int i = 0; i < trinkets.trinket.Length; i++)
//         {
//             TrinketI temp = ScriptableObject.CreateInstance<TrinketI>();
//             temp.Name= trinkets.trinket[i].name;
//             temp.cost = trinkets.trinket[i].cost;
//             SaveScriptableObject(temp);
//         }   
//         for (int i = 0; i < waterbornes.waterborne.Length; i++)
//         {
//             WaterborneI temp = ScriptableObject.CreateInstance<WaterborneI>();
//             temp.Name= waterbornes.waterborne[i].name;
//             temp.cost = waterbornes.waterborne[i].cost;
//             temp.speed = waterbornes.waterborne[i].speed;
//             SaveScriptableObject(temp);
//         } 
//         for (int i = 0; i < weapons.weapon.Length; i++)
//         {
//             WeaponI temp = ScriptableObject.CreateInstance<WeaponI>();
//             temp.Name= weapons.weapon[i].name;
//             temp.cost = weapons.weapon[i].cost;
//             temp.damage = weapons.weapon[i].damage;
//             temp.weight = weapons.weapon[i].weight;
//             temp.properties = weapons.weapon[i].properties;

//             SaveScriptableObject(temp);
//         } 

//     }

   
// private void SaveScriptableObject(Item itemObject)
// {
//   string folderPath;

//     // Use a switch statement to determine the folder path based on object type
//     switch (itemObject)
//     {
//     case ArmorI type:
//       folderPath = "Assets/Armors";
//       break;
//     case FoodI type: // Assuming you uncomment the FoodI class and constructor
//       folderPath = "Assets/Food";
//       break;
//     case GearI type: // Assuming you uncomment the FoodI class and constructor
//       folderPath = "Assets/Gear";
//       break;
//     case LifestyleI type:
//         folderPath = "Assets/Lifestyle";
//         break;
//     case MountI type:
//         folderPath = "Assets/Mount";
//         break;
//     case PackI type:
//         folderPath = "Assets/Pack";
//         break;
//     case ServiceI type:
//         folderPath = "Assets/Service";
//         break;
//     case TackI type:
//         folderPath = "Assets/Tack";
//         break;
//     case ToolI type:
//         folderPath = "Assets/Tool";
//         break;
//     case TradeI type:
//         folderPath = "Assets/Trade";
//         break;
//     case TrinketI type:
//         folderPath = "Assets/Trinket";
//         break;
//     case WaterborneI type:
//         folderPath = "Assets/Waterborne";
//         break;
//     case WeaponI type:
//         folderPath = "Assets/Weapon";
//         break;
//     // Add more cases for other item types (GearI, LifestyleI, etc.)
//     default:
//       folderPath = "Assets/Items"; // Default path for unknown types
//       Debug.LogWarning($"Unknown item type: {itemObject.GetType()}. Saved to default path.");
//       break;
//   }

//   string fileName = $"{itemObject.Name.Replace(" ", "_")}.asset";
//   string path = $"{folderPath}/{fileName}";
//   if (!Directory.Exists(folderPath))
//   {
//     // Create the folder if it doesn't exist
//     Directory.CreateDirectory(folderPath);
//   }
//   AssetDatabase.CreateAsset(itemObject, path);
//   AssetDatabase.SaveAssets();
//   AssetDatabase.Refresh();
// }
// }
