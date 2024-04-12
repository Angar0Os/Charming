using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> units;
    public BasePrincess SelectedPrincess;
    public BaseEnnemy SelectedEnnemy;

    public GameObject DeathGuardManager;
   

    private void Awake()
    {
        Instance = this;
        DeathGuardManager = GameObject.Find("DeathGuardManager");
        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnPrincess()
    {
        var princessCount = 1;

        for (int i = 0; i < princessCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePrincess>(Faction.Princess);
            var SpawnnedPrincess = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetPrincessSpawnTile();

            randomSpawnTile.SetUnit(SpawnnedPrincess);
        }
        FightManager.Instance.ChangeState(FightManager.Gamestate.SpawnEnnemies);
    }

    public void SpawnEnnemies()
    {
        if(DeathGuardManager.GetComponent<deathguard>().Type == 1)
        {
            Debug.Log("Guard");

            var randomPrefab = GetGuard<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();
            Debug.Log(randomPrefab);
            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);
        }

        if (DeathGuardManager.GetComponent<deathguard>().Type == 2)
        {
            var randomPrefab = GetWolf<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);

            Debug.Log("Animal");
        }
        

        if (DeathGuardManager.GetComponent<deathguard>().Type == 3)
        {
            var randomPrefab = GetPrince<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);

            Debug.Log("Prince");
        }

        if (DeathGuardManager.GetComponent<deathguard>().Type == 4)
        {
            var randomPrefab = GetKing<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);

            Debug.Log("King");
        }

        if (DeathGuardManager.GetComponent<deathguard>().Type <= 0 || DeathGuardManager.GetComponent<deathguard>().Type > 4)
        {
            var randomPrefab = GetRandomUnit<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);
        }

        else 
        {
            var randomPrefab = GetGuardTuto<BaseEnnemy>(Faction.Ennemy);
            var SpawnedEnnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnnemySpawnTile();

            randomSpawnTile.SetUnit(SpawnedEnnemy);
            FightManager.Instance.ChangeState(FightManager.Gamestate.PrincessTurn);
        }

    }

    private Guard GetGuard<Guard>(Faction faction) where Guard : BaseEnnemy
    {
        return (Guard)units[0].UnitPrefrab;
    }

    private Prince GetPrince<Prince>(Faction faction) where Prince : BaseEnnemy
    {
        return (Prince)units[1].UnitPrefrab;
    }
    private Wolf GetWolf<Wolf>(Faction faction) where Wolf : BaseEnnemy
    {
        return (Wolf)units[2].UnitPrefrab;
    }

    

    private King GetKing<King>(Faction faction) where King : BaseEnnemy
    {
        return (King)units[3].UnitPrefrab;
    }

    private Princess GetRandomUnit<Princess>(Faction faction) where Princess : BaseUnit
    {
        return (Princess)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefrab;
    }

    private GuardTuto GetGuardTuto<GuardTuto>(Faction faction) where GuardTuto : BaseEnnemy
    {
        return (GuardTuto)units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefrab;
    }
    public void SetSelectedPrincess(BasePrincess princess)
    {
        SelectedPrincess = princess;
        MenuFightManager.Instance.ShowSelectedPrincess(princess);
    }
    
    public void SetSelectedEnnemy(BaseEnnemy ennemy)
    {
        SelectedEnnemy = ennemy;
    }

    //public void SetMovementPrincess(BasePrincess princess)
    //{
    //    SelectedPrincess = princess;
    //}
}
