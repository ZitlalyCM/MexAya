class Arrow{
    constructor(){
      
      this.r = 35;
      this.x = width;
      this.y = height - this.r;
       
    }
  move(){
    this.x -= 7;
  }
  
  show(){
    image(tImg, this.x, this.y, this.r, this.r);
    
    fill(255, 50);
    //ellipseMode(CORNER);
    rect(this.x,this.y,this.r,this.r);
  }
}