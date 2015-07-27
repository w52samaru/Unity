using UnityEngine;
using System.Collections;

public class Load : Token {
	public float fixVX (float X, float Y, float VX){
		if ( (X > 0.9f && X < 1.1f) && (Y > -0.1f && Y < 0.1f)  ) {
			VX = 0.0f;
			//VY = 1.0f;
			
		}
		if ( (X > 0.9f && X < 1.1f) && (Y > 0.9f && Y < 1.1f) ) {
			VX = 1.0f;
			//VY = 0.0f;
		}
		return VX;
	}
	public float fixVY (float X, float Y, float VY){
		if ( (X > 0.9f && X < 1.1f) && (Y > -0.1f && Y < 0.1f)  ) {
			//VX = 0.0f;
			VY = 1.0f;
			
		}
		if ( (X > 0.9f && X < 1.1f) && (Y > 0.9f && Y < 1.1f) ) {
			//VX = 1.0f;
			VY = 0.0f;
		}
		return VY;
	}
	// 経路
	public float[] goload(float X, float Y, float VX, float VY){
		float[] VL = new float[2];
		
		VL[0] = VX;	
		VL[1] = VY;

		if (decide (X, Y, 0.0f, 0.0f)) {
			VL [0] = 0.1f;
			VL [1] = 1.0f;
		}
		if (decide (X,Y,1.0f,0.0f)) {
				VL [0] = 1.0f/1.4f;
				VL [1] = 1.0f/1.4f;
		}
		return VL;
	}
	// 位置の判定
	private bool decide(float X, float Y, float XX, float YY){
		bool result = false; 
		if ((X > XX-0.1f && X < XX+0.1f) && (Y > YY-0.1f && Y < YY+0.1f)) {
			result = true;
		}
		return result;
	}
}

