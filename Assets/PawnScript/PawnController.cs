using UnityEngine;
using System.Collections;
using MapDataStruture;

public class PawnController : MonoBehaviour {

	// Use this for initialization
	public Pawn[,] pawns;
 	public bool[,] occupied8X6 = new bool[8,6];
	public bool[,] occupied7X7 = new bool[7,7];
	public Warrior WarriorPrefab;
	public Wizard WizardPrefab;
	public Archer ArcherPrefab;
	public Farmer FarmerPrefab;

	public ArrayList redPawns;
	public ArrayList bluePawns;
	public ArrayList redWarriors;
	public ArrayList blueWarriors;
	public ArrayList redWizard;
	public ArrayList blueWizard;
	public ArrayList redArcher;
	public ArrayList blueArcher;
	public ArrayList redFarmer;
	public ArrayList blueFarmer;

	public enum GameScale{
		_8X6,
		_7X7
	};

	public enum PawnClass
	{
	  Warrior,
	  Wizard,
	  Archer,
	  Farmer
	};

	public GameScale nowGameScale = GameScale._8X6;


	public PawnController(int[] random){

	
	}

	public Pawn[,] getPawns(){
		return pawns; 
	}

	public Pawn getPawn(int x,int y){
		return pawns [x, y];
	}
	public Pawn getPawn(Coordinate c){
		return pawns [c.x, c.y];
	} 

	public void setPawn(PawnClass type,int x,int y,int team){
		if (pawns [x, y] != null)
			return;
		Pawn newPawn;
		if(type == PawnClass.Warrior)
			newPawn = Instantiate(WarriorPrefab,new Vector3(-7+2*x,1.0f,-7+2*y),Quaternion.identity);
		else if(type==PawnClass.Wizard)
			newPawn = Instantiate(WizardPrefab,new Vector3(-7+2*x,1.0f,-7+2*y),Quaternion.identity);
		else if(type==PawnClass.Archer)
			newPawn = Instantiate(ArcherPrefab,new Vector3(-7+2*x,1.0f,-7+2*y),Quaternion.identity);
		else if(type==PawnClass.Farmer)
			newPawn = Instantiate(FarmerPrefab,new Vector3(-7+2*x,1.0f,-7+2*y),Quaternion.identity);
		newPawn.setPosition(x,y);
		newPawn.setTeam(team);
		newPawn.setPawnController(this);
		pawns[x,y]= newPawn;
	}

	public void turnStart(int team){
		if (team == 0)
			foreach (Pawn p in redPawns) {
				p.calculateMove ();
				p.calculateAttack ();
			}
		else if (team == 1)
			foreach (Pawn p in bluePawns) {
				p.calculateMove();
				p.calculateAttack();
			}
	}

	public void goAttack(int team){
		if (team == 0) {
			foreach(Pawn p in redPawns)
				p.calculateTarget();
			foreach(Pawn p in redPawns)
				p.attack();
		} 
		else if (team == 1) {
			foreach(Pawn p in bluePawns)
				p.calculateTarget();
			foreach(Pawn p in bluePawns)
				p.attack();
		}

	}

	public void Make8X6Pawns(int[] random){
		int i,j,a,b;
		Pawn newPawn;

		nowGameScale = GameScale._8X6;

		for (i=0; i<8; i++)
			for (j=0; j<6; j++)
				occupied8X6 [i] [j] = false;

		for(i=0;i<3;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(WarriorPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setPosition(a,b);
			newPawn.setTeam(0);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=3;i<6;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(WarriorPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(1);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=6;i<9;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(WizardPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(0);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=9;i<12;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(WizardPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(1);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=12;i<15;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(ArcherPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(0);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=15;i<18;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(ArcherPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(1);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=18;i<21;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(FarmerPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(0);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
		for(i=21;i<24;i++){
			a = random[i]/6;
			b= random[i]%6;
				newPawn = Instantiate(FarmerPrefab,new Vector3(-7+2*a,1.0f,-7+2*b),Quaternion.identity);
			newPawn.setTeam(1);
			newPawn.setPosition(a,b);
			newPawn.setPawnController(this);
			pawns[a,b]= newPawn;
		}
	}

	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
