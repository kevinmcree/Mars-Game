using UnityEngine;
using System.Collections;

public class ColorConverter{
	

	public static Color HSVAtoRGBA(Color hsva){
		return HSVAtoRGBA(hsva.r, hsva.g, hsva.b, hsva.a);
	}

	/* Converts from HSVA to RGBA
	 * 
	 * H - Hue. Any value from 0 to 360
	 * S - Saturation. Any value from 0 to 1
	 * V - Value/Brightness. Any value from 0 to 1
	 * A - Alpha. Any value from 0 to 1
	 */
	public static Color HSVAtoRGBA(float H, float S, float V, float A){
		S = Mathf.Clamp (S, 0, 1);
		V = Mathf.Clamp (V, 0, 1);
		A = Mathf.Clamp (A, 0, 1);
		Color ret = new Color ();
		ret.a = A;
		float C = V*S;
		float X = C * (1 - Mathf.Abs ((H / 60) % 2 - 1));
		float m = V - C;
		switch (((int)H / 60)%6) {
		case 0:
			ret.r = C;
			ret.g = X;
			ret.b = 0;
			break;
		case 1:
			ret.r = X;
			ret.g = C;
			ret.b = 0;
			break;
		case 2:
			ret.r = 0;
			ret.g = C;
			ret.b = X;
			break;
		case 3:
			ret.r = 0;
			ret.g = X;
			ret.b = C;
			break;
		case 4:
			ret.r = X;
			ret.g = 0;
			ret.b = C;
			break;
		case 5:
			ret.r = C;
			ret.g = 0;
			ret.b = X;
			break;
		}
		ret.r += m;
		ret.g += m;
		ret.b += m;
		return ret;
	}

	public static Color RGBAtoHSVA(Color col){
		Color retVal = new Color();
		retVal.a = col.a;

		float R = col.r/255;
		float G = col.g/255;
		float B = col.b/255;

		float min = Mathf.Min(R, G, B);
		float max = Mathf.Max(R, G, B);
		retVal.b = max;

		float delta = max - min;

		if(max != 0){
			retVal.g = delta/max;
		} else {
			retVal.g = 0;
			retVal.r = -1;
			return retVal;
		}

		if( R == max){
			retVal.r = (G-B)/delta;
		} else if (G== max){
			retVal.r = 2+ (B-R)/delta;
		} else{
			retVal.r = 4+(R-G)/delta;
		}
		retVal.r *= 60;

		if(retVal.r < 0){
			retVal.r += 360;
		}
		return retVal;
	}
	
}
