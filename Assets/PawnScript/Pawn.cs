using UnityEngine;
using System.Collections;
using MapDataStruture;
public abstract class Pawn : MonoBehaviour {

	// Use this for initialization
	public enum Shape{
		Diamond,
		Square,
		Cross
	};
	public enum Action
	{
		Veiled,
		Waiting,
		Moving,
		Attacking,
		Injured
	};

	/*public struct Coordinate{
		public int x;
		public int y;
		public Coordinate(int xx ,int yy){x=xx;y=yy;}
	};
	*/
	public int maxHP;
	public ArrayList attackRangeList;
	public ArrayList moveRangeList;
	public ArrayList targetList;
	public Shape attackShape;
	public bool Triggered;
	public int HP;
	public int moveRange;
	public int maxAttackRange;
	public int minAttackRange;
	public int ATK;
	public int LV;
	public Coordinate pos;
	public PawnController mapgrid;
	public int team ;
	public PawnController PC;
	public PawnController.GameScale nowGameScale;
	public int maxScaleX,maxScaleY;
	public bool[,] check;
	public gameStateManager GM;
	public int n = 0;
	public Action nowAction;

	void Start () {
		this.nowGameScale = PC.nowGameScale;
		if (nowGameScale == PawnController.GameScale._8X6) {
			maxScaleX=8;
			maxScaleY=6;
			check = new bool[8,6];
		} else if (nowGameScale == PawnController.GameScale._7X7) {
			maxScaleX=7;
			maxScaleY=7;
			check = new bool[8,6];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPawnController(PawnController PC){
		this.PC = PC;
	}

	public void setTeam(int whichTeam){
		this.team = whichTeam;
	}

	public void setPosition(int xx,int yy){
		pos.x = xx;
		pos.y = yy;
	}

	public void upgrade (int nowlevel){

	}

	public void onDamage (int damage){
		// Play animation
		HP = HP - damage;
		if (HP > maxHP)
			HP = maxHP;

		if (HP <= 0)
			destroy ();

	}

	public void attack(){
		calculateTarget ();
		foreach (Pawn p in targetList) {
			// Play animation
			p.onDamage(this.ATK);
		}
	}

	public void move(Coordinate des){
		//Play animation
		if (nowGameScale == PawnController.GameScale._8X6) {
			PC.occupied8X6[pos.x,pos.y] = false;
			PC.occupied8X6[des.x,des.y]=true;
			PC.pawns[des.x,des.y] = this;
			PC.pawns[pos.x,pos.y]=null;
		} else if (nowGameScale == PawnController.GameScale._7X7) {
			PC.occupied7X7[pos.x,pos.y]=false;
			PC.occupied7X7[des.x,des.y]=true;
			PC.pawns[des.x,des.y] = this;
			PC.pawns[pos.x,pos.y]=null;

		}
		calculateAttack ();

	}

	public void destroy(){
		if (nowGameScale == PawnController.GameScale._8X6)
			PC.occupied8X6[pos.x,pos.y] = false;	
		else if(nowGameScale==PawnController.GameScale._7X7)
			PC.occupied7X7[pos.x,pos.y] = false;
		Destroy (gameObject);
	}

	public void unveil(){
		if (this.Triggered == false)
			this.Triggered = true;

	}


	public  void calculateMove(){
		int i,j;
		moveRangeList.Clear ();
		for(i=0;i<maxScaleX;i++)
			for(j=0;j<maxScaleY;j++)
				check[i,j]=false;
		n = 0;
		detect (this.pos);
		
		for (i=0; i<maxScaleX; i++)
			for (j=0; j<maxScaleY; j++)
			if (check [i,j] == true) {
				moveRangeList.Add(new Coordinate(i,j));
			}


	}

	public void calculateAttack(){
		int i,j;
		attackRangeList.Clear ();
		for(i=0;i<maxScaleX;i++)
			for(j=0;j<maxScaleY;j++)
				check[i,j]=false;
		
		if (attackShape == Shape.Diamond) {
			for (i=maxAttackRange; i>=-maxAttackRange; i--)   // Diamond
				for (j=(maxAttackRange-i); j>=(-maxAttackRange+i); j--)
					if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
						check [pos.x + i,pos.y + j] = true;
			for (i=minAttackRange; i>=-minAttackRange; i--)   // Diamond
				for (j=(minAttackRange-i); j>=(-minAttackRange+i); j--)
					if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
						check [pos.x + i,pos.y + j] = false;
			
		} else if (attackShape == Shape.Square) {
			for (i=maxAttackRange; i>=-maxAttackRange; i--)   // Diamond
				for (j=maxAttackRange; i>=-maxAttackRange; j--)
					if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
						check [pos.x + i,pos.y + j] = true;
			for (i=minAttackRange; i>=-minAttackRange; i--)   // Diamond
				for (j=minAttackRange; i>=-minAttackRange; j--)
					if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
						check [pos.x + i,pos.y + j] = false;
		} else if (attackShape == Shape.Cross) {
			j=0;
			for(i=7;i>=-7;i--)
				if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
					check[pos.x+i,pos.y+j] = true;
			i=0;
			for(j=7;j>=-7;j--)
				if(pos.x+i<maxScaleX&&pos.y+j<maxScaleY)
					check[pos.x+i,pos.y+j] = true;
		}
		
		
		for (i=0; i<maxScaleX; i++)
			for (j=0; j<maxScaleY; j++)
			if (check [i,j] == true) {
				attackRangeList.Add(new Coordinate(i,j));
			}
	}
	

	public void detect(Coordinate loc){
		if (  n > moveRange)
			return;
		
		if (nowGameScale == PawnController.GameScale._8X6 && PC.occupied8X6 [loc.x,loc.y] == true)
			return;
		else if (nowGameScale == PawnController.GameScale._7X7 && PC.occupied7X7 [loc.x,loc.y] == true)
			return;
		check [loc.x,loc.y] = true;
		
		n++;
		detect (new Coordinate (loc.x + 1, loc.y));
		detect (new Coordinate (loc.x , loc.y+1));
		detect (new Coordinate (loc.x - 1, loc.y));
		detect (new Coordinate (loc.x , loc.y-1));
		n--;
		return;
	}

	public void calculateTarget(){
		targetList.Clear ();
		foreach(Coordinate c in attackRangeList){
			if(PC.pawns[c.x,c.y]!=null)
				if(PC.pawns[c.x,c.y].team!=this.team&&PC.pawns[c.x,c.y].Triggered==true)
				targetList.Add(PC.pawns[c.x,c.y]);
		}
	}

	
}
