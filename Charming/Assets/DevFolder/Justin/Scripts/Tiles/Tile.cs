using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public List<GameObject> movements;
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;
    [SerializeField] private bool isWalkableForEnnemy;
    private GridManager gridManager;
    [SerializeField] private Princess1 princess;
    [SerializeField] private Ennemy1 ennemy1;
    public BaseUnit OccupiedUnit;

    private GameObject PrincessDress;
    private GameObject DeathGuard;
    private int ennemyChoice;
    public bool Walkable => isWalkable && OccupiedUnit == null;
    public bool WalkableForEnnemy => isWalkableForEnnemy && OccupiedUnit == null;
    private int Range2;

    [SerializeField] private int posX, posY;
    private Color  originalColor;
    private GridManager myGrid;
    private void Start()
    {
        DeathGuard = GameObject.Find("DeathGuardManager");
        PrincessDress = GameObject.FindGameObjectWithTag("Player");
        originalColor = this.GetComponent<SpriteRenderer>().color;
        princess = GameObject.FindGameObjectWithTag("PrincessPlayer").GetComponent<Princess1>();
        ennemy1 = GameObject.FindGameObjectWithTag("Ennemi").GetComponent<Ennemy1>();
    }

    public virtual void Init(int x, int y, GridManager gridMgr)
    {
        posX = x;
        posY = y;
        myGrid = gridMgr;

        
        
    }

    private void Update()
    {
        DeathGuard.GetComponent<deathguard>().IsGuardDead = ennemy1.IsEnemyDead;
        DeathGuard.GetComponent<deathguard>().IsGameOver = princess.IsPrincessDead;

        if (princess == null || ennemy1 == null)
        {
            return;
        }
        else
        {
            if (princess.IsPrincessDead || ennemy1.IsEnemyDead)
            {
                PrincessDress.transform.position = myGrid.LastPrincessPos;
                GameObject.Destroy(princess.gameObject, 1f);
                GameObject.Destroy(ennemy1.gameObject, 1f);
            }
        }
        
        switch (ennemyChoice)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
        if (ennemyChoice == 1)
        {
            if (princess.transform.position.x == ennemy1.transform.position.x + 1
      && princess.transform.position.y == ennemy1.transform.position.y || princess.transform.position.x == ennemy1.transform.position.x - 1
      && princess.transform.position.y == ennemy1.transform.position.y || princess.transform.position.y == ennemy1.transform.position.y + 1
      && princess.transform.position.x == ennemy1.transform.position.x || princess.transform.position.y == ennemy1.transform.position.y - 1
      && princess.transform.position.x == ennemy1.transform.position.x)
            {
                var inflitcDamageToPrincess = princess.OccupiedTile.OccupiedUnit;
                inflitcDamageToPrincess.GetComponent<BaseUnit>().Damage(20 - inflitcDamageToPrincess.GetComponent<BaseUnit>().Defense_Player);
                ennemyChoice = 3; 
            }
            else
            {
                ennemyChoice = 3;
            }
        }

        //if (ennemy1 == null || princess == null)
        //    princess = null;

        if (this.transform.position != ennemy1.transform.position && this.transform.position != princess.transform.position)
        {
            OccupiedUnit = null;
        }


        if (ennemy1 != null)

            if (FightManager.Instance.GameState == FightManager.Gamestate.PrincessTurn)
            if (this.transform.position.x <= princess.OccupiedTile.transform.position.x)
            {
                isWalkable = true;
                
            }
            else
            {
                isWalkable = false;
            }
            
        if (FightManager.Instance.GameState == FightManager.Gamestate.EnnemiesTurn && ennemy1 != null)
        {
           

            if (ennemy1.transform.position.x > princess.transform.position.x && ennemyChoice == 0)
            {
                
                if (posX <= ennemy1.OccupiedTile.posX && Vector3.Distance(this.transform.position, ennemy1.transform.position) <= 1)
                { 
                    isWalkableForEnnemy = true;
                    ennemy1.transform.position = this.transform.position;
                    
                    ennemy1.OccupiedTile = this;
                    ennemy1.OccupiedTile.OccupiedUnit = null;
                    OccupiedUnit = ennemy1;
                    ennemyChoice = 1;
                    FightManager.Instance.GameState = FightManager.Gamestate.PrincessTurn;
                }
            }

            if (ennemy1.transform.position.x < princess.transform.position.x && ennemyChoice == 0)
            {
                
                if (posX > ennemy1.transform.position.x && Vector3.Distance(this.transform.position, ennemy1.transform.position) <= 1)
                {
                    isWalkableForEnnemy = true;
                    ennemy1.transform.position = this.transform.position;
                    ennemy1.OccupiedTile = this;
                    ennemy1.OccupiedTile.OccupiedUnit = null;
                    OccupiedUnit = ennemy1;
                    ennemyChoice = 1;
                    FightManager.Instance.GameState = FightManager.Gamestate.PrincessTurn;
                }
            }

            if (ennemy1.transform.position.y < princess.transform.position.y && ennemyChoice == 0)
            {
                
                if (posY > ennemy1.transform.position.y && Vector3.Distance(this.transform.position, ennemy1.transform.position) <= 1)
                {
                    isWalkableForEnnemy = true;
                    ennemy1.transform.position = this.transform.position;
                    ennemy1.OccupiedTile = this;
                    ennemy1.OccupiedTile.OccupiedUnit = null;
                    OccupiedUnit = ennemy1;
                    ennemyChoice = 1;
                    FightManager.Instance.GameState = FightManager.Gamestate.PrincessTurn;
                }
            }

            if (ennemy1.transform.position.y > princess.transform.position.y && ennemyChoice == 0)
            {
                
                if (posY < ennemy1.transform.position.y && Vector3.Distance(this.transform.position, ennemy1.transform.position) <= 1)
                {
                    isWalkableForEnnemy = true;
                    ennemy1.transform.position = this.transform.position;
                    ennemy1.OccupiedTile = this;
                    ennemy1.OccupiedTile.OccupiedUnit = null;
                    OccupiedUnit = ennemy1;
                    ennemyChoice = 1;
                    FightManager.Instance.GameState = FightManager.Gamestate.PrincessTurn;
                }
            }
        }
       

        else
            {
                isWalkableForEnnemy = false;
                FightManager.Instance.GameState = FightManager.Gamestate.PrincessTurn;
            }



       

        if (ButtonManager.Instance.choicePrincessAction == 2)
        {
                if (posX == princess.OccupiedTile.posX + 2
                && posY == princess.OccupiedTile.posY || posX == princess.OccupiedTile.posX - 2
                && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 2
                && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 2
                && posX == princess.OccupiedTile.posX)
                    _renderer.color = Color.red;
        }
        if (ButtonManager.Instance.choicePrincessAction == 3)
        {
            if (posX == princess.OccupiedTile.posX + 1
            && posY == princess.OccupiedTile.posY || posX == princess.OccupiedTile.posX - 1
            && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 1
            && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 1
            && posX == princess.OccupiedTile.posX)
                _renderer.color = Color.red;
        }
        if (ButtonManager.Instance.choicePrincessAction == 1)
        {
            if(posX == princess.OccupiedTile.posX + 1 
                && posY == princess.OccupiedTile.posY || posX == princess.OccupiedTile.posX - 1 
                && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 1 
                && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 1
                && posX == princess.OccupiedTile.posX)
            {
                _renderer.color = Color.red;
            }
        }
        if(ButtonManager.Instance.choicePrincessAction == 0)
        {
            _renderer.color = originalColor;
        }
        

    }
    private void OnMouseEnter()
    {
        highlight.SetActive(true);
        MenuFightManager.Instance.ShowTileInfo(null);
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (FightManager.Instance.GameState != FightManager.Gamestate.PrincessTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Princess)
            {
                UnitManager.Instance.SetSelectedPrincess((BasePrincess)OccupiedUnit);     
            }

            else
            {
                if (UnitManager.Instance.SelectedPrincess != null)
                {
                    if(ButtonManager.Instance.choicePrincessAction == 2 && OccupiedUnit.Faction == Faction.Ennemy)
                    {
                        
                        if (posX == princess.transform.position.x + 2
                            && posY == princess.OccupiedTile.posY || posX == princess.transform.position.x - 2
                            && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 2
                            && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 2
                            && posX == princess.transform.position.x)
                        {
                            var ennemy = (BaseEnnemy)OccupiedUnit;
                            ennemy.GetComponent<BaseUnit>().Damage(20 + ennemy.GetComponent<BaseUnit>().Damage_Player);

                        ennemyChoice = 0;
                        UnitManager.Instance.SetSelectedPrincess(null);
                            ButtonManager.Instance.choicePrincessAction = 0;
                            FightManager.Instance.ChangeState(FightManager.Gamestate.EnnemiesTurn);
                        }
                    }

                    if (ButtonManager.Instance.choicePrincessAction == 3 && OccupiedUnit.Faction == Faction.Ennemy)
                    {

                        if (posX == princess.transform.position.x + 1
                            && posY == princess.OccupiedTile.posY || posX == princess.transform.position.x - 1
                            && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 1
                            && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 1
                            && posX == princess.transform.position.x)
                        {
                            var ennemy = (BaseEnnemy)OccupiedUnit;
                            ennemy.GetComponent<BaseUnit>().Damage(30 + ennemy.GetComponent<BaseUnit>().Damage_Player);

                            ennemyChoice = 0;
                            UnitManager.Instance.SetSelectedPrincess(null);
                            ButtonManager.Instance.choicePrincessAction = 0;
                            FightManager.Instance.ChangeState(FightManager.Gamestate.EnnemiesTurn);
                        }
                    }

                }
            }          
        }
        else
        {
            if(UnitManager.Instance.SelectedPrincess != null)
            {
                {
                    if (ButtonManager.Instance.choicePrincessAction == 1)
                    {
                        if (posX == princess.OccupiedTile.posX + 1 && posY == princess.OccupiedTile.posY || posX == princess.OccupiedTile.posX - 1 && posY == princess.OccupiedTile.posY || posY == princess.OccupiedTile.posY + 1 && posX == princess.OccupiedTile.posX || posY == princess.OccupiedTile.posY - 1 && posX == princess.OccupiedTile.posX)
                        {
                            MoveUnit(UnitManager.Instance.SelectedPrincess);
                            UnitManager.Instance.SetSelectedPrincess(null);
                            ennemyChoice = 0;
                            FightManager.Instance.ChangeState(FightManager.Gamestate.EnnemiesTurn);
                        }
                    }
                                          
                }
                
            }

        }
    }

    private void Damage(BaseEnnemy baseEnnemy, object unit)
    {
        throw new NotImplementedException();
    }
  
    public void SetUnit(BaseUnit princess)
    {
        if (princess.OccupiedTile != null)
            princess.OccupiedTile.OccupiedUnit = null;
            princess.transform.position = transform.position;
            OccupiedUnit = princess;
            princess.OccupiedTile = this;
    }
    public void MoveUnit(BaseUnit princess)
    {    
        if (princess.OccupiedTile != null)
            princess.OccupiedTile.OccupiedUnit = null;
            princess.transform.position = transform.position;
            OccupiedUnit = princess;
            princess.OccupiedTile = this;
        ButtonManager.Instance.choicePrincessAction = 0;
    }
}
