package mapEditor.BaseUI;

public class Vector2 {
	
	public float X;
	public float Y;
	
	public Vector2() {
		this(0,0);
	}
	public Vector2(float x, float y) {
		this.X = x;
		this.Y = y;
	}
	
	public float Magnitude() {
		return (float)Math.hypot((double)this.X, (double)this.Y);
	}
	public float Dot(Vector2 b) {
		return (this.X * b.X) + (this.Y * b.Y); 
	}
	public Vector2 Normalise() {
		return this.Divide(this.Magnitude());
	}
	public Vector2 Add(Vector2 b) {
		return new Vector2(this.X+b.X,this.Y+b.Y);
	}
	public Vector2 Subtract(Vector2 b) {
		return new Vector2(this.X-b.X,this.Y-b.Y);
	}
	public Vector2 Divide(float b) {
		return new Vector2(this.X/b,this.Y/b);
	}
	public Vector2 Multiply(float b) {
		return new Vector2(this.X*b,this.Y*b);
	}

}
