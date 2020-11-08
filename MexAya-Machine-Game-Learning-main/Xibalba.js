class Xibalba{
  constructor(){
    this.r = 90;
    this.x = 50;
    this.y = height -this.r;
    this.vy = 0;
    this.gravity = 1.2
  }
  jump(){
    if(this.y == height - this.r){
      this.vy = -20;
    }
    
  }
  
  hits(Arrow){
  //  let x1 = this.x + this.r * 0.5;
  //  let y1 = this.y + this.r * 0.5;
  //  let x2 = Arrow.x + Arrow.r * 0.5;
  //  let y2 = Arrow.y + Arrow.r * 0.5;
    return collideRectRect(this.x, this.y, this.r, this.r,Arrow.x, Arrow.y, Arrow.r, Arrow.r)
    
  }
  move(){
    this.y += this.vy;
    this.vy += this.gravity;
    this.y = constrain(this.y, 0, height -this.r);
  }
  
  show(){
    image(uImg,this.x,this.y, this.r, this.r);
    
    fill(255, 50);
    //ellipseMode(CORNER);
    rect(this.x,this.y,this.r,this.r);
  }
  
}